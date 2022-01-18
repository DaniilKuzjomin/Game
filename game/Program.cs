using System;
using System.IO;

namespace game
{
    class Program
    {
        static void Main(string[] args)
        {
            //string[] heroes = { "Harry Potter", "Superman", "Luke Skywalker", "Lara Kroft" };
            //string[] villains = { "Volandemort", "Joker", "Venom", "Darth Vader", "Cruella" };
            string folderPath = @"C:\Users\opilane\samples\mygame\";
            string[] heroes = GetDataFromFile(folderPath + "heroes.txt");
            string[] villains = GetDataFromFile(folderPath + "villains.txt");
            string[] weapons = GetDataFromFile(folderPath + "weapons.txt");
            string[] armor = GetDataFromFile(folderPath + "armor.txt");

            Random rnd = new Random();
            int randomIndex = rnd.Next(0, heroes.Length);

            string randomHero = GetRandomElement(heroes);
            string randomVillain = GetRandomElement(villains);
            string heroWeapon = GetRandomElement(weapons);
            string villainWeapon = GetRandomElement(weapons);
            string heroArmor = GetRandomElement(armor);
            string villainArmor = GetRandomElement(armor);


            int heroHP = GenerateHP(heroArmor);
            int villainHP = GenerateHP(villainArmor);

            Console.WriteLine($"Your random villain is: {randomVillain} in {villainArmor}");
            Console.WriteLine($"Your random hero is: {randomHero} in {heroArmor}");
            Console.WriteLine($"{randomHero} with {heroWeapon} will fight {randomVillain} with {villainWeapon}");
            Console.WriteLine($"{randomVillain} HP: {villainHP}");
            Console.WriteLine($"{randomHero} HP: {heroHP}");

            while(heroHP >= 0 && villainHP >= 0 )
            {
                heroHP = heroHP - Hit(randomVillain, villainWeapon);
                villainHP = villainHP - Hit(randomHero, heroWeapon);
            }

            if (heroHP > villainHP)
            {
                Console.WriteLine($"{randomHero} saves the day!");
            }
            else if(heroHP<villainHP)
            {
                Console.WriteLine("Dark Side wins!");
            }
            else
            {
                Console.WriteLine($"Someday {randomHero} shall fight {randomVillain} again!");
            }

        }

        public static string GetRandomElement(string[] someArray)
        {
            Random rnd = new Random();
            int randomIndex = rnd.Next(0, someArray.Length);
            string randomCharacter = someArray[randomIndex];
            return randomCharacter;
        }
        public static string[] GetDataFromFile(string filePath)
        {
            string[] dataFromfile = File.ReadAllLines(filePath);
            return dataFromfile;
        }

        public static int GenerateHP(string armor)
        {
            int characterHP = armor.Length;
            return characterHP;
        }

        public static int Hit(string character, string weapon)
        {
            Random rnd = new Random();
            int strike = rnd.Next(0, weapon.Length - 2);
            Console.WriteLine($"{character} hit {strike}!");

            if(strike== weapon.Length - 2)
            {
                Console.WriteLine($"Bad luck! {character} missed the target!");
            }
            return strike;

        }

        
    }
}
