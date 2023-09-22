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
            EndScreen endScreen = new EndScreen();
            ForestScenario forestScenario = new ForestScenario();
            TempleScenario templeScenario = new TempleScenario();

            Console.WindowWidth = 80;
            Console.WindowHeight = 25;

            Console.WriteLine("Welcome to My Game!");
            Console.WriteLine("Press Enter to Start... Or press H for instructions");
            ui.CheckForHelpInput();


            Console.Clear();

            ui.PrintTextLetterByLetter("Guide: Hello  i will be your guide in this adventure.\nGuide: I don't have name yet so first i want you to think of a name for me.\n", 20);
            Console.Write("Enter name for guide here , or 'H' for instructions: ");
            ui.CheckForHelpInput();

            string guide = Console.ReadLine();
            Console.Clear();

            int guideSpaces = guide.Count(char.IsLetter);
            string spaces = new string(' ', guideSpaces);

            ui.PrintTextLetterByLetter($"\n{guide}: What a great name! from now on i will be {guide}.\n{guide}: Now i just need to know your name before we start with this adventure.\n", 20);
            Console.Write("Enter your name here , or 'H' for instructions: ");
            ui.CheckForHelpInput();

            string playerName = Console.ReadLine();
            Console.Clear();

            ui.PrintTextLetterByLetter($"\n{guide}: Now that we know each other, it's time to embark on your first quest, {playerName}.," +$"\n{spaces}  Your mission is to find the hidden map that leads to the location of the Holy Grail.\n ", 20);
            ui.PressEnterToContinue();
            ui.PrintTextLetterByLetter($"{guide}: Someone is going to try to steal the holy grail too,\n{spaces}  now you need to steal it before it gets stolen!", 20);
            ui.PressEnterToContinue();

            ui.PrintTextLetterByLetter($"{guide}: You've reached a fork in the road. One path leads through a dark and mysterious forest, \n{spaces}  while the other leads to an ancient temple." +$"\n{guide}: Which path will you choose?  \n", 20);
            Console.Write("\nEnter your choice here (Type 'forest' or 'temple'), or 'H' for instructions: ");
            ui.CheckForHelpInput();

            string chosenPath = Console.ReadLine()?.ToLower();
            Console.Clear();

            if (chosenPath == "forest")
            {
                forestScenario.HandleForestScenario(guide, playerName, false);
                ui.PressEnterToContinue();
            }
            else if (chosenPath == "temple")
            {
                templeScenario.HandleTempleScenario(guide, playerName, false);
                ui.PressEnterToContinue();
            }
            else
            {
                ui.PrintTextLetterByLetter($"{guide}: I'm afraid finding that's not a choice", 20);
                ui.PressEnterToContinue();
                endScreen.GameOver();
            }
        }
    }

}
 
