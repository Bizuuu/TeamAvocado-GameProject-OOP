using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameProject
{
    public class Player
    {
        // fileds to add;
        public Texture2D healthTexture;
        public int health;
        public Rectangle healthRectangle;
        public Vector2 healthBarPosition;
        public Rectangle boundingBox;
        // fields to add;

        // Constructor
        public Player()
        {
            health = 200;// Later we'll put a constatnt in the class and use it;
            healthBarPosition = new Vector2(50, 50); // Remove the magic numbers later - make the field readonly or something;
        }

        // Load content
        public void LoadContent(ContentManager content)
        {
            // other things to load - for someone else to do;

            healthTexture = content.Load<Texture2D>("Textures/healthbar");
        }

        // Draw
        public void Draw(SpriteBatch spriteBatch)
        {
            // draw the player texture - for someone else to do;

            spriteBatch.Draw(healthTexture, healthRectangle, Color.White);

            // draw bullets - for someone else; 
        }

        public void Update(GameTime gameTime)
        {
            // Getting keyboard state - for someone else to do;

            // Bounding box for player spaceship
            boundingBox = new Rectangle((int)this.position.X, (int)this.position.Y,
              this.texture.Width, this.texture.Height); // position and texture will be implemented by someone else;

            // Set rectangle for the health bar
            healthRectangle = new Rectangle((int)healthBarPosition.X, (int)healthBarPosition.Y,
                                                                  health, healthTexture.Height);
        }

        // Update bullet method;
        public void UpdateBullets()
        {
            // For each bullet in the bullet list update movement, and if the bullet hits the top of the screen remove from list;
            foreach (var bullet in bulletList) // field List<Bullet> bulletList is to be implemented by someone else;
            {
                // bounding box for every bullet in the bulletList;
                bullet.boundingBox = new Rectangle((int)bullet.position.X, (int)bullet.position.Y,
                    bullet.texture.Width, bullet.texture.Height);

                // set movement for bullet - someone else will do it;

                // if bullet hits the top od the screen - make visible false - for someone else to do;
            }

            // Iterate through the bulletList and if some bullet is not visible - remove it from list; - dor someone else to do;
        }


    }
}
