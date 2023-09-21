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


        public static void Main(string[] args)
        {
            UI ui = new UI();
            ForestScenario forestScenario = new ForestScenario();
            TempleScenario templeScenario = new TempleScenario();

            Console.WindowWidth = 80;
            Console.WindowHeight = 25;

            bool isGameOver = false;

            while (!isGameOver)
            {
                // Display the help/instructions.


                // Handle user input and game events.
                // Update isGameOver when the game ends.

                // Check for 'H' key to display instructions.
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(intercept: true).Key;
                    if (key == ConsoleKey.H)
                    {
                        ui.DisplayInstructions();
                    }
                }

                Console.Clear();
                Console.WriteLine("Welcome to My Game!");
                Console.WriteLine("Press Enter to Start...");

                while (Console.ReadKey(true).Key != ConsoleKey.Enter)
                {
                }
                Console.Clear();

                ui.PrintTextLetterByLetter("Guide: Hello, I will be your guide in this adventure.\nGuide: I don't have a name yet, so first, I want you to think of a name for me.\n", 20);
                Console.Write("Enter a name for your guide here: ");
                string guide = Console.ReadLine();
                Console.Clear();

                int guideSpaces = guide.Count(char.IsLetter);
                string spaces = new string(' ', guideSpaces);

                ui.PrintTextLetterByLetter($"\n{guide}: What a great name! From now on, I will be {guide}.\n{guide}: Now, I just need to know your name before we start with this adventure.\n", 20);
                Console.Write("Enter your name here: ");
                string playerName = Console.ReadLine();
                Console.Clear();

                ui.PrintTextLetterByLetter($"\n{guide}: Now that we know each other, it's time to embark on your first quest, {playerName}. Your mission is to find the hidden map that leads to the location of the Holy Grail.", 20);
                ui.PressEnterToContinue();
                ui.PrintTextLetterByLetter($"{guide}: Someone is going to try to steal the Holy Grail too. Now you need to steal it before it gets stolen!", 20);
                ui.PressEnterToContinue();

                ui.PrintTextLetterByLetter($"{guide}: You've reached a fork in the road. One path leads through a dark and mysterious forest, while the other leads to an ancient temple.\n{guide}: Which path will you choose?", 20);
                Console.Write("\nEnter your choice here (Type 'forest' or 'temple'): ");

                string chosenPath = Console.ReadLine();
                Console.Clear();

                if (chosenPath.Equals("forest", StringComparison.OrdinalIgnoreCase))
                {
                    forestScenario.HandleForestScenario(guide, playerName, false);
                    // Add game over condition and set isGameOver accordingly.
                }
                else if (chosenPath.Equals("temple", StringComparison.OrdinalIgnoreCase))
                {
                    templeScenario.HandleTempleScenario(guide, playerName, false);
                    // Add game over condition and set isGameOver accordingly.
                }

                // Check for game over condition and set isGameOver accordingly.
            }
        }


    }

}
 
