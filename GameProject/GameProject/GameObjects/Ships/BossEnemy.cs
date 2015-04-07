namespace GameProject.GameObjects.Ships
{
    using GameProject.Interfaces;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class BossEnemy : Enemy, IEnemy, IShooting, IMovableObject, ICollidable, IRenderable 
    {
        private const int bossEnemySpeed = 5;
        private const int initialBossEnemyHealth = 20;
        private const int bossEnemyBulletDelay = 30;
        private const int bossEnemyBulletSpeed = 15;
        private const int bossEnemyPoints = 50;
        private const int bossEnemyShipDamage = 60;

        public BossEnemy(Texture2D texture, Vector2 position, Texture2D EnemyBulletTexture)
            : base(texture, position, EnemyBulletTexture, bossEnemySpeed, initialBossEnemyHealth, bossEnemyBulletDelay, bossEnemyBulletSpeed, bossEnemyPoints, bossEnemyShipDamage)
        {

        }
    }
}
