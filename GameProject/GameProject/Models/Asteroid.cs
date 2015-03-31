namespace GameProject.Models
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using GameProject.Interfaces;

    public class Asteroid : Projectile, IMovableObject, ICollidable, IDestructable, IProjectile, IRenderable
    {
        private const int AsteroidSpeed = 4;
        private const int AsteroidDamage = 20;
        public const int AsteroidPoints = 5;

        // Constructor
        public Asteroid(Texture2D newTexture, Vector2 newPosition) 
            : base(newTexture, newPosition, AsteroidSpeed, AsteroidDamage)
        {
        }        

        // Update
        public void Update(GameTime gameTime)
        {
            // Set bounding box for collision
            this.BoundingBox = new Rectangle((int)this.position.X, (int)this.position.Y, this.Texture.Width, this.Texture.Height);

            // update movement
            this.position.Y = this.position.Y + this.Speed;
            if (this.position.Y >= Game1.ScreenHeight)
            {
                this.position.Y = -50;
            }
        }

        // Draw
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (this.IsVisible)
            {
                spriteBatch.Draw(this.Texture, this.Position, Color.White);
            }
        }        
    }
}
