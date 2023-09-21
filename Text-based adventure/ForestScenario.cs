using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_based_adventure
{
    class ForestScenario
    {


        public void HandleForestScenario(string guide, string playerName, bool playedScenario)
        {
            UI ui = new UI();
            int attempts = 0;
            TempleScenario templeScenario = new TempleScenario();


            if (playedScenario == true)
            {
                ui.PrintTextLetterByLetter($"{guide}: Maybe we will have more luck with this route, {playerName}." + $"\n{guide}: The forest is dense and filled with secrets. " + $"\n{guide}: But beware, a mystical guardian awaits.\n", 20);
            }
            else
            {
                ui.PrintTextLetterByLetter($"{guide}: You've chosen the forest, {playerName}." + $"\n{guide}: The forest is dense and filled with secrets. " + $"\n{guide}: But beware, a mystical guardian awaits.\n", 20);

            }

            ui.PressEnterToContinue();
            ui.PrintTextLetterByLetter($"\nGuardian: I shall permit passage if you answer my riddle." + $"\nGuardian: I speak without a mouth and hear without ears. " + $"I have no body, but I come alive with wind. What am I?\n", 20);

            while (attempts < 3)
            {
                Console.Write("Your answer: ");
                string playerAnswer = Console.ReadLine().ToLower();

                if (playerAnswer == "echo")
                {
                    ui.PrintTextLetterByLetter("\nGuardian: Correct! You may proceed.\n", 20);
                    ui.PressEnterToContinue();
                }
                else
                {
                    attempts++;

                    if (attempts == 1)
                    {
                        ui.PrintTextLetterByLetter("\nGuardian: I'm sorry, that's not the correct answer.\nGuardian: Here's a hint: It's related to sound.\n", 20);
                    }
                    else if (attempts == 2)
                    {
                        ui.PrintTextLetterByLetter("\nGuardian: Still not quite there.\nGuardian: Here's another hint: Think about what repeats itself\n.", 20);
                        if (playedScenario == true)
                        {
                            ui.PrintTextLetterByLetter($"Guardian: The guardian becomes hostile and blocks your path.\n", 20);
                            ui.PrintTextLetterByLetter($"{guide}: I'm afraid finding another route will be pointless now, we will never be at the holy grail before it is stolen", 20);
                            ui.PressEnterToContinue();
                            ui.GameOver();
                        }
                    }
                    else
                    {
                        ui.PrintTextLetterByLetter($"Guardian: I see you're having difficulty.\n\n The guardian becomes hostile and blocks your path.\nYou must find an alternative route.\n{guide}: I guess we will have to try the temple route then", 20);
                        ui.PressEnterToContinue();
                        templeScenario.HandleTempleScenario(guide, playerName, true);
                    }
                }
            }

        }
        public bool HandleForestChallenge(string guide, string playerName)
        {
            UI ui = new UI();
            Random random = new Random();
            int playerRoll = random.Next(1, 7);
            int enemyRoll = random.Next(1, 7);

            ui.PrintTextLetterByLetter($"{guide}: You've reached a mysterious clearing in the dense forest, {playerName}." + $"\n{guide}: Here lies a forest guardian, challenging your luck.\n", 20);
            ui.PressEnterToContinue();
            ui.PrintTextLetterByLetter($"\nForest Guardian: To prove your worth, let's test your luck with a dice roll duel." + $"\nForest Guardian: Roll the dice, and I shall do the same. The higher roll wins.\n", 20);
            ui.PressEnterToContinue();
            ui.PrintTextLetterByLetter($"You roll the dice... It's a {playerRoll}!", 20);
            ui.PrintTextLetterByLetter($"The forest guardian rolls the dice... It's a {enemyRoll}!", 20);

            if (playerRoll > enemyRoll)
            {
                ui.PrintTextLetterByLetter("\nForest Guardian: You've won the dice duel! You may proceed deeper into the forest.\n", 20);
                ui.PressEnterToContinue();
                ui.PrintTextLetterByLetter($"{guide}: It seems we've taken the wrong path, {playerName}." + $"\n{guide}: The Holy Grail was never here. Our mission is in jeopardy.\n", 20);
                ui.PressEnterToContinue();
                ui.GameOver();
                return true; 
            }
            else if (playerRoll < enemyRoll)
            {
                ui.PrintTextLetterByLetter("\nForest Guardian: You've lost the dice duel. The forest remains an enigma.\n", 20);
                ui.PressEnterToContinue();
                ui.GameOver();
                return false;
            }
            else
            {
                ui.PrintTextLetterByLetter("\nForest Guardian: It's a tie! A rare occurrence. We'll try again.\n", 20);
                ui.PressEnterToContinue();
                return HandleForestChallenge(guide, playerName);
            }
        }
    }
}
