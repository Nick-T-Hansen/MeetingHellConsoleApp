using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureGame
{
    class LevelThree
    {
        public static void LevelThreeScenario()
        {

            Console.Clear();
            Console.Title = "Level Three - John Wick the Room";
            Console.WriteLine($"Well done, {Player.CharacterName}. You are proving to be a terrible coworker.");
            Console.WriteLine();
            UserScenario();
            while (!Player.LevelThreeCompleted) 
            {
                LevelThreeActionOptions(); //choices the user has in the scenario.
                                           //certain things need to happen in order for the player to be successful
                if (Player.LevelFailed)// is the player doesn't do these things in the correct order, the player fails
                {
                    Game.GameOver();
                    return;
                }
                var OptionResponse = Console.ReadLine(); //read the player input from the actionOption
                UserAction(OptionResponse); //apply the user input to various outcomes.
                                                 //change variables based on outcomes and continue this block until the correct outcome is reached
            }
            Game.Dialog("Press any key to continue", "white");
            Console.ReadKey();
        }
        public static void UserScenario()
        {
            Game.Dialog("Preparations have been set. Your unsuspecting colleagues begin to wander back into the room. There are too many of them to take out at once. You will need to carefully decide how to quickly and effectively dispatch these individuals. You glance at your WWTWD bracelet (What Would John Wick Do) and immediately know how to proceed. Everyone sits down at the table and Fred's chair breaks, sending him on the floor. Fred is stuck like a turtle on its back.' ", "white");
        }

        public static void LevelThreeActionOptions() //dialogue options need to be removed as things are completed
        {
            Game.Dialog(".", "grey");
            Console.WriteLine();
            Game.Dialog("Who do you target:" +
                        "\n 1) Ed" +
                        "\n 2) Fred" +
                        "\n 3) Karen, Karen and Karen", "white");
            if (Player.EdDead || Player.KarenDead || Player.FredDead)
            {
                Game.Dialog("4) Say witty catch phrase when the Protagonist in movies is successful." , "white");
            }

        }
        public static void UserAction(string OptionResponse)
        //Fred falls out of chair, ed goes into shock from sandwich, karrens electricuted, fred choked with ed's tie (need to acquire tie for this to happen)
        {
            switch (OptionResponse)
            {
                case "1": //Ed
                    Player.ValidResponse = true;
                    Player.EdDead = true;
                    Player.CornflowerTie = true;

                    Game.Dialog(
                        "ed die story", "green"); // ed story
                    Game.Dialog(
                        "Ed has died. You notice his stupid cornflower tie. You think you can put it to good use.", "red"); //successfully removed ed game note
                    Game.Dialog(
                        "You have acquired \"Cornflower Tie\"", "red"); //successfully removed ed game note
                    break;

                case "2": //Fred
                    Player.ValidResponse = true;
                    if (!Player.EdDead || !Player.KarenDead)
                    {
                        Player.LevelFailed = true;
                        Game.Dialog("You need to kill the others first. You lose.", "red");

                    }
                    else
                    {
                    Player.EdDead = true;
                    Game.Dialog("fred die story", "green"); // fred story
                    Game.Dialog("", "red"); // ed removal game note

                    }
                    
                    break;

                case "3": //Karen
                    Player.ValidResponse = true;
                    if (!Player.EdDead)
                    {
                        Player.LevelFailed = true;
                        Game.Dialog(
                            "You grab your coffee cup and douse the Karen's in its under caffinated wonder. As you grab the projector and begin to toss it at the group of ladies, Ed unplugs it. He is furious at your activities and publicly reprimands you. You are sent to HR for sensitivity training.",
                            "green"); // karen story
                    }
                    else
                    {
                    Game.Dialog("You grab your cup of coffee and douse Karen, Karen and Karen in it's under caffinated usefulness.'. They are stunned at your actions. You grab the shitty projector off the table and toss it at the group of obnaxious humans. The projector electrocutes the group of ladies, rendering them silent and slightly charred.", "green");
                    Game.Dialog("", "red"); // karen removal game note
                    }
                    break;

                case "4": //Unlocked Responses
                    Player.ValidResponse = true;
                    if (Player.EdDead && Player.KarenDead && Player.FredTrap) // win parameters
                    {
                        Game.Dialog("insert witty catch phrase", "green"); // need catchphrase win dialogue
                        Player.LevelOneCompleted = true;
                    }
                    else if (Player.EdDead || Player.KarenDead || Player.FredDead) // doesn;t meet all the win parameters in the if statement
                    {
                        Player.LevelFailed = true;
                        Game.Dialog(
                            "you lose", "green");
                        Game.GameOver();

                    }
                    else //if a user types 4, it will not allow them to cheat and display the actions they have not completed
                    {
                        Console.WriteLine("INVALID RESPONSE, PLEASE SELECT A VALID OPTION");
                    }
                    break;

                default:
                    Console.WriteLine("INVALID RESPONSE, PLEASE SELECT A VALID OPTION");
                    break;
            }
        }
    }
}
