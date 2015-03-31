
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

    public abstract class Ship : MovingObject, IShooting, IMovableObject, ICollidable, IRenderable
    {
        // Shooting variables
        private int bulletDelay;
        private IList<IProjectile> bulletList;
        //Collision variable
        private Rectangle boundingBox;

        //Constructor
        public Ship(Texture2D texture, Vector2 position, int speed, int health, int bulletDelay )
            : base(texture, position, speed)
        {            
            this.Health = health;
            this.BulletDelay = bulletDelay;
            this.bulletList = new List<IProjectile>();
        }

        public int Health { get; set; }

        public int BulletDelay
        {
            get { return this.bulletDelay; }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Can not set bullet delay to less than zero.");
                }
                this.bulletDelay = value;
            }
        }

        public IList<IProjectile> BulletList
        {
            get { return new List<IProjectile>(this.bulletList); }
        }

        public Rectangle BoundingBox
        {
            get { return this.boundingBox; }
            protected set { this.boundingBox = value; }
        }
                
        public abstract void Shoot();

        public abstract void UpdateProjectiles();

        public void ClearBullets()
        {
            this.bulletList.Clear();
        }

        protected void AddBullet(IProjectile projectile)
        {
            if (projectile == null)
            {
                throw new ArgumentNullException("Can not add projectile that is null.");
            }
            this.bulletList.Add(projectile);
        }

        protected void RemoveBulletAtPosition(int bulletPosition)
        {
            this.bulletList.RemoveAt(bulletPosition);
        }



        public abstract override void Draw(SpriteBatch spriteBatch);
    }
}
