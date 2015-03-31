namespace GameProject.Models
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using GameProject.Interfaces;

    public class BonusHealth : BonusObject, IMovableObject, ICollidable, IDestructable
    {
        private const int HealthBoost = 50;
        private const int HealthBonusSpeed = 3;

        public BonusHealth(Texture2D texture, Vector2 position)
            : base(texture, position, HealthBonusSpeed)
        {
        }

        public override void DistributeBonusEffect(Player p)
        {
            if (p.Health < 300)
            {
                p.Health += HealthBoost;
            }
        }
    }
}
