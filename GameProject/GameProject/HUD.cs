namespace GameProject
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    public class HUD
    {
        public int playerScore, screenWidth, screenHeight;
        public SpriteFont playerScoreFont;
        public Vector2 playerScorePos;
        public bool showHud;


        //Constructor
        public HUD()
        {
           this.PlayerScore = 0;
            this.showHud = true;
            this.screenHeight = 950;
            this.screenWidth = 800;
            this.playerScoreFont = null;
           this. playerScorePos = new Vector2(screenWidth / 2, 50);

        }

        public int PlayerScore { get; set; }
        
        public bool ShowHud { get; set; }
        
        public int ScreenHeight { get; set; }

        public int ScreenWidth { get; set; }

        public SpriteFont PlayerScoreFont { get; set; }

        public Vector2 PlayerScorePos { get; set; }

        //Load Content
        public void LoadContent(ContentManager Content)
        {
            playerScoreFont = Content.Load<SpriteFont>("georgia");
        }
        //Update
        public void Update(GameTime gameTime)
        {
            //Get KeyboardState
            KeyboardState keyState = Keyboard.GetState();
            // KeyboardState  = Keaboard.GetState();
        }

        //Draw
        public void Draw(SpriteBatch spriteBatch)
        {
            //if we are shoing our HUD (if showHUD==true) then display our HUD
            if (showHud)
                spriteBatch.DrawString(playerScoreFont, "Score - " + playerScore, playerScorePos, Color.Red);
        }
    }
}
