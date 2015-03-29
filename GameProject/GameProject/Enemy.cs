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
            isVisible = false;
        }

        // Update
        public void Update(GameTime gameTime)
        {
            // Update Collision Rectangle
            boundingBox = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);

            // Update Enemy Movement
            position.Y += speed;

            // The rest is for the next on the list :)		49	            // Move Enemy back to top of the screen if he flies off bottom
            if (position.Y >= 950)
            {
                position.Y = -75;
            }

            EnemyShoot();
            UpdateBullets();
        }

        // Draw
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
            foreach (Bullet b in bulletList)
            {
                // bounding box for every bullet in the bulletList;
                b.boundingBox = new Rectangle((int)b.position.X, (int)b.position.Y,
                    b.texture.Width, b.texture.Height);

                // set movement for bullet
                b.position.Y = b.position.Y + b.speed;

                // if bullet hits the top od the screen - make visible false -
                if (b.position.Y >= 950)
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

        // Enemy shoot function
        public void EnemyShoot()
        {
            // Shoot only if bulletdelay resets
            if (bulletDelay >= 0)
            {
                bulletDelay--;
            }

            if (bulletDelay <= 0)
            {
                // Create new bullet and position it front and center of enemy ship
                Bullet newBullet = new Bullet(bulletTexture);
                newBullet.position = new Vector2(position.X + texture.Width / 2 - newBullet.texture.Width / 2, position.Y + 30);

                newBullet.isVisible = true;

                if (bulletList.Count < 20)
                {
                    bulletList.Add(newBullet);
                }
            }

            // Reset bullet delay
            if (bulletDelay == 0)
            {
                bulletDelay = 40;
            }
        }

    }
}
