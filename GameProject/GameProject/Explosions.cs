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

    public class Explosion
    {
        public Texture2D texture;
        public Vector2 position;
        public float timer;
        public float interval;
        public Vector2 origin;
        public int currentFrame, spriteWidth, spriteHeight;
        public Rectangle sourceRect;
        public bool isVisible;

        //Consructor
        public Explosion(Texture2D newTexter, Vector2 newPosition)
        {
            position = newPosition;
            texture = newTexter;
            timer = 0f;
            interval = 20f;
            currentFrame = 1;
            spriteWidth = 128;
            spriteHeight = 128;
            isVisible = true;
        }

        //Load Content
        public void LoadContent(ContentManager content)
        {

        }

        //Update
        public void Update(GameTime gameTime)
        {
            //increse the timer by the number of milliseconds since update was last called
            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            //Check the time is more than chosen interval
            if (timer > interval)
            {
                //Show next frame
                currentFrame++;
                //reset timer
                timer = 0f;
            }
            // if were the last frame , make explosion zero and reset currentFrame

            if (currentFrame == 17)
            {
                isVisible = false;
                currentFrame = 0;
            }
            sourceRect = new Rectangle(currentFrame * spriteWidth, 0, spriteWidth, spriteHeight);
            origin = new Vector2(sourceRect.Width / 2, sourceRect.Height / 2);
        }

        //Draw

        public void Draw(SpriteBatch spriteBatch)
        {
            if (isVisible == true)
            {
                spriteBatch.Draw(texture, position, sourceRect, Color.White, 0f, origin, 1.0f, SpriteEffects.None, 0);
            }
        }
    }
}