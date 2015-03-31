    
namespace GameProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using GameProject.Interfaces;

    public abstract class Projectile : MovingObject, IProjectile, IMovableObject, ICollidable, IDestructable, IRenderable
    {
        private int damage;

        public Projectile(Texture2D texture, Vector2 position, int speed, int damage)
            : base(texture, position, speed)
        {
            this.Damage = damage;
            this.IsVisible = true;
        }

        public Rectangle BoundingBox { get; set; }

        public int Damage
        {
            get { return this.damage; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Damage can not be set to negative.");
                }
                this.damage = value;
            }
        }

        public bool IsVisible { get; set; }

        public void DestroyObject()
        {
            this.IsVisible = false;
        }

        public abstract override void Draw(SpriteBatch spriteBatch);
    }
}
