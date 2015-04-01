namespace GameProject.Interfaces
{
    using Microsoft.Xna.Framework;

    public interface IEnemy : IRenderable, IDestructable, IMovableObject, ICollidable, IShooting
    {
        int EnemyPoints { get; }

        int EnemyShipDamage { get; }

        void Update(GameTime gameTime);
    }
}