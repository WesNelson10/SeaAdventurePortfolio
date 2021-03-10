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
            do
            {
                Console.Title = "Sea Adventure";

                #region Weapons and Objects
                Weapon starterSword = new Weapon("Starter Sword", "Found buried in the sand a long time ago. It is been your go-to ever since.", WeaponType.StarterSword, 4, 4, 9);
                Weapon ironSword = new Weapon("Iron Sword", "A serviceable blade with a love of plundering.", WeaponType.IronSword, 5, 5, 10);
                Weapon handHook = new Weapon("Hand Hook", "No opposable thumb for you, but it does take down all who oppose you.", WeaponType.HandHook, 6, 3, 10);
                Weapon cutlass = new Weapon("Cutlass", "A menacing blade with a slight curve,  sure to intimidate any foe.", WeaponType.Cutlass, 6, 4, 15);
                OtherObject bread = new OtherObject("Bread", "Some stale but edible bread.", true);
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

                #region Scenarios
                List<Weapon> firstWeapon = new List<Weapon>() { starterSword };
                List<OtherObject> someBread = new List<OtherObject>() { bread };
                Scenario port = new Scenario("Port", "Home of your favorite drinkin' spot. Besides the ship, of course.", firstWeapon, someBread, false, false, false);
                #endregion

                #region Port Intro
                List<Weapon> weaponInventory = new List<Weapon>();
                PlayerPirate realPlayer = new PlayerPirate(playerName, 50, 50, 40, 10, true, chosenPirate, starterSword, weaponInventory);
                Console.Clear();
                Console.WriteLine("You arrive at port, seeking supplies to support the next stint at sea. As you scour the familiar line of buildings for vendors, you notice a group of people surrounding an old man. There seems to be some kind of struggle, and you walk over to investigate.");
                port.IsCurrentScenario = true;
                #endregion

                #region Port Scenario
                while (!exitAdventure)
                {
                    while (port.IsCurrentScenario && !exitAdventure)
                    {
                        Console.WriteLine(port);
                        if (!port.IsScenarioComplete)
                        {
                            Console.WriteLine("By the time you arrived, the old man has handled his attackers with expert swordsmanship. His assailants either lie dead at his feet, or are seen on the horizon, sprinting inland.\nThe old man looks at you with a mischievous grin.\nSon, if you ever want to be a real pirate, you're gonna need a weapon to do that...\nThe old man gestures to the dead attacker below him.\nYou nod in agreement, not wanting to anger the old man further.\nThe old man smiles and holds out his sword, as well as a bag of food.\n[1] View Inventory\n" +
                        "[2] Look around the port\n" +
                        "[3] Take the items\n" +
                        "[4] Leave port/return to ship\n");
                        }
                        else
                        {
                            Console.WriteLine("[1] View Inventory\n" +
                        "[2] Look around the port\n" +
                        "[3] Take the items\n" +
                        "[4] Leave port/return to ship\n");
                        }
                        ConsoleKey scenarioMenuChoice = Console.ReadKey(true).Key;

                        switch (scenarioMenuChoice)
                        {
                            case ConsoleKey.D1:
                            case ConsoleKey.NumPad1:
                                Console.Clear();
                                Display.ViewPlayerInventory(realPlayer);
                                break;

                            case ConsoleKey.D2:
                            case ConsoleKey.NumPad2:
                                Console.Clear();
                                Display.DisplayPort(); // I still use HDMI but oh well
                                break;

                            case ConsoleKey.D3:
                            case ConsoleKey.NumPad3:
                                Console.WriteLine("Taking Items.");
                                break;

                            case ConsoleKey.D4:
                            case ConsoleKey.NumPad4:
                                if (!port.IsScenarioComplete)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Lorem Ipsum");
                                    port.Description = "blah";
                                    port.IsScenarioComplete = true;
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Headed to the ship.");
                                    if (!port.IsEnemyDead)
                                    {
                                        Console.WriteLine("enemy appears");

                                        #region Combat
                                        Foe enemy = enemyPirate;
                                        Console.WriteLine($"An {enemyPirate} stares angrily at you with a snarl.");
                                        Console.WriteLine("Press any button to fight!");
                                        Console.ReadKey(true);

                                        bool exitBattle = false;
                                        do
                                        {
                                            Console.WriteLine($"Choose an Action:" +
                                                        $"\n[1] Attack the {enemy.Name}" +
                                                        $"\n[2] Chat with the {enemy.Name}!" +
                                                        $"\n[3] View Your Stats" +
                                                        $"\n[4] View {enemy.Name}'s Stats" +
                                                        $"\n[5] Access Your Inventory");
                                            ConsoleKey userChoice = Console.ReadKey(true).Key;
                                            Console.Clear();

                                            switch (userChoice)
                                            {
                                                case ConsoleKey.D1:
                                                case ConsoleKey.NumPad1:
                                                    Combat.Battle(realPlayer, enemy);
                                                    if (enemy.Life <= 0)
                                                    {
                                                        Display.Green($"The {enemy.Name} now lies dead before you.");
                                                        exitBattle = true;
                                                    }
                                                    break;

                                                case ConsoleKey.D2:
                                                case ConsoleKey.NumPad2:
                                                    Console.Clear();
                                                    Console.WriteLine("Chatting functionality here.");
                                                    break;

                                                case ConsoleKey.D3:
                                                case ConsoleKey.NumPad3:
                                                    Console.WriteLine(realPlayer);
                                                    break;

                                                case ConsoleKey.D4:
                                                case ConsoleKey.NumPad4:
                                                    Console.WriteLine(enemy);
                                                    break;

                                                case ConsoleKey.D5:
                                                case ConsoleKey.NumPad5:
                                                    Display.ViewPlayerInventory(realPlayer);
                                                    break;

                                                default:
                                                    Console.Clear();
                                                    Console.WriteLine("Invalid choice. Try again.");
                                                    break;
                                            }
                                            if (realPlayer.Life <= 0)
                                            {
                                                Display.Red($"The {enemy.Name} has defeated you!");
                                                exitAdventure = true;
                                            }
                                        } while (!exitBattle && !exitAdventure);
                                    }

                                    #endregion
                                }
                                break;
                        }


                    }
                }
                #endregion
            } while (!exitAdventure);


        }
    }
}
