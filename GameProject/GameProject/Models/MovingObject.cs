
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

    public abstract class MovingObject : IMovableObject, IRenderable
    {
        protected Vector2 position;
        private Texture2D texture;
        private int speed;

        public MovingObject(Texture2D texture, Vector2 position, int speed)
        {
            this.Texture = texture;
            this.position = position;
            this.Speed = speed;
        }

        public Texture2D Texture
        {
            get { return this.texture; }
            protected set { this.texture = value; }
        }

        public Vector2 Position
        {
            get { return this.position; }
        }

        public int Speed
        {
            get { return this.speed; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Speed can not be assigned 0 or negative.");
                }
                this.speed = value;
            }
        }

        public abstract void Draw(SpriteBatch spriteBatch);
    }
}
