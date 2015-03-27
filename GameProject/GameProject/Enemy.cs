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
    public class Enemy
    {
        public Rectangle boundingBox;
        public Texture2D texture;
        public Texture2D bulletTexture;
        public Vector2 position;
        public int health;
        public int speed;
        public int bulletDelay;
        public int currentDifficultyLevel;// may not be necessary;
        public bool isVisible;
        public List<Bullet> bulletList;

        public Enemy(Texture2D newTexture, Vector2 newPosition, Texture2D newBulletTexture)
        {
            bulletList = new List<Bullet>();
            texture = newTexture;
            bulletTexture = newBulletTexture;
            health = 5; // this will be a variable, changing according to the level of difficulty, if there is such;
            position = newPosition;
            currentDifficultyLevel = 1;// later constants;
            bulletDelay = 40;// later a variable, changing according to the level;

            speed = 5;
            isVisible = true;
        }

        // Update
        public void Update(GameTime gameTime)
        {
            // Update Collision Rectangle
            boundingBox = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);

            // Update Enemy Movement
            position.Y += speed;

            // Move Enemy back to top of the screen if he flies off bottom
            if(position.Y >= 950)
            {
                position.Y = -75;
            }

        }
        
        public void Draw(SpriteBatch spriteBatch)
        {
            // Draw enemy ship
            spriteBatch.Draw(texture, position, Color.White);

            // Draw enemy bullets
            foreach (Bullet b in bulletList)
            {
                b.Draw(spriteBatch);
            }
        }

        public void UpdateBullets()
        {
            // For each bullet in the bullet list update movement, and if the bullet hits the top of the screen remove from list;
            foreach (var bullet in bulletList) // field List<Bullet> bulletList is to be implemented by someone else;
            {
                // bounding box for every bullet in the bulletList;
                bullet.boundingBox = new Rectangle((int)bullet.position.X, (int)bullet.position.Y,
                    bullet.texture.Width, bullet.texture.Height);

                // set movement for bullet - someone else will do it;
                b.position.Y = b.position.Y - b.speed;

                // if bullet hits the top od the screen - make visible false - 
                if (b.position.Y <= 0)
                {
                    b.isVisible = false;
                }
            }

            // Iterate through the bulletList and if some bullet is not visible - remove it from list
            for (int i = 0; i < bulletList.Count; i++)
            {
                if (!bulletList[i].isVisible)
                {
                    bulletList.RemoveAt(i);
                    i--;
                }
            }
        }
    }
}
