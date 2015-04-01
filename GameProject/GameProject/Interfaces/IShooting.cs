namespace GameProject.Interfaces
{
    using System.Collections.Generic;

    public interface IShooting
    {
        int Health { get; set; }

        int BulletDelay { get; }

        IList<IProjectile> BulletList { get; }

        void Shoot();

        void UpdateProjectiles();
    }
}