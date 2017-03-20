using System;
//JaJuan Webster
//Professor Cascioli
//Spaceship!
//ABOVE AND BEYOND: Background Music

namespace Webster_HW_Project1_Spaceship
{
#if WINDOWS || LINUX
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (var game = new Game1())
                game.Run();
        }
    }
#endif
}
