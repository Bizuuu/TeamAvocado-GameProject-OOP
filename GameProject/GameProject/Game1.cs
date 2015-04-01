namespace GameProject
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using GameProject.Interfaces;
    using GameProject.Models;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using Microsoft.Xna.Framework.Media;

    //Main
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        public const int ScreenHeight = 700; // Can be changed
        public const int ScreenWidth = 800; // Can be changed
        public const int NumberOfEnemiesOnScreen = 3;
        public const int TypesOfEnemies = 1; // could be more(for now - only NormalEnemy);
        public const int MaxAsteroidsOnScreen = 5;
        public const int TypesOfBonuses = 2; // could be more;
        public const int MinBonusesInPlay = 2;        

        // For Veselin to incorporate Singleton with this. If not - make it an automatic prop;
        private readonly Starfield sf = new Starfield();       

        // Fields
        private readonly List<Asteroid> asteroidList;
        private readonly List<IEnemy> enemyList;
        private readonly List<Explosion> explosionList;
        private readonly List<BonusObject> bonusesList;

        //Constructor
        public Game1()
        {
            this.Graphics = new GraphicsDeviceManager(this);
            this.Graphics.IsFullScreen = false;
            this.Graphics.PreferredBackBufferWidth = ScreenWidth;
            this.Graphics.PreferredBackBufferHeight = ScreenHeight;
            this.Window.Title = "XNA 2D Space Shooter";
            this.Content.RootDirectory = "Content";
            this.SM = SoundManager.Instance; // Created inside the class SoundManager using Singleton design pattern;
            this.Player = new Player();
            this.Hud = new HUD();
            this.asteroidList = new List<Asteroid>();
            this.enemyList = new List<IEnemy>();
            this.bonusesList = new List<BonusObject>();
            this.explosionList = new List<Explosion>();
            this.RandomGenerator = new Random();
            this.MenuImage = null;
            this.GameOverImage = null;
            this.GameState = State.Menu;
        }

        // Properties
        public SoundManager SM { get; private set; }

        public GraphicsDeviceManager Graphics { get; set; }

        public SpriteBatch SpriteBatch { get; set; }

        public Texture2D MenuImage { get; private set; }

        public Texture2D GameOverImage { get; private set; }

        public Player Player { get; private set; }

        public HUD Hud { get; private set; }

        public State GameState { get; private set; }

        public Random RandomGenerator { get; private set; }

        public List<Asteroid> AsteroidList
        {
            get
            {
                return new List<Asteroid>(this.asteroidList);
            }
        }

        public List<IEnemy> EnemyList
        {
            get
            {
                return new List<IEnemy>(this.enemyList);
            }
        }

        public List<Explosion> ExplosionList
        {
            get
            {
                return new List<Explosion>(this.explosionList);
            }
        }

        public List<BonusObject> BonusesList
        {
            get
            {
                return new List<BonusObject>(this.bonusesList);
            }
        }

        // Load Asteroids
        public void LoadAsteroids()
        {
            //Creating random variables for X and Y axis of our asteroids
            int randY = this.RandomGenerator.Next(-1, 0);
            int randX = this.RandomGenerator.Next(0, ScreenWidth - 50);

            //if there are less than 5 asteroids on the screen, then create more until there are 5 again
            if (this.asteroidList.Count() < MaxAsteroidsOnScreen)
            {
                this.asteroidList.Add(new Asteroid(this.Content.Load<Texture2D>("asteroid"), new Vector2(randX, randY)));
            }

            //If any of the asteroids in the list were destroyed (or invisible), then remove them from the list
            for (int i = 0; i < this.asteroidList.Count; i++)
            {
                if (!this.asteroidList[i].IsVisible)
                {
                    this.asteroidList.RemoveAt(i);
                    i--;
                }
            }
        }

        // Load Enemies
        public void LoadEnemies()
        {
            //Creating random variables for our X and Y axis of our asteroids
            int randY = this.RandomGenerator.Next(-1, 0);
            int randX = this.RandomGenerator.Next(0, ScreenWidth - 50);
            int randEnemy = this.RandomGenerator.Next(0, TypesOfEnemies);

            // If there less than 3 enemies on the screen, then create more untill there is 3 agin
            if (this.enemyList.Count() < NumberOfEnemiesOnScreen)
            {
                switch (randEnemy)
                {
                    case 0:
                        this.enemyList.Add(new NormalEnemy(this.Content.Load<Texture2D>("enemyship"),
                            new Vector2(randX, randY),
                            this.Content.Load<Texture2D>("EnemyBullet")));
                        break;
                // Extend with more, if there is more than 1 type of enemy;
                //case 1:
                //    // enemyList.Add(new SomeOtherKindOfEnemy();)
                //    break;                    
                }
            }
            //if any of enemies in the list were destroyed (or invisible), then remove from the list
            for (int i = 0; i < this.enemyList.Count; i++)
            {
                if (!this.enemyList[i].IsVisible)
                {
                    this.enemyList.RemoveAt(i);
                    i--;
                }
            }
        }

        // Load Bonuses
        public void LoadBonuses()
        {
            //Creating random variables for X and Y axis of our bonuses
            int randY = this.RandomGenerator.Next(25, ScreenHeight / 2); // Bonuses will appear on the top part of the screen;
            int randX = this.RandomGenerator.Next(-500, 0);
            int randBonus = this.RandomGenerator.Next(0, TypesOfBonuses);

            //if there are less than 2 bonuses on the screen, then create more until there are 2 again
            if (this.BonusesList.Count() < MinBonusesInPlay)
            {
                switch (randBonus)
                {
                    case 0:
                        this.bonusesList.Add(new BonusDamage(this.Content.Load<Texture2D>("damageBonus"), new Vector2(randX, randY)));
                        break;
                    case 1:
                        this.bonusesList.Add(new BonusHealth(this.Content.Load<Texture2D>("heartBonus"), new Vector2(randX, randY)));
                        break;
                // Extend with more, if there is more than 2 types of bonus;
                //case 2:
                //    // bonusesList.Add(new SomeOtherKindOfBonus();)
                //    break;
                }
            }

            // If any of the asteroids in the list were destroyed (or invisible), then remove them from the list
            for (int i = 0; i < this.BonusesList.Count; i++)
            {
                if (!this.bonusesList[i].IsVisible)
                {
                    this.bonusesList.RemoveAt(i);
                    i--;
                }
            }
        }

        //Manage Explosions
        public void ManageExplosions()
        {
            for (int i = 0; i < this.explosionList.Count; i++)
            {
                if (!this.explosionList[i].IsVisible)
                {
                    this.explosionList.RemoveAt(i);
                    i--;
                }
            }
        }

        //Init
        //Load Content
        protected override void LoadContent()
        {
            this.SpriteBatch = new SpriteBatch(this.GraphicsDevice);
            this.Hud.LoadContent(this.Content);
            this.Player.LoadContent(this.Content);
            this.sf.LoadContent(this.Content);
            this.SM.LoadContent(this.Content);
            this.MenuImage = this.Content.Load<Texture2D>("menuScreen");
            this.GameOverImage = this.Content.Load<Texture2D>("gameOverScreen");
        }

        //Update
        protected override void Update(GameTime gameTime)
        {
            //Allows the Game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
            {
                this.Exit();
            }

            switch (this.GameState)
            {
                // UPDATE MENU STATE
                case State.Menu:
                    {
                        //Get Keyboard State
                        KeyboardState keyState = Keyboard.GetState();

                        if (keyState.IsKeyDown(Keys.Enter))
                        {
                            this.GameState = State.Playing;
                            MediaPlayer.Play(this.SM.BgMusic);
                        }

                        this.sf.Update(gameTime);
                        this.sf.Speed = 1;
                        break;
                    }
                    //UPDATE PLAYING STATE
                case State.Playing:
                    {
                        this.sf.Speed = Starfield.StarfieldSpeed;
                        // Updating Enemies and checking collision of enemy ship to player ship

                        // Polymorphism - accessing the child class of Enemy prop's and methods;
                        foreach (IEnemy e in this.EnemyList)  
                        {
                            // Check if enemyship is colliding with player
                            if (e.BoundingBox.Intersects(this.Player.BoundingBox))
                            {
                                SoundCaller explosionOccured = new SoundCaller(this.SM.ExplodeSound); // Event handling;
                                this.Player.Health -= e.EnemyShipDamage/* /p.DefensePower*/;
                                this.Player.ResetBonusEffects(); // When player is hit - attack, defense bonus are set to their initial value;
                                e.DestroyObject();
                            }

                            // Check enemy bullet collision with player ship
                            for (int i = 0; i < e.BulletList.Count; i++)
                            {
                                if (this.Player.BoundingBox.Intersects(e.BulletList[i].BoundingBox)) // Bullets in bulletlists are accessed through their parrent class Projectile - Polymorphism;
                                {
                                    this.Player.Health -= e.BulletList[i].Damage/* /p.DefensePower*/;

                                    // When player is hit - attack, defense bonus are set to their initial value;
                                    this.Player.ResetBonusEffects();
                                    e.BulletList[i].DestroyObject();
                                }
                            }

                            // Check player bullet collision to enemy ship
                            for (int i = 0; i < this.Player.BulletList.Count; i++)
                            {
                                if (this.Player.BulletList[i].BoundingBox.Intersects(e.BoundingBox))
                                {
                                    e.Health -= this.Player.BulletList[i].Damage * this.Player.AttackPower;
                                    this.Player.BulletList[i].DestroyObject();
                                    if (e.Health <= 0)
                                    {
                                        SoundCaller explosionOccured = new SoundCaller(this.SM.ExplodeSound); // Event handling;
                                        this.explosionList.Add(new Explosion(this.Content.Load<Texture2D>("explosion3"), new Vector2(e.Position.X, e.Position.Y)));
                                        this.Hud.PlayerScore += e.EnemyPoints;
                                        e.DestroyObject();
                                    }
                                }
                            }

                            e.Update(gameTime);
                        }

                        foreach (Explosion ex in this.ExplosionList)
                        {
                            ex.Update(gameTime);
                        }

                        // for each asteroid in our asteroidList, update it and check for collisions
                        foreach (Asteroid a in this.AsteroidList)
                        {
                            // check if any asteroids are colliding with player
                            // if they are set visible to false
                            if (a.BoundingBox.Intersects(this.Player.BoundingBox))
                            {
                                this.Player.Health -= a.Damage/* /p.DefensePower*/;
                                this.Player.ResetBonusEffects(); // When player is hit - attack, defense bonus are set to their initial value;
                                a.DestroyObject();
                            }

                            //Iterate through our bulletList if any asteroids come in contacts with trhese bulets, destroy bulets and asteroids
                            for (int i = 0; i < this.Player.BulletList.Count; i++)
                            {
                                if (a.BoundingBox.Intersects(this.Player.BulletList[i].BoundingBox))
                                {
                                    SoundCaller explosionOccured = new SoundCaller(this.SM.ExplodeSound); // Event handling;
                                    this.explosionList.Add(new Explosion(this.Content.Load<Texture2D>("explosion3"), new Vector2(a.Position.X, a.Position.Y)));
                                    this.Hud.PlayerScore += Asteroid.AsteroidPoints;
                                    a.DestroyObject();
                                    this.Player.BulletList[i].DestroyObject();
                                }
                            }

                            a.Update(gameTime);
                        }

                        //for each bonus in our bonusesList, update it and check for collisions
                        foreach (BonusObject bonus in this.BonusesList)
                        {
                            //check if any bonuses are colliding with player
                            // if they are set visible to false
                            if (bonus.BoundingBox.Intersects(this.Player.BoundingBox))
                            {
                                bonus.DistributeBonusEffect(this.Player);
                                // maybe display in HUD for 1 sec a text "... bonus" above/below the health bar, if someone has the time;
                                bonus.DestroyObject();
                            }
                            
                            bonus.Update(gameTime);
                        }

                        // If a player health is zero - game over;

                        if (this.Player.Health <= 0)
                        {
                            this.GameState = State.Gameover;
                        }

                        this.Hud.Update(gameTime);
                        this.Player.Update(gameTime);
                        this.sf.Update(gameTime);
                        this.ManageExplosions();
                        this.LoadAsteroids();
                        this.LoadEnemies();
                        this.LoadBonuses();
                        break;
                    }
                    //UPDATE GAME OVER STATE
                case State.Gameover:
                    {
                        //Get Keyboard State
                        KeyboardState keyState = Keyboard.GetState();

                        if (keyState.IsKeyDown(Keys.Escape))
                        {
                            this.enemyList.Clear();
                            this.asteroidList.Clear();
                            this.Player.ClearBullets();
                            this.bonusesList.Clear();
                            this.explosionList.Clear();
                            this.Player.ResetStartPosition();
                            this.Player.Health = Player.InitialPlayerHealth;
                            this.Hud.PlayerScore = HUD.InititalPlayerScore;
                            this.GameState = State.Menu;
                        }

                        // Stop music
                        MediaPlayer.Stop();
                        break;
                    }
            }

            base.Update(gameTime);
        }

        //Draw
        protected override void Draw(GameTime gameTime)
        {
            this.GraphicsDevice.Clear(Color.Black);
            this.SpriteBatch.Begin();

            switch (this.GameState)
            {
                // DRAW MENU STATE
                case State.Menu:
                    {
                        this.sf.Draw(this.SpriteBatch);
                        this.SpriteBatch.Draw(this.MenuImage, new Vector2(0, 0), Color.White);
                        break;
                    }
                    // DRAW PLAYING STATE
                case State.Playing:
                    {
                        this.sf.Draw(this.SpriteBatch);
                        this.Player.Draw(this.SpriteBatch);
                        foreach (Explosion ex in this.ExplosionList)
                        {
                            ex.Draw(this.SpriteBatch);
                        }

                        foreach (Asteroid a in this.AsteroidList)
                        {
                            a.Draw(this.SpriteBatch);
                        }

                        foreach (IEnemy e in this.EnemyList)
                        {
                            e.Draw(this.SpriteBatch);
                        }

                        foreach (BonusObject bonus in this.BonusesList)
                        {
                            bonus.Draw(this.SpriteBatch);
                        }

                        this.Hud.Draw(this.SpriteBatch);
                        break;
                    }

                    // DRAW GAME OVER STATE
                case State.Gameover:
                    {
                        this.SpriteBatch.Draw(this.GameOverImage, new Vector2(0, 0), Color.White);
                        this.SpriteBatch.DrawString(this.Hud.PlayerScoreFont, string.Format("Your score is: {0}", this.Hud.PlayerScore.ToString()),
                            new Vector2(0, 0), Color.Red);
                        break;
                    }
            }

            this.SpriteBatch.End();

            base.Draw(gameTime);
        }
    }
}