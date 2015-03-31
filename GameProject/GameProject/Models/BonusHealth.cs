
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

    public class BonusHealth : BonusObject, IMovableObject, ICollidable, IDestructable
    {
        private const int HealthBoost = 50;
        private const int HealthBonusSpeed = 2;

        public BonusHealth(Texture2D texture, Vector2 position)
            : base(texture, position, HealthBonusSpeed)
        {
        }

        public override void DistributeBonusEffect(Player p)
        {
            p.Health += HealthBoost;
        }
    }
}
