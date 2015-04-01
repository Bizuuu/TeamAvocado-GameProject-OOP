namespace GameProject.Models
{
    using System;
    using GameProject.Interfaces;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public abstract class Ammunition : MovingObject, IProjectile, IMovableObject, ICollidable, IDestructable, IRenderable
    {
        private int damage;

        public Ammunition(Texture2D texture, Vector2 position, int speed, int damage) : base(texture, position, speed)
        {
            this.Damage = damage;
            this.IsVisible = true;
        }

        public int Damage
        {
            get 
            { 
                return this.damage; 
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Damage can not be set to negative.");
                }

                this.damage = value;
            }
        }

        public Rectangle BoundingBox { get; set; }

        public bool IsVisible { get; set; }

        public abstract void UpdateAmmoMovement();

        public void DestroyObject()
        {
            this.IsVisible = false;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.Texture, this.Position, Color.White);
        }
    }
}