using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_based_adventure
{
    class TempleScenario 
    {
        public void HandleTempleScenario(string guide, string playerName, bool playedScenario)
        {
            UI ui = new UI();
            EndScreen endScreen = new EndScreen();
            int attempts = 0;
            ForestScenario templeScenario = new ForestScenario();

            if (playedScenario == true)
            {
                ui.PrintTextLetterByLetter($"{guide}: Maybe we will have more luck with this route, {playerName}." + $"\n{guide}: The forest is dense and filled with secrets. " + $"\n{guide}: But beware, a mystical guardian awaits.\n", 20);
            }
            else
            {
                ui.PrintTextLetterByLetter($"{guide}: You've chosen the temple, {playerName}." + $"\n{guide}: The forest is dense and filled with secrets. " + $"\n{guide}: But beware, a mystical guardian awaits.\n", 20);
            }
            ui.PressEnterToContinue();
            ui.PrintTextLetterByLetter($"\nGuardian: I shall permit passage if you answer my riddle." + $"\nGuardian: I am a creature of night, with feathers so black," + $"\nGuardian: Silent in flight, I hunt without track. Who am I, with eyes that gleam bright?\n", 20);

            while (attempts < 3)
            {
                Console.Write("Your answer: ");
                string playerAnswer = Console.ReadLine().ToLower();

                if (playerAnswer == "raven")
                {
                    ui.PrintTextLetterByLetter("\nGuardian: Correct! You may proceed.\n", 20);
                    ui.PressEnterToContinue();
                    HandleFinalTempleChallenge(guide, playerName);
                    
                }
                else
                {
                    attempts++;

                    if (attempts == 1)
                    {
                        ui.PrintTextLetterByLetter("\nGuardian: I'm sorry, that's not the correct answer.\nGuardian: Here's a hint: The answer is a bird of the night with bright eyes.\n", 20);
                    }
                    else if (attempts == 2)
                    {
                        if (playedScenario == true)
                        {
                            ui.PrintTextLetterByLetter($"Guardian: The guardian becomes hostile and blocks your path.\n", 20);
                            ui.PrintTextLetterByLetter($"{guide}: I'm afraid finding another route will be pointless now, we will never be at the holy grail before it is stolen", 20);
                            ui.PressEnterToContinue();
                            endScreen.GameOver();

                        }
                        ui.PrintTextLetterByLetter("\nGuardian: Still not quite there.\nGuardian: Here's another hint: It's known for its dark feathers and silent flight.\n", 20);
                    }
                    else
                    {
                        ui.PrintTextLetterByLetter($"Guardian: The guardian becomes hostile and blocks your path.\n\nYou must find an alternative route.", 20);
                        ui.PressEnterToContinue();
                        ui.PrintTextLetterByLetter($"{guide}: I guess we will have to try the temple route then", 20);
                        templeScenario.HandleForestScenario(guide, playerName, true);
                    }
                }
            }

        }
        public bool HandleFinalTempleChallenge(string guide, string playerName)
        {
            UI ui = new UI();
            Random random = new Random();
            EndScreen endScreen = new EndScreen();
            int playerRoll = random.Next(1, 7);
            int enemyRoll = random.Next(1, 1);

            ui.PrintTextLetterByLetter($"{guide}: You've reached the inner sanctum of the temple, {playerName}." + $"\n{guide}: Here lies the final challenge before the Holy Grail.\n", 20);
            ui.PressEnterToContinue();
            ui.PrintTextLetterByLetter($"\nGuardian: To prove your worth, you must defeat me in a dice duel." + $"\nGuardian: Roll the dice, and I shall do the same. The higher roll wins.\n", 20);
            ui.PressEnterToContinue();
            ui.PrintTextLetterByLetter($"You roll the dice... It's a {playerRoll}!", 20);
            ui.PrintTextLetterByLetter($"The guardian rolls the dice... It's a {enemyRoll}!", 20);

            if (playerRoll > enemyRoll)
            {
                ui.PrintTextLetterByLetter("\nGuardian: You've won the dice duel! The path to the Holy Grail is now revealed.\n", 20);
                ui.PressEnterToContinue();
                Console.Clear();
                ui.PrintTextLetterByLetter($"{guide}: Congratulations, {playerName}!" + $"\n{guide}: We've found the Holy Grail, the legendary artifact of immense power." + $"\n{guide}: With this, we can fulfill our mission and prevent it from falling into the wrong hands.\n", 20);
                ui.PressEnterToContinue();
                endScreen.VictoryScreen();
                return true; 
            }
            else if (playerRoll < enemyRoll)
            {
                ui.PrintTextLetterByLetter("\nGuardian: You've lost the dice duel. The path to the Holy Grail remains hidden forever.\n", 20);
                ui.PressEnterToContinue();
                endScreen.GameOver();
                return false; 
            }
            else
            {
                ui.PrintTextLetterByLetter("\nGuardian: It's a tie! A rare occurrence. We'll try again.\n", 20);
                ui.PressEnterToContinue();
                return HandleFinalTempleChallenge(guide, playerName); 
            }
        }
    }
}
