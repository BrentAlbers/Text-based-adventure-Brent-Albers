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
            
            string guide = Console.ReadLine();
            Console.Clear();

            int guideSpaces = guide.Count(char.IsLetter);
            string spaces = new string(' ', guideSpaces);

            PrintTextLetterByLetter($"\n{guide}: What a great name! from now on i will be {guide}.", 20);
            PrintTextLetterByLetter($"{guide}: Now i just need to know your name before we start with this adventure.\n", 20);

            Console.Write("Enter your name here: ");

            string playerName = Console.ReadLine();
            Console.Clear();

            PrintTextLetterByLetter($"\n{guide}: Now that we know each other, it's time to embark on your first quest, {playerName}.,\n{spaces}  Your mission is to find the hidden map that leads to the location of the Holy Grail.\n ", 20);
            PrintTextLetterByLetter($"{guide}: Someone is going to try to steal the holy grail too,\n{spaces}  now you need to steal it before it gets stolen", 20);


        }
    }
}
