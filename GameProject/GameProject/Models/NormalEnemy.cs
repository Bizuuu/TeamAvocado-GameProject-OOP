namespace GameProject.Models
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    public class NormalEnemy : Enemy
    {
        private const int NormalEnemySpeed = 5;
        private const int InitialNormalEnemyHealth = 5;
        private const int NormalEnemyBulletDelay = 40;
        private const int NormalEnemyBulletSpeed = 10;
        private const int NormalEnemyPoints = 20; // Points awarded when destroyed;
        private const int NormalEnemyShipDamage = 40;// Health lost by player if he collides with enemy ship;

        // The same way we can make different enemies - with different textures, bullets, damage, etc.
        public NormalEnemy(Texture2D texture, Vector2 position, Texture2D normalEnemyBulletTexture)
            : base(texture, position, NormalEnemySpeed, InitialNormalEnemyHealth, NormalEnemyBulletDelay)
        {
            this.NormalEnemyBulletTexture = normalEnemyBulletTexture;
            this.EnemyPoints = NormalEnemyPoints;
            this.EnemyShipDamage = NormalEnemyShipDamage;
        }

        public Texture2D NormalEnemyBulletTexture { get; private set; }

        // Update
        public override void Update(GameTime gameTime)
        {
            // Update Collision Rectangle
            this.BoundingBox = new Rectangle((int)position.X, (int)position.Y, this.Texture.Width, this.Texture.Height);

            // Update Enemy Movement
            this.position.Y += this.Speed;

            // Move Enemy back to top of the screen if he flies off bottom
            if (this.Position.Y >= Game1.ScreenHeight)
            {
                this.position.Y = 0;
            }

            this.Shoot();
            this.UpdateProjectiles();
        }

        public override void Shoot()
        {
            // Shoot only if bulletdelay resets
            if (this.BulletDelay >= 0)
            {
                this.BulletDelay--;
            }

            if (this.BulletDelay <= 0)
            {
                // Create new bullet and position it front and center of enemy ship
                Vector2 newBulletPosition = new Vector2(this.Position.X + this.Texture.Width / 2 - NormalEnemyBulletTexture.Width / 2,
                                                this.position.Y + this.Texture.Height / 2); // maybe different values;                
                NormalEnemyBullet newBullet = new NormalEnemyBullet(NormalEnemyBulletTexture,
                    newBulletPosition, NormalEnemyBulletSpeed);

                if (this.BulletList.Count < 20)
                {
                    this.AddBullet(newBullet);
                }
            }

            // Reset bullet delay
            if (this.BulletDelay == 0)
            {
                this.BulletDelay = NormalEnemyBulletDelay;
            }
        }

        public override void UpdateProjectiles()
        {
            // For each bullet in the bullet list update movement, and if the bullet hits the top of the screen remove from list;
            foreach (Ammunition b in this.BulletList)
            {
                b.UpdateAmmoMovement();
            }

            // Iterate through the bulletList and if some bullet is not visible - remove it from list
            for (int i = 0; i < this.BulletList.Count; i++)
            {
                if (!this.BulletList[i].IsVisible)
                {
                    this.RemoveBulletAtPosition(i);
                    i--;
                }
            }
        }
    }
}
