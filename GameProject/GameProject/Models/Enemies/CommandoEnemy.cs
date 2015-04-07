namespace GameProject.Models
{
    using GameProject.Interfaces;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class CommandoEnemy : Enemy, IEnemy, IShooting, IMovableObject, ICollidable, IRenderable 
    {
        private const int commandoEnemySpeed = 10;
        private const int initialCommandoEnemyHealth = 5;
        private const int commandoEnemyBulletDelay = 80;
        private const int commandoEnemyBulletSpeed = 30;
        private const int commandoEnemyPoints = 20;
        private const int commandoEnemyShipDamage = 40;

        public CommandoEnemy(Texture2D texture, Vector2 position, Texture2D EnemyBulletTexture)
            : base(texture, position, EnemyBulletTexture, commandoEnemySpeed, initialCommandoEnemyHealth, commandoEnemyBulletDelay, commandoEnemyBulletSpeed, commandoEnemyPoints, commandoEnemyShipDamage)
        {

        }
    }
}
