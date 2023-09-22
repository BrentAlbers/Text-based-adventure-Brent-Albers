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

        }
        public void CheckForHelpInput()
        {
            string playerInput = Console.ReadLine();
            if (playerInput == "H")
            {
                Console.Write("These are the instructions");
            }
        }

    }
}
