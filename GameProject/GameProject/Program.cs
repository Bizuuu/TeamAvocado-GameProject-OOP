namespace GameProject
{
    using System;

    #if WINDOWS || XBOX
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        private static void Main(string[] args)
        {
            using (GameEngine game = new GameEngine())
            {
                game.Run();
            }
        }
    }
    #endif
}