namespace GameProject.Interfaces
{
    using Microsoft.Xna.Framework.Input;

    public interface IControllable
    {
        void ControlMovement(KeyboardState keyState);
    }
}