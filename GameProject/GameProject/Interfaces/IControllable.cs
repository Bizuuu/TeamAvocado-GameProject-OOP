namespace GameProject.Interfaces
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    public interface IControllable
    {
        void ControlMovement(KeyboardState keyState);
    }
}
