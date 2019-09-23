using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace AdventureGame
{
    class LevelTwo
    {
        public static void LevelTwoScenario() //issue with an extra key press after the level is completed and before it moves to LevelThree
        {
            Player.ChoicesRemaining = 2;

            Console.Clear(); // clears text from levelOne actions
            Console.Title = "Level Two - Lay the Trap";
            Console.WriteLine($"Congrats on being a sneaky sneek, {Player.CharacterName}.");
            Console.WriteLine();

            UserDecision1();
            while (!Player.LevelTwoCompleted && Player.ChoicesRemaining >= 0)
            {
                LevelTwoTrapOptions();
                if (Player.LevelFailed)
                {
                    Game.GameOver();
                    return;
                }
                var DialogueResponse = Console.ReadLine();
                UserResponse1(DialogueResponse);
            }
        }

        public static void UserDecision1()
        {
            Player.ValidResponse = false;

            Game.Dialog(
                "You have convinced everyone to leave the room, but they will be back shortly. You only have time to prepare two traps. Plan carefully or you may find yourself stuck in this meeting.", "white");
            Console.WriteLine();
        }

        public static void LevelTwoTrapOptions()
        {
            if (Player.ChoicesRemaining == 0)
            {
                if (Player.EdTrap && Player.FredTrap)
                {
                    Game.Dialog("You win!", "green");
                    Player.LevelTwoCompleted = true;
                    Game.Dialog("Press any key to continue", "white");
                    Console.ReadKey();
                }
                else
                {
                    {
                        Game.Dialog("You ran out of time and were unable to effectively trap the meeting room. The meeting takes place without any major disruptions and you must endure your failures in silence and pretending you care.","yellow");
                        Player.LevelFailed = true;
                    }
                }
            }
            else
            {
                Game.Dialog("What do you do? ", "grey");
                Console.WriteLine();
                Game.Dialog("Do you:" +
                            "\n 1) Lay a trap for Ed" +
                            "\n 2) Lay a trap for Fred" +
                            "\n 3) Lay a trap for Karen, Karen and Karen", "yellow");
            }
        }
        public static void UserResponse1(string DialogueResponse)
        {
            switch (DialogueResponse)
            {
                case "1": //Ed
                    Player.ValidResponse = true;
                    Player.EdTrap = true;
                    Player.ChoicesRemaining--;

                    Game.Dialog(
                        "", "green"); // add dialogue here
                    Game.Dialog("You have successfully laid a trap for Ed' \"\"", "red");
                    break;

                case "2": //Fred
                    Player.ValidResponse = true;
                    Player.FredTrap = true;
                    Player.ChoicesRemaining--;

                    Game.Dialog("", "green"); // add dialogue here
                    Game.Dialog("You have successfully laid a trap for Fred", "red");
                    break;

                case "3": //Karen
                    Player.ValidResponse = true;
                    Player.ChoicesRemaining--;
                    Game.Dialog("", "green"); // add dialogue here
                    break;

                default:
                    Console.WriteLine("INVALID RESPONSE, PLEASE SELECT A VALID OPTION");
                    break;
            }
        }
    }
}
