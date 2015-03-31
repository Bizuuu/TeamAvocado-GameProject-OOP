
namespace GameProject.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    public interface IProjectile : IMovableObject, ICollidable, IDestructable
    {
        int Damage { get; } // will determine how much damage a certain projectile afflicts;
    }
}
