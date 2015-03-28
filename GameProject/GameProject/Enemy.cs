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

            // The rest is for the next on the list :)
        }
    }
}
