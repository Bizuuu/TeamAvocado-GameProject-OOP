namespace GameProject.Models
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using GameProject.Interfaces;

    public class Starfield : MovingObject, IMovableObject, IRenderable
    {
        private const float FirstCoordY = 0;
        private const float SecondCoordY = -Game1.ScreenHeight;
        public const int StarfieldSpeed = 5;

        private Vector2 secondPosition;

        // Constructor
        public Starfield(Texture2D texture, Vector2 position, int speed)
            : base(null, new Vector2(0, FirstCoordY), StarfieldSpeed)
        {
            this.secondPosition = new Vector2(0, SecondCoordY);
        }

        public Starfield()
            : this(null, new Vector2(0, FirstCoordY), StarfieldSpeed)
        {

        }

        public Vector2 SecondPosition { get { return this.secondPosition; } }

        // Load Content 
        public void LoadContent(ContentManager Content)
        {
            this.Texture = Content.Load<Texture2D>("space");
        }

        //Draw
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.Texture, this.Position, Color.White);
            spriteBatch.Draw(this.Texture, this.SecondPosition, Color.White);
        }

        // Update
        public void Update(GameTime gameTime)
        {
            // Setting speed for background scrolling
            this.position.Y = this.position.Y + this.Speed;
            this.secondPosition.Y = this.secondPosition.Y + this.Speed;

            // Scrolling background (Repeating)
            if (this.Position.Y >= Game1.ScreenHeight)
            {
                this.position.Y = 0;
                this.secondPosition.Y = -Game1.ScreenHeight;
            }
        }
    }
}
