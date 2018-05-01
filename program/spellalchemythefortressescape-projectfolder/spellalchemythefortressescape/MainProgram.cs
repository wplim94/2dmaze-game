using System;

namespace SpellAlchemyTheFortressEscape
{
#if WINDOWS || XBOX

   
    static class MainProgram
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (SpellAlchemyTheFortressEscapeGame GameInstance = new SpellAlchemyTheFortressEscapeGame())
            {
                GameInstance.Run();
            }
        }
    }
#endif
}

