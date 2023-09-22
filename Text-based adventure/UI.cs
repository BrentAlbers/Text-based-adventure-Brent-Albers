using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Text_based_adventure
{
    class UI
    {
        public void PrintTextLetterByLetter(string text, int delayMilliseconds)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(delayMilliseconds);
            }

            Console.WriteLine();
        }
        public void PressEnterToContinue()
        {
            Console.WriteLine("\nPress enter to continue, or 'H' for instructions");
            CheckForHelpInput();
            Console.ReadLine();
            Console.Clear();
            string objective = "Objective: Find the Holy Grail before it's stolen";
            Console.WriteLine("Objective: Find the Holy Grail before it's stolen");
        }
        public void CheckForHelpInput()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);
            if (keyInfo.Key == ConsoleKey.H)
            {
                Console.Clear();
                Console.WriteLine("Instructions:");
                Console.WriteLine("Type an answer when asked.");
                Console.WriteLine("The game will give clear directions on how to answer.");
                Console.WriteLine("If you are stuck, you can always enter 'H' for instructions.");
                Console.WriteLine("The game will let you know when it has ended and how you ended it.");
                Console.WriteLine("Press Enter to continue...");
                while (Console.ReadKey(true).Key != ConsoleKey.Enter) { }
                Console.Clear();
            }
            else
            {
                
            }
        }
    }

    }

