using System;

namespace RedXAffichage
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (Body game = new Body())
            {
                game.Run();
            }
        }
    }
#endif
}

