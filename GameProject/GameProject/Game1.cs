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

        //Asteroid List
        List<Asteroid> asteroidList = new List<Asteroid>();

        //Instanting our player and starfield objects
        Player p = new Player();
        Starfield sf = new Starfield();


        //Constructor
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.IsFullScreen = false;
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 950;
            this.Window.Title = "XNA 2D Space Shooter";
            Content.RootDirectory = "Content";
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
            //Allows the Game to wxit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            //for each asteroid in our asteroidList, Update it
            foreach (Asteroid a in this.asteroidList)
            {
                a.Update(gameTime);

            }


            p.Update(gameTime);
            sf.Update(gameTime);
            LoadAsteroids();

            base.Update(gameTime);
        }

        //Draw
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();

            sf.Draw(spriteBatch);
            p.Draw(spriteBatch);

            foreach (Asteroid a in this.asteroidList)
            {
                a.Draw(spriteBatch);

            }

            spriteBatch.End();

            base.Draw(gameTime);
        }

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
    }
}
