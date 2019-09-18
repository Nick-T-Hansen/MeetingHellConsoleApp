using System;

namespace AdventureGame
{
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
        public static void GameOver()
        {
            if (Player.LevelFailed == true)
            {
                Dialog($"You lose, {Player.CharacterName}. Please hit any key to exit.", "red");
                Console.ReadKey();
            }
        }
    }
}