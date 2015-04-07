namespace GameProject.GameObjects
{
    using System;
    using GameProject.Interfaces;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public abstract class MovingObject : IMovableObject, IRenderable
    {
        protected Vector2 position;
        private int speed;

        public MovingObject(Texture2D texture, Vector2 position, int speed)
        {
            this.Texture = texture;
            this.position = position;
            this.Speed = speed;
        }

        public Texture2D Texture { get; protected set; }

        public Vector2 Position
        {
            get
            {
                return this.position;
            }
        }

        public int Speed
        {
            get
            {
                return this.speed;
            }

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