namespace GameProject.Interfaces
{
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    public interface IEnemy : IRenderable, IDestructable, IMovableObject, ICollidable, IShooting
    {
        int EnemyPoints { get; }
        int EnemyShipDamage { get; }

        void Update(GameTime gameTime);
    }
}
