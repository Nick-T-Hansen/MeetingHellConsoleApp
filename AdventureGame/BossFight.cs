using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureGame
{
    class BossFight
    {
        public static void BossFightScenario() // currently, if the game fails in an earlier level, bossfight still runs.
        {
            Console.Clear();
            Console.Title = "Level Three - John Wick the Room";
            Console.WriteLine(
                $"Congrats, {Player.CharacterName}. After you clean up this mess you made you will be able to take your lunch break. I know you are excited, you have leftover meatloaf.");
            Console.WriteLine();
            UserScenario(); 

            do
            {
                AttackNinja();
                if (!Player.BossFightCompleted)
                {
                    AttackPokemon();
                    if (!Player.LevelFailed)
                    {
                        Console.WriteLine("The fight rages on, press any key to continue.");
                        Console.ReadKey();
                    }
                }
            } while (!Player.BossFightCompleted);

            Game.GameOver();
        }

        public static void UserScenario()
        {
            Game.Dialog("You look around the room. It is silent. You grab your coffee mug and start to walk out of the meeting room. All of the sudden, you see a figure fall out of the drop ceiling. Oh no. He has returned...", "white");
            NinjaModel.GenerateNinja();
            Console.WriteLine();
            Game.Dialog("You have one last trick up your sleeve. You throw your favorite coffee mug and yell your best battle cry. Behind the ninja your untamed companion arrives.", "yellow");
            PokemonModel.GeneratePokemon();
            Console.WriteLine();
        }

        public static void AttackPokemon()
        {
            NinjaModel.GenerateRandomDamage();

            Console.WriteLine($"Ninja attacks {PokemonModel.PokemonType} with a {NinjaModel.Weapon}!");
            var pokemonRemainingLife = PokemonModel.Health - NinjaModel.Damage;
            PokemonModel.Health = pokemonRemainingLife;
            if (PokemonModel.Health <= 0)
            {
                Player.LevelFailed = true;
                Player.BossFightCompleted = true;
                Game.Dialog($"{PokemonModel.PokemonType} has been decapitated. The Ninja turns to you and throws his {NinjaModel.Weapon} at you. Your head explodes.","red");
            }
        }

        public static void AttackNinja()
        //combine attackType + damage to reduce ninja's health. If Thanos + snap, make instant kill. If other + snap, make ineffective'
        {
            PokemonModel.GenerateRandomDamage();
            PokemonModel.GenerateRandomAttack();

            switch (PokemonModel.PokemonType)
            {
                case "Thanos":
                    if (PokemonModel.AttackType == "snap")
                    {
                        NinjaModel.Health = 0;
                        Game.Dialog("At the snap of Thanos' fingers, the ninja disintegrates instantly.", "green");
                        Player.BossFightCompleted = true;
                    }
                    else
                    {
                        Console.WriteLine($"{PokemonModel.PokemonType} attacks the ninja with a {PokemonModel.AttackType}!");
                        var ninjaRemainingLife = NinjaModel.Health - PokemonModel.Damage;
                        NinjaModel.Health = ninjaRemainingLife;
                        if (NinjaModel.Health <= 0)
                        {
                            Player.BossFightCompleted = true;
                            Game.Dialog($"{PokemonModel.PokemonType} has slain the ninja! You rejoice!", "Red");
                            return;
                        }
                    }
                    break;
                default:
                    Console.WriteLine($"{PokemonModel.PokemonType} attacks the ninja with a {PokemonModel.AttackType}!");
                    if (PokemonModel.PokemonType != "Thanos" && PokemonModel.AttackType == "snap")
                    {
                        PokemonModel.Damage = 0;
                        Game.Dialog("The snap was highly ineffective, and in reality, plain stupid. The ninja laughs at you.", "red");
                    }
                    var ninjaRemainingLife2 = NinjaModel.Health - PokemonModel.Damage;
                    NinjaModel.Health = ninjaRemainingLife2;
                    if (NinjaModel.Health <= 0)
                    {
                        Player.BossFightCompleted = true;
                        Game.Dialog($"{PokemonModel.PokemonType} has slain the ninja! You rejoice!", "Red");
                    }
                    break;
            }
        }
    }
}
