namespace GameProject.Models
{
    using System;
    using System.Collections.Generic;
    using GameProject.Interfaces;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public abstract class Ship : MovingObject, IShooting, IMovableObject, ICollidable, IRenderable
    {
        private readonly IList<IProjectile> bulletList;
        // Shooting variables
        private int bulletDelay;

        //Collision variable
        //Constructor
        public Ship(Texture2D texture, Vector2 position, int speed, int health, int bulletDelay) : base(texture, position, speed)
        { 
            this.Health = health;
            this.BulletDelay = bulletDelay;
            this.bulletList = new List<IProjectile>();
        }

        public int Health { get; set; }

        public int BulletDelay
        {
            get
            {
                return this.bulletDelay;
            }

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
            get
            {
                return new List<IProjectile>(this.bulletList);
            }
        }

        public Rectangle BoundingBox { get; protected set; }
                
        public abstract void Shoot();

        public abstract void UpdateProjectiles();

        public override void Draw(SpriteBatch spriteBatch)
        {
            // Draw ship
            spriteBatch.Draw(this.Texture, this.Position, Color.White);

            // Draw ship's bullets
            foreach (Ammunition b in this.BulletList)
            {
                b.Draw(spriteBatch);
            }
        }

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
    }
}