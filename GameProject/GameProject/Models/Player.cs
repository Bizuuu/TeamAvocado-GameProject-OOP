namespace GameProject.Models
{
    using GameProject.Interfaces;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    public class Player : Ship, IShooting, IMovableObject, ICollidable, IControllable, IRenderable
    {
        public static readonly Vector2 HealthBarPosition = new Vector2(50, 50);

        public const int InitialPlayerHealth = 300;
        public const int InitialAttackPower = 1;
        private const float ShipHeight = 50; // Height of the ship texture in pixels. Will change if ship pic is changed.
        private const int PlayerSpeed = 10;
        private const int PlayerBulletDelay = 5;
        private const int PlayerBulletSpeed = 10;
        private const float InitialPlayerCoordX = Game1.ScreenWidth / 2;
        private const float InitialPlayerCoordY = Game1.ScreenHeight - ShipHeight;        

        //Constructor
        public Player() : base(null, new Vector2(InitialPlayerCoordX, InitialPlayerCoordY), PlayerSpeed, InitialPlayerHealth, PlayerBulletDelay)
        {
            this.AttackPower = InitialAttackPower;
            // set defense prop, eventually;
        }

        public Texture2D HealthTexture { get; private set; }

        public Texture2D PlayerBulletTexture { get; private set; }

        public Rectangle HealthRectangle { get; private set; }

        public int AttackPower { get; set; }

        // Could have Defense, for manipulating taken damage, if per say someone writes a BonusArmor;

        //Load Content
        public void LoadContent(ContentManager Content)
        {
            this.Texture = Content.Load<Texture2D>("ship");
            this.PlayerBulletTexture = Content.Load<Texture2D>("playerbullet");
            this.HealthTexture = Content.Load<Texture2D>("healthbar");
        }

        //Draw
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.Texture, this.Position, Color.White);

            spriteBatch.Draw(this.HealthTexture, this.HealthRectangle, Color.White);

            foreach (PlayerBullet bul in this.BulletList)
            {
                bul.Draw(spriteBatch); // Add Draw() to PlayerBullet;
            }
        }

        //Update
        public void Update(GameTime gameTime)
        {
            //Getting keybord State
            KeyboardState keyState = Keyboard.GetState();

            // Bounding box for player spaceship
            this.BoundingBox = new Rectangle((int)this.position.X, (int)this.position.Y,
                this.Texture.Width, this.Texture.Height);

            // Set rectangle for the health bar
            this.HealthRectangle = new Rectangle((int)HealthBarPosition.X, (int)HealthBarPosition.Y,
                this.Health, this.HealthTexture.Width);

            //Fire Bullets
            if (keyState.IsKeyDown(Keys.Space))
            {
                this.Shoot();
            }

            this.UpdateProjectiles();

            //Ship Controls
            this.ControlMovement(keyState);
        }

        // Shoot (set starting position of bullets)
        public override void Shoot()
        {
            // shoot only on bulletdelay reset
            if (this.BulletDelay >= 0)
            {
                this.BulletDelay--;
            }

            // if bullet delay is at 0, create new bullet
            if (this.BulletDelay <= 0)
            {
                // Event handling
                SoundCaller shotFired = new SoundCaller(SoundManager.Instance.PlayerShootSound);

                // Could add a BonusMissile class, and a bool variable IsBonusMissileActive - 
                // if yes - can create Missiles, which will be a new class, with a different texture
                // and different damage, inheriting the Projectile class;

                Vector2 newBulletPosition = new Vector2(this.Position.X + this.Texture.Width / 2 - this.PlayerBulletTexture.Width / 2,
                    this.position.Y + this.Texture.Height / 2); // maybe different values;
                PlayerBullet newBullet = new PlayerBullet(this.PlayerBulletTexture, newBulletPosition, PlayerBulletSpeed);
                 
                if (this.BulletList.Count < 20)
                {
                    this.AddBullet(newBullet);
                }
            }

            // reset delay
            if (this.BulletDelay == 0)
            {
                this.BulletDelay = PlayerBulletDelay;
            }
        }

        //Update Bullet Function
        public override void UpdateProjectiles()
        {
            //for each bullet in our bulletlist: update the movement and if the bullet hits the top of the screen remove it from the list
            foreach (Ammunition b in this.BulletList)
            {
                b.UpdateAmmoMovement();
            }

            //Iterate through bulletList and see if any of the bullets are not visible, if they arent then remove the bullet from our bullet List
            for (int i = 0; i < this.BulletList.Count; i++)
            {
                if (!this.BulletList[i].IsVisible)
                {
                    this.RemoveBulletAtPosition(i);
                    i--;
                }
            }
        }

        public void ControlMovement(KeyboardState keyState)
        {
            if (keyState.IsKeyDown(Keys.W))
            {
                this.position.Y = this.Position.Y - this.Speed;
            }

            if (keyState.IsKeyDown(Keys.A))
            {
                this.position.X = this.Position.X - this.Speed;
            }

            if (keyState.IsKeyDown(Keys.S))
            {
                this.position.Y = this.Position.Y + this.Speed;
            }

            if (keyState.IsKeyDown(Keys.D))
            {
                this.position.X = this.Position.X + this.Speed;
            }

            // Keep player ship in screen bounds
            if (this.Position.X <= 0)
            {
                this.position.X = 0;
            } 

            if (this.Position.X >= Game1.ScreenWidth - this.Texture.Width)
            {
                this.position.X = Game1.ScreenWidth - this.Texture.Width;
            }

            if (this.Position.Y <= 0)
            {
                this.position.Y = 0;
            }

            if (this.Position.Y >= Game1.ScreenHeight - this.Texture.Height)
            {
                this.position.Y = Game1.ScreenHeight - this.Texture.Height;
            }
        }

        public void ResetStartPosition()
        {
            this.position = new Vector2(InitialPlayerCoordX, InitialPlayerCoordY);
        }

        public void ResetBonusEffects()
        {
            this.AttackPower = InitialAttackPower;
            // this.DefensePower = InitialDefensePower; // Eventually;
        }
    }
}