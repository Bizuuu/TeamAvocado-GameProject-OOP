
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

    public interface IShooting
    {
        int Health { get; }
        int BulletDelay { get; }
        IList<IProjectile> BulletList { get; }

        void Shoot();
        void UpdateProjectiles();
    }
}
