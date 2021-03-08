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

            Console.WriteLine(@"
                            ______________________________________________
       sea               .-'                     _                        '.
       adventure       .'                       |-'                        |
                     .'                         |                          |
                  _.'               p         _\_/_         p              |
               _.'                  |       .'  |  '.       |              |
          __..'                     |      /    |    \      |              |
    ___..'                         .T\    ======+======    /T.             |
 ;;;\::::                        .' | \  /      |      \  / | '.           |
 ;;;|::::                      .'   |  \/       |       \/  |   '.         |
 ;;;/::::                    .'     |   \       |        \  |     '.       |
       ''.__               .'       |    \      |         \ |       '.     |
            ''._          <_________|_____>_____|__________>|_________>    |
                '._     (___________|___________|___________|___________)  |
                   '.    \;;o;;;o;;;o;;;;;o;;;;;o;;;;;o;;;;;o;;;;;o;;;;/   |
                     '.~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~   |
                       '. ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~  |
                         '-.______________________________________________.'
");
            Console.WriteLine("Ahoy, scallywag! Enter your name: ");
            string playerName = Console.ReadLine(); // player's name
            Console.Clear();

            do
            {
                Console.WriteLine($"You wake to the smell of rum and salt.The room is slowly rocking back and forth, and you manage to get up out of the bed.There is a dusty mirror on the opposite wall - you navigate to that mirror.\n ****************\nWhat type of pirate do you see, {playerName}?\n[1] Default Pirate\n" +
                "[2] Privateer\n" +
                "[3] Corsair\n" +
                "[4] Buccaneer\n"); // Pirate selection screen
                ConsoleKey pirateChoice = Console.ReadKey(true).Key;
                switch (pirateChoice)
                {

                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        Console.Clear();
                        Console.WriteLine("You see a plain old pirate wiht a love for lootin'.\n");
                        chosenPirate = PirateOption.Pirate;
                        exitPirateSelection = true;
                        break;

                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        Console.Clear();
                        Console.WriteLine("You have an aptitude for the Caribbean and American Football.\n");
                        chosenPirate = PirateOption.Buccaneer;
                        exitPirateSelection = true;
                        break;

                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        Console.Clear();
                        Console.WriteLine("A European type pirate stares back at you.\n");
                        chosenPirate = PirateOption.Corsair;
                        exitPirateSelection = true;
                        break;

                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        Console.Clear();
                        Console.WriteLine("A professional looking individual smirks at you in the mirrror.\n");
                        chosenPirate = PirateOption.Privateer;
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
