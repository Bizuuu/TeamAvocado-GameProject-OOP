namespace GameProject.Models
{
    using GameProject.Interfaces;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class PowerEnemy : Enemy, IEnemy, IShooting, IMovableObject, ICollidable, IRenderable 
    {
        private const int powerEnemySpeed = 5;
        private const int initialPowerEnemyHealth = 5;
        private const int powerEnemyBulletDelay = 40;
        private const int powerEnemyBulletSpeed = 10;
        private const int powerEnemyPoints = 20;
        private const int powerEnemyShipDamage = 80;

        public PowerEnemy(Texture2D texture, Vector2 position, Texture2D EnemyBulletTexture)
            : base(texture, position, EnemyBulletTexture, powerEnemySpeed, initialPowerEnemyHealth, powerEnemyBulletDelay, powerEnemyBulletSpeed, powerEnemyPoints, powerEnemyShipDamage)
        {

        }
    }
}
