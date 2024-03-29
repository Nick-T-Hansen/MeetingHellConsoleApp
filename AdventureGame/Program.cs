﻿
/*
 * Karens die by dumping coffee on them and electrocuting them with the projector
 * Ed dies through peanut butter allergy
 * strangle guy with eds tie
 */

using System;
using System.ComponentModel.Design;
using System.Reflection.Metadata.Ecma335;

namespace AdventureGame
{
    class Program
    {
        static void Main()
        {
            Game.StartGame();
            Game.NameCharacter();
            Game.Dialog($"Welcome to the club, {Player.CharacterName}. To begin your adventure, click any key.",
                "yellow");
            Game.LevelOneScenario();

            
            
            Console.Read(); //keep app open
        }
    }

    class Game
    {

        //print out game title and overview
        public static void StartGame()
        {
            Console.Title = "Adventure Game of Awesome";
            Console.WriteLine("Adventure Game!");
        }

        //ask player for a name, and save it
        public static void NameCharacter()
        {
            Console.WriteLine("Please tell me your Adventurer's name.");
            Player.CharacterName = Console.ReadLine();
            Player.LevelOneCompleted = false; //initialize
            Player.LevelFailed = false; //initializes
        }

        //write line options which include color choices
        public static void Dialog(string message, string color)
        {
            if (color == "red") // actions impacting a change in the game rules
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else if (color == "green") // action response
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else if (color == "yellow") // action prompt
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else if (color == "white") // scenario text
            {
                Console.ForegroundColor = ConsoleColor.White;
            }

            Console.WriteLine(message);
            Console.ResetColor();
        }

        public static void LevelOneScenario()
        {
            Console.Clear();
            Console.Title = "Level One - Scope Out The Meeting";
            Console.WriteLine($"Welcome to the Officedome, {Player.CharacterName}.");
            Console.WriteLine();
            Dialog(
                $"You find yourself at your desk. It is just another day in the life of {Player.CharacterName}. " +
                $"Living the life in a mid level white collar job " +
                $"You look at your watch and realize it is two minutes from your daily team meeting. " +
                $"Fuck. You grab your cup with a room temperature flavorless liquid the office calls \"coffee\" and slowly begin to walk toward the meeting room, " +
                $"dreading the next 90 minutes of the gaggle of Karens complaining about their mornings, " +
                $"Fred and his tuna fish and peanut butter sandwich stinking up the room, and seeing Ed. " +
                $"Asshat Ed and his bullshit managerial seminar motivation. " +
                $"You would have jumped out of the meeting room on Tuesday if it wasn't locked." +
                $"You pass a stupid poster of a cat on a tree limb that says \"Hang In There!\" and decide it is time to reclaim your time. And to do that, it's time to fuck shit up.",
                "white"
            );
            Dialog("You have acquired \"Coffee Cup\"", "red");
            Player.CoffeeCup = true;

            Console.WriteLine(""); // create whitespace
            UserDecision1();
            while (Player.ValidResponse == false)
            {
                var DialogResponse = Console.ReadLine();
                UserResponse1(DialogResponse);
            }

            Dialog(
                "The rest of the team waddles in. You hate how they waddle. Waddling is for penguins. Karen A., Karen F., and Karen T. sit in three seats across from you. They have matching \"Live, Love, Laugh\" cardigans on. The gaggle of Karens are the worst. ",
                "white");
            Console.WriteLine();
            Dialog(
                "Fred sit next to you with his fish and peanut butter sandwich and Ed sits at the head of the table with his cornflower blue tie. You hate that tie.",
                "white");

            Console.WriteLine(""); // create whitespace
            UserDecision2();
            while (Player.LevelOneCompleted == false)
            {
                ConversationOptions();
                var DialogResponse = Console.ReadLine();
                UserResponse2(DialogResponse);
                if (Player.LevelFailed)
                {
                    Game.GameOver();
                    return; 
                }
            }

            Dialog("loop", "red"); //remove test code
        }

        public static void UserDecision1()
        {
            Dialog("You walk into the conference room, it is empty.", "grey");
            Console.WriteLine();
            Dialog("Do you:" +
                   "\n 1) Walk to the window" +
                   "\n 2) Take a seat at the conference table\n", "yellow");
        }

        public static void UserResponse1(string DialogueResponse)
        {
            switch (DialogueResponse)
            {
                case "1":
                    Player.ValidResponse = true;
                    Dialog(
                        "You check the window to see if it is still locked. Damn. No escape. You take a seat at the table and ponder your next move.",
                        "green");
                    break;
                case "2":
                    Player.ValidResponse = true;
                    Dialog(
                        "You head straight to the conference table and sit facing the door to establish dominance in hopes to intimidate your prey.",
                        "green");
                    break;
                default:
                {
                    Console.WriteLine("INVALID RESPONSE, PLEASE SELECT A VALID OPTION");
                    UserDecision1();
                    break;
                }
            }
        }

        public static void UserDecision2()
        {
            Player.ValidResponse = false;

            Dialog(
                "Everyone is settling in for 90 minutes of wonderful and crucial organizational updates. You decide to take control before Ed can say the word memo.",
                "white");
            Console.WriteLine();
        }

        public static void UserResponse2(string DialogueResponse)
        {

            switch (DialogueResponse)
            {
                case "1":
                    Player.ValidResponse = true;
                    Player.Projector = true;

                    Dialog(
                        "You muster all of your online poker bluffing skills and put on a really creepy happy face and ask Ed if there is time to do the presentation" +
                        "\non TPS Reports. Ed responds positively as he can tell his boss he actually did something today. Ed asks you to grab the projector and set it up on " +
                        "\nthe table while he gathers his notes on the riveting TPS Report presentation.", "green");
                    Dialog("You have acquired \"Piece of shit projector", "red");
                    break;
                case "2":
                    Player.ValidResponse = true;
                    break;
                case "3":
                    Player.ValidResponse = true;
                    break;
                case "4":
                    Player.ValidResponse = true;
                    if (Player.Projector && Player.PeanutButterSandwich)
                    {
                        Dialog("You suggest a bathroom break. Everyone decides excessive breaks every 20 minutes are an adult necessity. The room clears out, leaving you the opportunity to lay your traps and end these meetings forever.", "green");
                        Player.LevelOneCompleted = true;
                    }
                    else if (Player.Projector)
                    {
                        Dialog(
                            "You suggest a bathroom break. Fred mentions he is not feeling well, he thinks the fish in his sandwich had turned and he asks to go home and have this meeting tomorrow. Ed thinks this is a great idea and the meeting is postponed until tomorrow. You decide there is no point fighting the sever circles of hell that is this meeting. You spend the rest of your life eating sandwiches with Fred and gossiping with the Karens. You are a terrible person.",
                            "yellow");

                        Player.LevelFailed = true;

                    }
                    else
                    {
                        Console.WriteLine("INVALID RESPONSE, PLEASE SELECT A VALID OPTION");
                        
                    }
                    break;
                default:
                    Console.WriteLine("INVALID RESPONSE, PLEASE SELECT A VALID OPTION");
                    break;
            }
        }



        public static void ConversationOptions()
        {
 
            if (Player.Projector && Player.PeanutButterSandwich)
            {
                Dialog("Who do you want to start a conversation with?:" +

                       "\n 1) Ed" +
                       "\n 3) Karen, Karen, and Karen" +
                       "\n 4) Suggest a break", "yellow");
                    
            }
            else if (Player.Projector)
            {
                Dialog("Who do you want to start a conversation with?:" +

                       "\n 2) Fred" +
                       "\n 3) Karen, Karen, and Karen" +
                       "\n 4) Suggest a break", "yellow");
            }
            else if (Player.PeanutButterSandwich)
            {
                Dialog("Who do you want to start a conversation with?:" +
                       "\n 1) Ed" +
                       "\n 3) Karen, Karen, and Karen", "yellow");
            }
            else
            {
                {
                    Dialog("Who do you want to start a conversation with?:" +

                           "\n 1) Ed" +
                           "\n 2) Fred" +
                           "\n 3) Karen, Karen, and Karen", "yellow");
                }
            }
        }

        public static void GameOver()
        {
            if (Player.LevelFailed == true)
            {
                Dialog($"You lose, {Player.CharacterName}. Please hit any key to exit.", "red");
                
                Console.ReadKey();
            }
        }
    }

    public class Player
    {
        public static string CharacterName { get; set; }
        public static bool LevelOneCompleted { get; set; }
        public static bool LevelFailed { get; set; }
        public static bool ValidResponse { get; set; } //validate user response to meet the proper criteria
        public static bool CoffeeCup { get; set; }
        public static bool Projector { get; set; }
        public static bool PeanutButterSandwich { get; set; }
        public static bool CornflowerTie { get; set; }
        public bool EdDead { get; set; }
        public bool FredDead { get; set; }
        public bool KarenDead { get; set; }
    }
}
