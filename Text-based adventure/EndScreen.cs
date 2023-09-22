using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Text_based_adventure
{
    class EndScreen
    {
        public void GameOver()
        {
            Console.WindowWidth = 80;
            Console.WindowHeight = 25;

            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("Game Over!");

            Thread.Sleep(1000);

            Console.Clear();

            for (int i = 1; i <= 25; i++)
            {
                Console.SetCursorPosition(Console.WindowWidth / 2 - 6, i);
                Console.Write("####################");
                Thread.Sleep(50);
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(Console.WindowWidth / 2 - 5, 13);
            Console.Write("You Lost!");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 17, 15);
            Console.Write("Press any key to exit...");

            Console.ReadKey();


            Console.ResetColor();
        }
        public void VictoryScreen()
        {
            Console.WindowWidth = 80;
            Console.WindowHeight = 25;

            Console.ForegroundColor = ConsoleColor.Green;

            Console.Clear();

            Console.WriteLine("Congratulations!");

            Thread.Sleep(1000);

            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(Console.WindowWidth / 2 - 5, 13);
            Console.Write("You Won!");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 17, 15);
            Console.Write("Press Enter to exit...");


            while (Console.ReadKey(true).Key != ConsoleKey.Enter)
            {

            }

            Console.ResetColor();
        }
    }
}
