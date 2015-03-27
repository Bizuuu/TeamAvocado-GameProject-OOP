namespace GameProject
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.Xna.Framework;
    //using Microsoft.Xna.Framework.Audio;
    using Microsoft.Xna.Framework.Content;
    //using Microsoft.Xna.Framework.GamerServices;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    //using Microsoft.Xna.Framework.Media;

    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Random random = new Random();
        public int enemmyBulletDamage;

        //Lists
        List<Asteroid> asteoridList = new List<Asteroid>();
        List<Enemy> enemyList = new List<Enemy>();
        List<Explosion> explosionList = new List<Explosion>();

        //Instantaiting our Player and Starfield objects
        Player p = new Player();
        Starfield sf = new Starfield();
        HUD hud = new HUD();

        //Constructor
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.IsFullScreen = false;
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 950;
            this.Window.Title = "Avocado TEAM SPACE SHOOTER";
            Content.RootDirectory = "Content";
            enemmyBulletDamage = 10;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        /// Initialization
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }
        // LoadContent will be called once per game and is the place to load
        // all of your content.

        // Load Content
        protected override void UnloadContent()
        {
            spriteBatch =new SpriteBatch (GraphicsDevice;)
 	
            hud.LoadContent(Content);
            p.LoadContent(Content);
            sf.LoadContent(Content);
        }
        //Unload Content
        protected override void UnloadContent()
        {

        }

        //Update

        protected override void Update(GameTime gameTime)
        {
            //Allows the game to exit 
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back = ButtonState.Pressed)
                this.Exit();
            //Updating Enemy's and checking collision of enemyship or playership
            foreach (Enemy e in enemyList)
            {

                //check if enemy ship  is colliding with player
                if (e.boundingBox.Intersects(p.boundingBox))
                {
                    p.health -= 40;
                    e.isVisible = false;
                }
                //Check enemy bullet collision with player ship
                for (int i = 0; i < e.bulletList.Count; i++)
                {
                    if (p.boundingBox.Intersects(e.bulletList[i].boundingBox))
                    {
                        p.health -= enemmyBulletDamage;
                        e.bulletList[i].isVisible = false;
                    }
                }

                //Check Player bullet colliosion to enemy ship
                for (int i = 0; i < p.bulletList.Count; i++)
                {
                    if (p.bulletList[i].boundingBox.Intersects(e.boundingBox))
                    {
                        explosionList.Add(new Explosion(Content.Load("explosion3"), new Vector2(e.position.X, e.position.Y)));
                        hud.playerScore += 20;
                        p.bulletList[i].isVisible = false;
                        e.isVisible = false;

                    }
                }

                e.Update(gameTime);
            }

            foreach (var ex in explosionList)
            {
                ex.Update(gameTime);
            }
            //for each asteroid in our asteroidList, update it and check for collisions
            foreach (Asteroid a in asteoridList)
            {

                //check if any asteroids are colliding with player
                // if they are set visible to false
                if (a.boundingBox.Intersects(p.boundingBox))
                {
                    p.health -= 20;
                    a.isVisible = false;
                }
                //Iterate through our bulletList if any asteroids come in contacts with trhese bulets, destroy bulets and asteroids
                for (int i = 0; i < p.bulletList.Count; i++)
                {
                    if (a.boundingBox.Intersects(p.bulletList[i].boundingBox))
                    {
                        explosionList.Add(new Explosion(Content.Load("explosion3"), new Vector2(a.position.X, a.position.Y)));
                        hud.playerScore += 5;
                        a.isVisible = false;
                        p.bulletList.ElementAt(i).isVisible = false;

                    }
                }
                a.Update(gameTime);
            }
            // hud.Update(gameTime);
            p.Update(gameTime);
            sf.Update(gameTime);
            ManageExplosions();
            LoadAsteroids();
            LoadEnemies();

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        //DRAW
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();

            sf.Draw(spriteBatch);
            p.Draw(spriteBatch);

            foreach (var ex in explosionList)
            {
                ex.Draw(spriteBatch);
            }


            foreach (Asteroid a in asteoridList)
            {
                a.Draw(spriteBatch);
            }
            foreach (Enemy e in enemyList)
            {
                e.Draw(spriteBatch);
            }

            hud.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
        //Load Asteroids
        public void LoadAsteroids()
        {
            //Creating random variables for our X and Y axis of our asteroids
            int randY = random.Next(-600, -50);
            int randX = random.Next(0, 750);


            // If there less than 5 asteroids on the screen,then creat more untill there is 5 agin
            if (asteoridList.Count() < 5)
            {
                asteoridList.Add(new Asteroid(Content.Load<Texture2D>("asteroid"), new Vector2(randX, randY)));
            }

            //if any of asteroids in the list were destroyed (or invisible), then remove from the list
            for (int i = 0; i < asteoridList.Count; i++)
            {
                if (!asteoridList[i].isVisible)
                {
                    asteoridList.RemoveAt(i);
                    i--;
                }
            }
        }
        // Load enemies

        public void LoadEnemies()
        {
            //Creating random variables for our X and Y axis of our asteroids
            int randY = random.Next(-600, -50);
            int randX = random.Next(0, 750);


            // If there less than 3 asteroids on the screen,then creat more untill there is 5 agin
            if (asteoridList.Count() < 3)
            {
                enemyList.Add(new Enemy(Content.Load<Texture2D>("enemyship"), new Vector2(randX, randY), Content.Load<Texture2D>("EnemyBullet")));
            }

            //if any of enemies in the list were destroyed (or invisible), then remove from the list
            for (int i = 0; i < asteoridList.Count; i++)
            {
                if (!enemyList[i].isVisible)
                {
                    enemyList.RemoveAt(i);
                    i--;
                }
            }
        }

        //Manage Explosions
        public void ManageExplosions()
        {
            for (int i = 0; i < explosionList.Count; i++)
            {
                if (!explosionList[i].isVisible)
                {
                    explosionList.RemoveAt(i);
                    i--;
                }
            }
        }
    }
}
