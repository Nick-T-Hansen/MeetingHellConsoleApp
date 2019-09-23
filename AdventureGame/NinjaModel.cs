using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace AdventureGame
{
    class NinjaModel
    {
        public static int Health { get; set; }
        public static string Weapon { get; set; }
        public static int Damage { get; set; }

        public static void GenerateNinja()
        {
            GenerateRandomWeapon();
            GenerateRandomHealth();
        }
        public static void GenerateRandomDamage()
        {
            Random rnd = new Random();
            int[] damageNums = {10, 20, 30, 40, 50};
            int dmgIndex = rnd.Next(damageNums.Length);
            Damage = damageNums[dmgIndex];
        }
        public static void GenerateRandomWeapon()
        {
            Random rnd = new Random();
            string[] weaponName = {"katana", "rubber chicken", "broom", "rusty knife", "giant foam finger"};
            int wpnIndex = rnd.Next(weaponName.Length);
            Console.WriteLine($"Careful, the ninja is wielding a {weaponName[wpnIndex]}!");
            Weapon = weaponName[wpnIndex];
        }
        public static void GenerateRandomHealth()
        {
            Random rnd = new Random();
            int[] healthNums = {50, 60, 70, 80, 90};
            int hlthIndex = rnd.Next(healthNums.Length);
            Health = healthNums[hlthIndex];
        }
    }
}
