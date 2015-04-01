namespace GameProject.Models
{
    using GameProject.Interfaces;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class BonusHealth : BonusObject, IMovableObject, ICollidable, IDestructable
    {
        private const int HealthBoost = 50;
        private const int HealthBonusSpeed = 3;

        public BonusHealth(Texture2D texture, Vector2 position) : base(texture, position, HealthBonusSpeed)
        {
        }

        public override void DistributeBonusEffect(Player p)
        {
            if (p.Health < Player.InitialPlayerHealth)
            {
                p.Health += HealthBoost;
            }
        }
    }
}