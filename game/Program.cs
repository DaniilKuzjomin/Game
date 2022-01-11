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

            Random rnd = new Random();
            int randomIndex = rnd.Next(0, heroes.Length);

            string randomHero = GetRandomElement(heroes);
            string randomVillain = GetRandomElement(villains);
            string heroWeapon = GetRandomElement(weapons);
            string villainWeapon = GetRandomElement(weapons);
            Console.WriteLine($"Your random villain is: {randomVillain}");
            Console.WriteLine($"Your random hero is: {randomHero}");
            Console.WriteLine($"{randomHero} with {heroWeapon} will fight {randomVillain} with {villainWeapon}");
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
    }
}
