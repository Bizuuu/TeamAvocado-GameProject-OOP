namespace GameProject.Interfaces
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public interface IMovableObject
    {
        Texture2D Texture { get; }

        Vector2 Position { get; }

        int Speed { get; }
    }
}