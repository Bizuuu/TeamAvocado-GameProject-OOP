namespace GameProject
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.Xna.Framework;
    //using Microsoft.Xna.Framework.Audio;
    using Microsoft.Xna.Framework.Content;
    //using Microsoft.Xna.Framework.GamerServices;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    //using Microsoft.Xna.Framework.Media;
    
    public class HUD
    {
        public int playerScore, screenWidth, screenHeight;
        public SpriteFont playerScoreFont;
        public Vector2 playerScorePos;
        public bool showHud;


        //Constructor
        public HUD ()
        {
            playerScore = 0;
            showHud = true;
            screenHeight = 950;
            screenWidth = 800;
            playerScoreFont = null;
            playerScorePos = new Vector2( screenWidth/ 2, 50);
        }
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
                spriteBatch.DrawString(playerScoreFont,"Score - "+playerScore,playerScorePos, Color.Red);
        }

    }
}
