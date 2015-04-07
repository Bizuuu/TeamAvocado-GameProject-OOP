namespace GameProject.Models
{
    using GameProject.Interfaces;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    public class Starfield : MovingObject, IMovableObject, IRenderable
    {
        private const float FirstCoordY = 0;
        private const float SecondCoordY = -Game1.ScreenHeight;
        private Vector2 secondPosition;
        private static Starfield instance = null;

        public const int StarfieldSpeed = 5;

        // Constructor
        private Starfield(Texture2D texture, Vector2 position, int speed)
            : base(null, new Vector2(0, FirstCoordY), StarfieldSpeed)
        {
            this.secondPosition = new Vector2(0, SecondCoordY);
        }

        private Starfield()
            : this(null, new Vector2(0, FirstCoordY), StarfieldSpeed)
        {
        }

        public Vector2 SecondPosition { get { return this.secondPosition; } }
 
        public static Starfield getInstance()
        {
            if (instance == null)
            {
                instance = new Starfield();
            }

            return instance;
        }

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