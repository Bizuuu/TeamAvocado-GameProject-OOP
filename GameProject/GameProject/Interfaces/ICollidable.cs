namespace GameProject.Interfaces
{
    using Microsoft.Xna.Framework;

    public interface ICollidable
    {
        Rectangle BoundingBox { get; }
    }
}