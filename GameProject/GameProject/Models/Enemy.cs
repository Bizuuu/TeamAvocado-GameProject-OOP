namespace GameProject.Models
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using GameProject.Interfaces;

    public abstract class Enemy : Ship, IShooting, IMovableObject, ICollidable, IDestructable
    {

        public Enemy(Texture2D texture, Vector2 position, int speed, int health, int bulletDelay)
            : base(texture, position, speed, health, bulletDelay)
        {
            this.IsVisible = true;
        }

        public bool IsVisible { get; set; }
        public int EnemyPoints { get; protected set; }
        public int EnemyShipDamage { get; protected set; }

        public void DestroyObject()
        {
            this.IsVisible = false;
        }

        //Draw
        public override void Draw(SpriteBatch spriteBatch)
        {
            // Draw enemy ship
            spriteBatch.Draw(this.Texture, this.Position, Color.White);

            // Draw enemy bullets
            foreach (Ammunition b in this.BulletList)
            {
                b.Draw(spriteBatch);
            }
        }

        // Update
        public abstract void Update(GameTime gameTime);

        public abstract override void Shoot();

        public abstract override void UpdateProjectiles();
    }
}
