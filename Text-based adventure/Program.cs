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


        static void Main(string[] args)
        {
            GameLogic gameLogic = new GameLogic();
            UI ui = new UI();


            ui.PrintTextLetterByLetter("Guide: Hello  i will be your guide in this adventure.\nGuide: I don't have name yet so first i want you to think of a name for me.\n", 20);
            Console.Write("Enter name for guide here: ");

            int attempts = 0;

            string guide = Console.ReadLine();
            Console.Clear();

            int guideSpaces = guide.Count(char.IsLetter);
            string spaces = new string(' ', guideSpaces);

            PrintTextLetterByLetter($"\n{guide}: What a great name! from now on i will be {guide}.", 20);
            PrintTextLetterByLetter($"{guide}: Now i just need to know your name before we start with this adventure.\n", 20);

            Console.Write("Enter your name here: ");

            string playerName = Console.ReadLine();
            Console.Clear();

            PrintTextLetterByLetter($"\n{guide}: Now that we know each other, it's time to embark on your first quest, {playerName}.," +$"\n{spaces}  Your mission is to find the hidden map that leads to the location of the Holy Grail.\n ", 20);
            PressEnterToContinue();
            PrintTextLetterByLetter($"{guide}: Someone is going to try to steal the holy grail too,\n{spaces}  now you need to steal it before it gets stolen!", 20);
            PressEnterToContinue();

            PrintTextLetterByLetter($"{guide}: You've reached a fork in the road. One path leads through a dark and mysterious forest, \n{spaces}  while the other leads to an ancient temple." +$"\n{guide}: Which path will you choose?  \n", 20);
 

            Console.Write("\nEnter your choice here (Type 'forest' or 'temple'): ");
            

            string chosenPath = Console.ReadLine();
            Console.Clear();

            if (chosenPath == "forest")
            {
                HandleForestScenario();
            }
            else if (chosenPath == "temple")
            {
                HandleTempleScenario();
            }

            void HandleForestScenario()
            {
                PrintTextLetterByLetter($"{guide}: You've chosen the forest, {playerName}." +$"\n{guide}: The forest is dense and filled with secrets. " +$"\n{guide}: But beware, a mystical guardian awaits.\n" , 20);
                PressEnterToContinue();
                PrintTextLetterByLetter($"\nGuardian: I shall permit passage if you answer my riddle." +$"\nGuardian: I speak without a mouth and hear without ears. " +$"I have no body, but I come alive with wind. What am I?\n", 20);

                while (attempts < 3)
                {
                    Console.Write("Your answer: ");
                    string playerAnswer = Console.ReadLine().ToLower();

                    if (playerAnswer == "echo")
                    {
                        PrintTextLetterByLetter("\nGuardian: Correct! You may proceed.\n", 20);
                        PressEnterToContinue();

                    }
                    else
                    {
                        attempts++;

                        if (attempts == 1)
                        {
                            PrintTextLetterByLetter("\nGuardian: I'm sorry, that's not the correct answer.\nGuardian: Here's a hint: It's related to sound.\n", 20);
                        }
                        else if (attempts == 2)
                        {
                            PrintTextLetterByLetter("\nGuardian: Still not quite there.\nGuardian: Here's another hint: Think about what repeats itself\n.", 20);
                        }
                        else
                        {
                            PrintTextLetterByLetter("Guardian: I see you're having difficulty.\nGuardian: The guardian becomes hostile and blocks your path.\nGuardian: You must find an alternative route.", 20);
                            PrintTextLetterByLetter($"{guide}: I guess we will have to try the temple route then", 20);
                            PressEnterToContinue();
                            HandleTempleScenario();
                            return;
                        }
                    }
                }
                
            }

            void HandleTempleScenario()
            {
                Console.WriteLine("hey temple");
            }


        }
    }
}
