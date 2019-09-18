

using System;

using System.ComponentModel.DataAnnotations;
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
            
            LevelOne.LevelOneScenario();
            LevelTwo.LevelTwoScenario();
            LevelThree.LevelThreeScenario();


            Console.Read(); //keep app open
        }
    }
}
