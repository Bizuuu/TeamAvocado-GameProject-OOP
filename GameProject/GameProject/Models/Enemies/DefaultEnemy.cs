namespace GameProject.Models
{
    using GameProject.Interfaces;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class DefaultEnemy : Enemy, IEnemy, IShooting, IMovableObject, ICollidable, IRenderable 
    {
        private const int defaultEnemySpeed = 5;
        private const int initialDefaultEnemyHealth = 5;
        private const int defaultEnemyBulletDelay = 40;
        private const int defaultEnemyBulletSpeed = 10;
        private const int defaultEnemyPoints = 20;
        private const int defaultEnemyShipDamage = 40;

        public DefaultEnemy(Texture2D texture, Vector2 position, Texture2D EnemyBulletTexture)
            : base(texture,position,EnemyBulletTexture, defaultEnemySpeed, initialDefaultEnemyHealth, defaultEnemyBulletDelay, defaultEnemyBulletSpeed, defaultEnemyPoints, defaultEnemyShipDamage)
        {

        }
    }
}
