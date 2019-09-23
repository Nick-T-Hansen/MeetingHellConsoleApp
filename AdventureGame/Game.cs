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
            if (Player.LevelFailed)
            {
                Dialog($"You lose, {Player.CharacterName}. Please hit any key to exit.", "red");
            }

            else if (Player.BossFightCompleted && !Player.LevelFailed )
            {
                Dialog($"Congratulations, you have ended pointless meetings forever. You must tell everyone by now writing a memo and distributing it via fax. Please hit any key to exit.", "red");
            }
        }
    }
}