namespace GameProject.Models
{
    using GameProject.Interfaces;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    public class HUD : IRenderable
    {
        public const int InititalPlayerScore = 0;
        public const int CoordX = Game1.ScreenWidth / 2;
        public const int CoordY = 50;

        //Constructor
        public HUD()
        {
            this.PlayerScore = InititalPlayerScore;
            this.ShowHud = true;
            this.PlayerScoreFont = null;
            this.PlayerScorePosition = new Vector2(CoordX, CoordY);
        }
        
        public int PlayerScore { get; set; }

        public bool ShowHud { get; set; }

        public SpriteFont PlayerScoreFont { get; set; }

        public Vector2 PlayerScorePosition { get; private set; }

        //Load Content
        public void LoadContent(ContentManager Content)
        {
            this.PlayerScoreFont = Content.Load<SpriteFont>("georgia");
        }

        //Update
        public void Update(GameTime gameTime)
        {
            //Get KeyboardState
            KeyboardState keyState = Keyboard.GetState();
        }

        //Draw
        public void Draw(SpriteBatch spriteBatch)
        {
            //if we are shoвing our HUD (if showHUD==true) then display our HUD
            if (this.ShowHud)
            {
                spriteBatch.DrawString(this.PlayerScoreFont, string.Format("Score - {0}", this.PlayerScore), this.PlayerScorePosition, Color.Red);
            }
        }
    }
}