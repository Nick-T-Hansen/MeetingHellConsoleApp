using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureGame
{
    class LevelThree
    {
        public static void LevelThreeScenario()
        {

            Console.Clear(); // clears text from levelOne actions
            Console.Title = "Level Three - John Wick the Room";
            Console.WriteLine($"Well done, {Player.CharacterName}. You are proving to be a terrible coworker.");
            Console.WriteLine();
            UserDecision1(); //need to write scenario text for the level
            while (Player.LevelThreeCompleted == false)
            {
                LevelThreeActionOptions();
                if (Player.LevelFailed)
                {
                    Game.GameOver();
                    return;
                }
                var DialogueResponse = Console.ReadLine();
                UserResponse1(DialogueResponse);
            }
            Game.Dialog("Press any key to continue", "white");
            Console.ReadKey();
        }

        public static void UserDecision1()
        {

        }

        public static void UserResponse1(string DialogueResponse)
        {

        }

        public static void LevelThreeActionOptions()
        {

        }
    
    }
}
