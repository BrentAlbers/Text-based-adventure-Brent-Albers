using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Text_based_adventure
{
    class Program
    {
        static void PrintTextLetterByLetter(string text, int delayMilliseconds)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(delayMilliseconds);
            }

            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            PrintTextLetterByLetter("Guide: Hello  i will be your guide in this adventure.\nGuide: I don't have name yet so first i want you to think of a name for me.\n", 20);
            Console.Write("Enter name for guide here: ");

            string Guide = Console.ReadLine();

            PrintTextLetterByLetter($"{Guide}: What a great name! from now on i will be {Guide}.", 20);
            PrintTextLetterByLetter($"{Guide}: Now i just need to know your name before we start with this adventure.\n", 20);

            Console.Write("Enter your name here: ");

            string Player = Console.ReadLine();

            PrintTextLetterByLetter($"\n{Guide}: Hello {Player}", 20);


        }
    }
}
