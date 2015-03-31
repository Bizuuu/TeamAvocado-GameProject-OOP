
namespace GameProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using GameProject.Interfaces;

    public class BonusDamage : BonusObject, IMovableObject, ICollidable, IDestructable, IRenderable
    {
        private const int DamageBoost = 20;
        private const int DamageBonusSpeed = 2;

        public BonusDamage(Texture2D texture, Vector2 position)
            : base(texture, position, DamageBonusSpeed)
        {
        }

        public override void DistributeBonusEffect(Player p)
        {
            p.AttackPower *= DamageBoost;
        }
    }
}
