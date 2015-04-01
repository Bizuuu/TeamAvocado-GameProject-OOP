namespace GameProject.Interfaces
{
    public interface IDestructable
    {
        bool IsVisible { get; }

        void DestroyObject();
    }
}