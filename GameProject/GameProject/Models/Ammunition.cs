namespace GameProject.Models
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using GameProject.Interfaces;

    public abstract class Ammunition : Projectile, IProjectile, IMovableObject, ICollidable, IDestructable, IRenderable
    {
        public Ammunition(Texture2D texture, Vector2 position, int speed, int damage)
            : base(texture, position, speed, damage)
        {            
        }

        public abstract void UpdateAmmoMovement();

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.Texture, this.Position, Color.White);
        }
    }
}
