namespace GameProject
{
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    public class Player
    {
        public Texture2D texture, bulletTexture;
        public Vector2 position;
        public int speed;
        public float bulletDelay;
        //Collision variables
        public Rectangle boundingBox;
        public bool isColliding;
        public List<Bullet> bulletList;

        //Constructor
        public Player()
        {
            this.bulletList = new List<Bullet>();
            texture = null;
            position = new Vector2(300, 300);
            this.bulletDelay = 20;
            speed = 10;
            isColliding = false;
        }

        //Load Content
        public void LoadContent(ContentManager Content)
        {
            texture = Content.Load<Texture2D>("ship");
            bulletTexture = Content.Load<Texture2D>("playerbullet");
        }

        //Draw
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
            foreach (Bullet bul in this.bulletList)
            {
                bul.Draw(spriteBatch);
            }
        }

        //Update
        public void Update(GameTime gameTime)
        {
            //Getting keybord State
            KeyboardState keyState = Keyboard.GetState();

            //Ship Controls
            if (keyState.IsKeyDown(Keys.W))
            {
                position.Y = position.Y - speed;
            }
            if (keyState.IsKeyDown(Keys.A))
            {
                position.X = position.X - speed;
            }
            if (keyState.IsKeyDown(Keys.S))
            {
                position.Y = position.Y + speed;
            }
            if (keyState.IsKeyDown(Keys.D))
            {
                position.X = position.X + speed;
            }

            //Keep player ship in screen bounds
            if (position.X <= 0)
            {
                position.X = 0;
            }
            if (position.X >= 800 - texture.Width)
            {
                position.X = 800 - texture.Width;
            }
            if (position.Y <= 0)
            {
                position.Y = 0;
            }
            if (position.Y >= 950 - texture.Height)
            {
                position.Y = 950 - texture.Height;
            }
        }

        // Shoot (set starting position of bullets)
        public void Shoot()
        {
            // shoot only on bulletdelay reset
            if (this.bulletDelay >= 0)
            {
                this.bulletDelay--;
            }

            // if bullet delay is at 0, create new bullet
            if (bulletDelay <= 0)
            {
                Bullet newBullet = new Bullet(bulletTexture);
                newBullet.position = new Vector2(this.position.X + 32 - newBullet.texture.Width / 2, this.position.Y + 30);
                newBullet.isVisible = true;

                if (this.bulletList.Count < 20)
                {
                    this.bulletList.Add(newBullet);
                }
            }

            // reset delay
            if (this.bulletDelay == 0)
            {
                this.bulletDelay = 20;
            }
        }
    }
}
