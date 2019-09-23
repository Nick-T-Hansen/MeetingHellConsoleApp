

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
            
           
            LevelOne.LevelOneScenario();
            LevelTwo.LevelTwoScenario();
            LevelThree.LevelThreeScenario();
            BossFight.BossFightScenario();

           Console.Read(); //keep app open
        }
    }
}
