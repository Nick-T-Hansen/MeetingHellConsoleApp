using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureGame
{
    class PokemonModel 
    {
        public static string PokemonType { get; set; }
        public static string AttackType { get; set; }
        public static int Health { get; set; }
        public static int Damage { get; set; }

        //When the pokemon is randomly generated,
        //it should use attacks and damage numbers from a list of possible choices
        //and combine them to do damage to the ninja

        public static void GeneratePokemon()
        {
            GeneratePokemonType();
            GenerateRandomHealth();
        }
        public static void GeneratePokemonType()
        {
            Random rnd = new Random();
            string[] pokemonTypes = { "Pikachu", "Tiny Version of Tyler", "Thanos" };
            int pokeIndex = rnd.Next(pokemonTypes.Length);
            PokemonType = pokemonTypes[pokeIndex];
            Console.WriteLine($"Oh wow, a wild {PokemonType} appears!");
        }
        public static void GenerateRandomHealth()
        {
            Random rnd = new Random();
            int[] healthNums = { 50, 60, 70, 80, 90 };
            int hlthIndex = rnd.Next(healthNums.Length);
            Health = healthNums[hlthIndex];
        }
        public static void GenerateRandomDamage()
        {
            Random rnd = new Random();
            int[] damageNums = { 10, 20, 30, 40, 50 };
            int dmgIndex = rnd.Next(damageNums.Length);
            Damage = damageNums[dmgIndex];
        }
        public static void GenerateRandomAttack()
        {
            Random rnd = new Random();
            string[] attackTypes = { "sharknado", "drop kick", "throat punch", "snap" };
            int atkIndex = rnd.Next(attackTypes.Length);
            AttackType = attackTypes[atkIndex];
            
        }
      
       
    }
}
