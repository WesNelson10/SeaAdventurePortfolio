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
            bool exitAdventure = false;
            do
            {
                Console.Title = "Sea Adventure";
                Display.SeaTheme(); // custom title card and song

                #region Weapons and Objects
                Weapon starterSword = new Weapon("Starter Sword", "Found buried in the sand a long time ago. It is been your go-to ever since.", WeaponType.StarterSword, 4, 4, 9);
                Weapon ironSword = new Weapon("Iron Sword", "A serviceable blade with a love of plundering.", WeaponType.IronSword, 5, 5, 10);
                Weapon handHook = new Weapon("Hand Hook", "No opposable thumb for you, but it does take down all who oppose you.", WeaponType.HandHook, 6, 3, 10);
                Weapon cutlass = new Weapon("Cutlass", "A menacing blade with a slight curve,  sure to intimidate any foe.", WeaponType.Cutlass, 6, 4, 15);
                OtherObject bread = new OtherObject("Bread", "Some stale but edible bread.", true);
                #endregion

                #region Foes
                Foe enemyPirate = new Foe("Enemy Pirate", 30, 30, 50, 4, true, "Although having a lot in common with you, they don't seem to want to talk about it.", 5, 9);
                Foe kraken = new Foe("Kraken", 50, 50, 20, 8, false, "This mighty beast strikes pure fear into your heart.", 10, 30);
                Foe richGuy = new Foe("Rich Guy", 30, 30, 4, 3, false, "This man has earned his wealth through the exploitation of the laborers.", 4, 8);
                #endregion

                #region Pirate Selection
                PirateOption chosenPirate = new PirateOption();
                bool exitPirateSelection = false;
               
                Console.WriteLine("Ahoy, scallywag! Enter your name: ");
                string playerName = Console.ReadLine(); // player's name
                Console.Clear();

                do
                {
                    Console.WriteLine($"You wake to the smell of rum and salt. The room is slowly rocking back and forth, and you manage to get up out of your hammock. Out of the small window, you seem to be approaching land. There is also a dusty mirror on the opposite wall - you navigate to that mirror.\n ****************\nWhat type of pirate do you see, {playerName}?\n[1] Default Pirate\n" +
                    "[2] Buccaneer\n" +
                    "[3] Corsair\n" +
                    "[4] Privateer\n"); // Pirate selection screen
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

                List<Weapon> weaponInventory = new List<Weapon>(firstWeapon); // we don't have to specify the weapon right now.
                List<OtherObject> otherInventory = new List<OtherObject>(someBread);

                PlayerPirate player = new PlayerPirate(playerName, 50, 50, 70, 5, false, chosenPirate, starterSword, weaponInventory, true);

                //Port fight goes here
                //bool exitScenario = false;
                bool exitBattle = false;

                do
                {
                    Foe enemy = enemyPirate;
                    Display.DisplayPort();
                    Console.WriteLine("You make port in the early afternoon, looking to restock on food for the long journey ahead. As you approach vendors, a battle seems to be brewing. (ADD MORE DETAILS)"); // TODO add port intro details
                    Console.WriteLine($"Choose an Action:" +
                                                $"\n[1] Attack the {enemy.Name}" +
                                                $"\n[2] Chat" +
                                                $"\n[3] View Your Stats" +
                                                $"\n[4] View {enemy.Name}'s Stats" +
                                                $"\n[5] Inventory");
                    ConsoleKey userChoice = Console.ReadKey(true).Key;
                    Console.Clear();
                    switch (userChoice)
                    {
                        case ConsoleKey.D1:
                        case ConsoleKey.NumPad1:
                            Combat.Battle(player, enemy);
                            if (enemy.Life <= 0)
                            {
                                Display.Green($"The {enemy.Name} died!");
                                exitBattle = true;
                            }
                            break;

                        case ConsoleKey.D2:
                        case ConsoleKey.NumPad2:
                            Console.WriteLine("Chatting...");
                            break;

                        case ConsoleKey.D3:
                        case ConsoleKey.NumPad3:
                            Console.WriteLine(player);
                            break;

                        case ConsoleKey.D4:
                        case ConsoleKey.NumPad4:
                            Console.WriteLine(enemy);
                            break;

                        case ConsoleKey.D5:
                        case ConsoleKey.NumPad5:
                            Display.ViewPlayerInventory(player);
                            break;

                        default:
                            break;
                    }
                } while (player.Life > 0 && !exitBattle);

                if (!exitAdventure)
                {
                    //Sea fight goes here
                    do
                    {
                        Foe enemy = kraken;
                        Display.DisplayPort();
                        Console.WriteLine("After a long while at sea, you hear a low rumbling in the ocean..."); // TODO add port intro details
                        Console.WriteLine($"Choose an Action:" +
                                                    $"\n[1] Attack the {enemy.Name}" +
                                                    $"\n[2] Chat" +
                                                    $"\n[3] View Your Stats" +
                                                    $"\n[4] View {enemy.Name}'s Stats" +
                                                    $"\n[5] Access Your Inventory");
                        ConsoleKey userChoice = Console.ReadKey(true).Key;
                        Console.Clear();
                        switch (userChoice)
                        {
                            case ConsoleKey.D1:
                            case ConsoleKey.NumPad1:
                                Combat.Battle(player, enemy);
                                if (enemy.Life <= 0)
                                {
                                    Display.Green($"The {enemy.Name} died!");
                                    exitBattle = true;
                                }
                                break;

                            case ConsoleKey.D2:
                            case ConsoleKey.NumPad2:
                                Console.WriteLine("chatting");
                                break;

                            case ConsoleKey.D3:
                            case ConsoleKey.NumPad3:
                                Console.WriteLine(player);
                                break;

                            case ConsoleKey.D4:
                            case ConsoleKey.NumPad4:
                                Console.WriteLine(enemy);
                                break;

                            case ConsoleKey.D5:
                            case ConsoleKey.NumPad5:
                                Display.ViewPlayerInventory(player);
                                break;

                            default:
                                break;
                        }

                    } while (player.Life > 0 && exitBattle);
                }

                if (!exitAdventure)
                {
                    //Land fight goes here
                    do
                    {
                        Foe enemy = richGuy;
                        Display.Heal(player);
                        Display.DisplayPort();
                        Console.WriteLine("Arriving at port once more, you see a wealthy man attacking some citizens. You have healed to full health."); // TODO add port intro details
                        Console.WriteLine($"Choose an Action:" +
                                                    $"\n[1] Attack the {enemy.Name}" +
                                                    $"\n[2] Chat" +
                                                    $"\n[3] View Your Stats" +
                                                    $"\n[4] View {enemy.Name}'s Stats" +
                                                    $"\n[5] Access Your Inventory");
                        ConsoleKey userChoice = Console.ReadKey(true).Key;
                        Console.Clear();
                        switch (userChoice)
                        {
                            case ConsoleKey.D1:
                            case ConsoleKey.NumPad1:
                                Combat.Battle(player, enemy);
                                if (enemy.Life <= 0)
                                {
                                    Display.Green($"The {enemy.Name} died!");
                                    exitBattle = true;
                                    exitAdventure = true;
                                }
                                break;

                            case ConsoleKey.D2:
                            case ConsoleKey.NumPad2:
                                Console.WriteLine("chatting");
                                break;

                            case ConsoleKey.D3:
                            case ConsoleKey.NumPad3:
                                Console.WriteLine(player);
                                break;

                            case ConsoleKey.D4:
                            case ConsoleKey.NumPad4:
                                Console.WriteLine(enemy);
                                break;

                            case ConsoleKey.D5:
                            case ConsoleKey.NumPad5:
                                Display.ViewPlayerInventory(player);
                                break;

                            default:
                                break;
                        }

                    } while (player.Life > 0 && exitBattle);
                }

            } while (!exitAdventure);
            //Closing sequence
            Display.DeathCard();

        }
    }
}
