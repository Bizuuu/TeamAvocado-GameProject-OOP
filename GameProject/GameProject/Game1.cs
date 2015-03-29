using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace GameProject
{
    //Main
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Random random = new Random();
        public int enemyBulletDamage;

        //Asteroid List
        List<Asteroid> asteroidList = new List<Asteroid>();
        List<Enemy> enemyList = new List<Enemy>();
        List<Explosion> explosionList = new List<Explosion>();

        //Instanting our player and starfield objects
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
            this.Window.Title = "XNA 2D Space Shooter";
            Content.RootDirectory = "Content";
            enemyBulletDamage = 10;
        }

        //Init
        protected override void Initialize()
        {
            base.Initialize();
        }

        //Load Content
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            hud.LoadContent(Content);
            p.LoadContent(Content);
            sf.LoadContent(Content);
        }

        //Upload Content
        protected override void UnloadContent()
        {
        }

        //Update
        protected override void Update(GameTime gameTime)
        {
            //Allows the Game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // Updating Enemies and checking collision of enemy ship to player ship
            foreach (Enemy e in enemyList)
            {
                // Check if enemyship is colliding with player
                if (e.boundingBox.Intersects(p.boundingBox))
                {
                    p.health -= 40;
                    e.isVisible = false;
                }

                // Check enemy bullet collision with player ship
                for (int i = 0; i < e.bulletList.Count; i++)
                {
                    if (p.boundingBox.Intersects(e.bulletList[i].boundingBox))
                    {
                        p.health -= enemyBulletDamage;
                        e.bulletList[i].isVisible = false;
                    }
                }

                // Check player bullet collision to enemy ship
                for (int i = 0; i < p.bulletList.Count; i++)
                {
                    if (p.bulletList[i].boundingBox.Intersects(e.boundingBox))
                    {
                        explosionList.Add(new Explosion(Content.Load<Texture2D>("explosion3"), new Vector2(e.position.X, e.position.Y)));
                        hud.playerScore += 20;
                        p.bulletList[i].isVisible = false;
                        e.isVisible = false;
                    }
                }

                e.Update(gameTime);
            }
            foreach(Explosion ex in explosionList)
            {
                ex.Update(gameTime);
            }

            //for each asteroid in our asteroidList, update it and check for collisions
            foreach (Asteroid a in asteroidList)
            {

                //check if any asteroids are colliding with player
                // if they are set visible to false
                if (a.boundingBox.Intersects(p.boundingBox))
                {
                    p.health -= 20;// later make a variable asteroidDamage in the Asteroid class(could change if we put levels in the game);
                    a.isVisible = false;
                }
                //Iterate through our bulletList if any asteroids come in contacts with trhese bulets, destroy bulets and asteroids
                for (int i = 0; i < p.bulletList.Count; i++)
                {
                    if (a.boundingBox.Intersects(p.bulletList[i].boundingBox))
                    {
                        explosionList.Add(new Explosion(Content.Load<Texture2D>("explosion3"), new Vector2(a.position.X, a.position.Y)));
                        hud.playerScore += 5;
                        a.isVisible = false;
                        p.bulletList.ElementAt(i).isVisible = false;// or p.bulletList[i], we'll see later what level of abstraction we'll need;

                    }
                }
                a.Update(gameTime);
            }

            hud.Update(gameTime);
            p.Update(gameTime);
            sf.Update(gameTime);
            ManageExplosions();
            LoadAsteroids();
            LoadEnemies();

            base.Update(gameTime);
        }

        //Draw
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();

            sf.Draw(spriteBatch);
            p.Draw(spriteBatch);

            foreach (Explosion ex in explosionList)
            {
                ex.Draw(spriteBatch);
            }
             
            foreach (Asteroid a in this.asteroidList)
            {
                a.Draw(spriteBatch);

            }

            foreach (Enemy e in this.enemyList)
            {
                e.Draw(spriteBatch);
            }

            hud.Draw(spriteBatch); 
            spriteBatch.End();

            base.Draw(gameTime);
        }

        // Load Asteroids
        public void LoadAsteroids()
        {
            //Creating random variables for X and Y axis of our asteroids
            int randY = this.random.Next(-600, -50);
            int randX = this.random.Next(0, 750);

            //if there are less than 5 asteroids on the screen, then create more until there are 5 again
            if (this.asteroidList.Count() < 5)
            {
                this.asteroidList.Add(new Asteroid(Content.Load<Texture2D>("asteroid"), new Vector2(randX, randY)));
            }

            //If any of the asteroids in the list were destroyed (or invisible), then remove them from the list
            for (int i = 0; i < this.asteroidList.Count; i++)
            {
                if (!this.asteroidList[i].isVisible)
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
            int randY = random.Next(-600, -50);
            int randX = random.Next(0, 750);


            // If there less than 3 enemies on the screen, then create more untill there is 3 agin
            if (enemyList.Count() < 3)
            {
                enemyList.Add(new Enemy(Content.Load<Texture2D>("enemyship"), new Vector2(randX, randY), Content.Load<Texture2D>("EnemyBullet")));
            }

            //if any of enemies in the list were destroyed (or invisible), then remove from the list
            for (int i = 0; i < enemyList.Count; i++)
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
