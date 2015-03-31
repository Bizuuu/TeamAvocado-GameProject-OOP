namespace GameProject.Models
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using GameProject.Interfaces;

    public class Explosion : IRenderable
    {      
        //Consructor
        public Explosion(Texture2D newTexture, Vector2 newPosition)
        {
            this.Position = newPosition;
            this.Texture = newTexture;
            this.Timer = 0f;
            this.Interval = 20f;
            this.CurrentFrame = 1;
            this.SpriteWidth = newTexture.Height;
            this.SpriteHeight = newTexture.Height;
            this.IsVisible = true;
        }

        public Vector2 Position { get; set; }

        public Texture2D Texture { get; set; }

        public float Timer { get; set; }

        public float Interval { get; set; }

        public int CurrentFrame { get; set; }

        public int SpriteWidth { get; set; }

        public int SpriteHeight { get; set; }

        public bool IsVisible { get; set; }

        public Rectangle SourceRect { get; set; }

        public Vector2 Origin { get; set; }

        //Update
        public void Update(GameTime gameTime)
        {
            //increse the timer by the number of milliseconds since update was last called
            this.Timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            //Check the time is more than chosen interval
            if (this.Timer > this.Interval)
            {
                //Show next frame
                this.CurrentFrame++;
                //reset timer
                this.Timer = 0f;
            }
            // if were the last frame , make explosion zero and reset currentFrame

            if (this.CurrentFrame == 17)
            {
                this.IsVisible = false;
                this.CurrentFrame = 0;
            }
            this.SourceRect = new Rectangle(this.CurrentFrame * this.SpriteWidth, 0, this.SpriteWidth, this.SpriteHeight);
            this.Origin = new Vector2(this.SourceRect.Width / 2, this.SourceRect.Height / 2);
        }

        //Draw

        public void Draw(SpriteBatch spriteBatch)
        {
            if (this.IsVisible == true)
            {
                spriteBatch.Draw(this.Texture, this.Position, this.SourceRect, Color.White, 0f, this.Origin, 1.0f, SpriteEffects.None, 0);
            }
        }

    }
}
