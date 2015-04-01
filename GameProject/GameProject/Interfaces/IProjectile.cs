namespace GameProject.Interfaces
{
    public interface IProjectile : IMovableObject, ICollidable, IDestructable
    {
        int Damage { get; }// will determine how much damage a certain projectile afflicts;
    }
}