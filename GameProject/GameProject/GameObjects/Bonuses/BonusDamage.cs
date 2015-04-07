namespace GameProject.GameObjects.Bonuses
{
    using GameProject.GameObjects.Ships;
    using GameProject.Interfaces;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class BonusDamage : BonusObject, IMovableObject, ICollidable, IDestructable, IRenderable
    {
        private const int DamageBoost = 20;
        private const int DamageBonusSpeed = 2;

        public BonusDamage(Texture2D texture, Vector2 position) : base(texture, position, DamageBonusSpeed)
        {
        }

        public override void DistributeBonusEffect(Player p)
        {
            p.AttackPower *= DamageBoost;
            p.AttackBonusActive = true;
        }
    }
}