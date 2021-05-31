using System;

namespace FirstGameProject
{
    class Program
    {
        static void Main( string[] args )
        {
            using (var game = new Game1() ) {
                game.Run();
            }
        }
    }
}
