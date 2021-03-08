using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventureLibrary;
using FoeLibrary;

namespace SeaAdventurePortfolio
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exitAdventure = true;

            Console.Title = "Sea Adventure";

            #region Weapons
            Weapon starterSword = new Weapon("Starter Sword", "Found buried in the sand a long time ago. It is been your go-to ever since.", WeaponType.StarterSword, 4, 4, 9);
            Weapon ironSword = new Weapon("Iron Sword", "A serviceable blade with a love of plundering.", WeaponType.IronSword, 5, 5, 10);
            Weapon handHook = new Weapon("Hand Hook", "No opposable thumb for you, but it does take down all who oppose you.", WeaponType.HandHook, 6, 3, 10);
            Weapon cutlass = new Weapon("Cutlass", "A menacing blade with a slight curve,  sure to intimidate any foe.", WeaponType.Cutlass, 6, 4, 15);
            #endregion

            #region Foes
            Foe enemyPirate = new Foe("Enemy Pirate", 30, 30, 4, 4, true, "Although having a lot in common with you, they don't seem to want to talk about it.", 5, 9);
            Foe kraken = new Foe("The Kraken", 100, 100, 30, 25, false, "This mighty beast strikes pure fear into your heart.", 15, 200);
            #endregion

            #region Pirate Selection
            PirateOption chosenPirate = new PirateOption();
            bool exitPirateSelection = false;

            do
            {
                Console.WriteLine("Selecting a character."); // Pirate selection screen
                ConsoleKey pirateChoice = Console.ReadKey(true).Key;
                switch (pirateChoice)
                {

                    case ConsoleKey.D1://Warrior
                    case ConsoleKey.NumPad1:
                        Console.Clear();
                        Console.WriteLine("You see a plain old pirate wiht a love for lootin'.\n");
                        chosenPirate = PirateOption.Pirate;
                        exitPirateSelection = true;
                        break;

                    case ConsoleKey.D2://Thief
                    case ConsoleKey.NumPad2:
                        Console.Clear();
                        Console.WriteLine("You have an aptitude for the Caribbean and American Football.\n");
                        chosenPirate = PirateOption.Buccaneer;
                        exitPirateSelection = true;
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine($"{pirateChoice} is not a valid option, press any key to try again.");
                        Console.ReadKey(true);
                        break;
                }
            } while (!exitPirateSelection);
            #endregion
        }
    }
}
