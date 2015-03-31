﻿namespace GameProject.Models
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
    using GameProject;

    public class PlayerBullet : Ammunition, IProjectile, IMovableObject, ICollidable, IDestructable
    {
        private const int PlayerBulletDamage = 10;

        public PlayerBullet(Texture2D texture, Vector2 position, int speed)
            : base(texture, position, speed, PlayerBulletDamage)
        {
        }

        public override void UpdateAmmoMovement()
        {
            // bounding box for every bullet in the bulletList;
            this.BoundingBox = new Rectangle((int)this.Position.X, (int)this.Position.Y,
                this.Texture.Width, this.Texture.Height);

            //set movement for bullet
            this.position.Y -= this.Speed;

            //if bullet hits the top of the screen, then make visible false
            if (this.Position.Y <= 0)
            {

                this.IsVisible = false;
            }
        }
    }
}
