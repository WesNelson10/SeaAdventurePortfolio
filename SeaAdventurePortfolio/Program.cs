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
            bool lostGame = false;
            bool exitBattle = false;
            int killCount = 0;

            Console.WindowHeight = 40;

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
                OtherObject armorVest = new OtherObject("Armored Vest", "This might give you an edge in combat.", true);
                OtherObject goldCompass = new OtherObject("A Golden Compass", "You already have a compass. But this one is golden!", true);
                List<Weapon> weapons = new List<Weapon>();
                weapons.Add(starterSword);
                //weapons.Add(ironSword);
                //weapons.Add(handHook);
                //weapons.Add(cutlass);

                List<OtherObject> others = new List<OtherObject>();
                //others.Add(bread);
                //others.Add(armorVest);

                #endregion

                #region Foes
                Foe enemyPirate = new Foe("Enemy Pirate", 30, 30, 50, 4, true, "Although having a lot in common with you, they don't seem to want to talk about it.", 4, 8);
                Foe enemyPirateCaptain = new Foe("Enemy Pirate (Captain)", 40, 40, 60, 20, true, "Sure, he's angry about you killing a crew member of his, but the captain's thoughts are more focused on your loot.", 6, 12);
                Foe kraken = new Foe("Kraken", 50, 50, 20, 8, false, "This mighty beast strikes pure fear into your heart.", 8, 25);
                Foe chestGuard = new Foe("Chest Guard", 30, 30, 40, 3, false, "His captain left him here with the chest to guard it for life.", 8, 12);
                #endregion

                #region Pirate Selection
                PirateOption chosenPirate = new PirateOption();
                bool exitPirateSelection = false;
               
                Console.WriteLine("Ahoy, scallywag! Enter your name: ");
                string playerName = Console.ReadLine(); // player's name
                Console.Clear();

                do
                {
                    Console.WriteLine($"You wake to the smell of rum and salt. The room is slowly rocking back and forth, and you manage to get up out of your hammock. Out of the small window, you seem to be approaching land.\n\n********************\n\nThere is also a dusty mirror on the opposite wall - you navigate to that mirror.\nWhat type of pirate do you see, {playerName}?\n\n********************\n[1] Default Pirate\n" +
                    "[2] Buccaneer\n" +
                    "[3] Corsair\n" +
                    "[4] Privateer\n"); // Pirate selection screen
                    ConsoleKey pirateChoice = Console.ReadKey(true).Key;
                    switch (pirateChoice)
                    {

                        case ConsoleKey.D1:
                        case ConsoleKey.NumPad1:
                            Console.Clear();
                            Console.WriteLine("You see a plain old pirate with a love for lootin'.\n");
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
                Scenario port = new Scenario("Port", "Home of your favorite drinkin' spot. Besides the ship, of course.", false, false, false);
                Scenario sea = new Scenario("The Open Sea", "Who knows what you will face here.", false, false, false);
                Scenario island = new Scenario("A lonely Island", "This one's not a hallucination", false, false, false);
                #endregion

                #region Chats
                List<Chat> chats = new List<Chat>();
                Chat port1 = new Chat("Taking offense to your diplomacy, the enemy lunges out and strikes you with someone's detached peg leg.");
                Chat port2 = new Chat("The enemy seems amused by your attempt at reasoning.");
                Chat port3 = new Chat("The enemy lowers his guard for a moment, allowing you to do extra damage.");
                Chat port4 = new Chat("The enemy is not thrown off by your words.");
                Chat port5 = new Chat("Your chat did nothing.");
                chats.Add(port1);
                chats.Add(port2);
                chats.Add(port3); // manually adding, could refactor to use collection initialization syntax
                chats.Add(port4);
                chats.Add(port5);
                Random rand = new Random();
                #endregion

                PlayerPirate player = new PlayerPirate(playerName, 50, 50, 70, 5, false, killCount, chosenPirate, starterSword, weapons, others, true); // global player

                do
                {
                    Foe enemy = enemyPirate;
                    port.IsCurrentScenario = true;
                    Display.DisplayPort();
                    Console.WriteLine("You make port in the early afternoon, looking to restock on food for the long journey ahead. As you approach vendors, a battle seems to be brewing. You make your way over to the commotion - a pirate seems to be roughing up some villagers.\n"); // TODO add port intro details
                    Console.WriteLine($"Choose an Action:" +
                                                $"\n[1] Attack the {enemy.Name}" +
                                                $"\n[2] Chat" +
                                                $"\n[3] View Your Stats" +
                                                $"\n[4] View {enemy.Name}'s Stats" +
                                                $"\n[5] Inventory" +
                                                $"\n[6] Where am I..." +
                                                $"\n[7] Exit Game");
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
                                Display.Green($"You find some {bread.Name} after the fight!");
                                others.Add(bread);
                                killCount++;
                                exitBattle = true;
                            }
                            if (player.Life <= 0)
                            {
                                lostGame = true;
                                exitBattle = true;
                                exitAdventure = true;                              
                            }
                            break;

                        case ConsoleKey.D2:
                        case ConsoleKey.NumPad2:
                            int r = rand.Next(0, chats.Count);
                            System.Threading.Thread.Sleep(50);
                            Console.WriteLine(chats[r]);
                            if (chats[r].Message == "The enemy lowers his guard for a moment, allowing you to do extra damage.")
                            {
                                Display.Green("Max Damage Increased!");
                                player.EquippedWeapon.MaxDamage += 2;
                            }
                            if (chats[r].Message == "Taking offense to your diplomacy, the enemy lunges out and strikes you with someone's detached peg leg.")
                            {
                                Display.Red("Hit for 2 damage...");
                                player.Life -= 2;
                            }
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

                        case ConsoleKey.D6:
                        case ConsoleKey.NumPad6:
                            Console.WriteLine(port);
                            break;

                        case ConsoleKey.D7:
                        case ConsoleKey.NumPad7:
                            lostGame = true;
                            exitBattle = true;
                            exitAdventure = true;                     
                            break;

                        default:
                            break;
                    }
                } while (player.Life > 0 && !exitBattle);

                exitBattle = false;

                if (!exitAdventure)
                {
                    //Sea fight goes here
                    do
                    {
                        Foe enemy = kraken;
                        Display.DisplayKraken();
                        Console.WriteLine("After a long while at sea, you hear a low rumbling in the ocean...");
                        Console.WriteLine($"Choose an Action:" +
                                                    $"\n[1] Attack the {enemy.Name}" +
                                                    $"\n[2] Chat" +
                                                    $"\n[3] View Your Stats" +
                                                    $"\n[4] View {enemy.Name}'s Stats" +
                                                    $"\n[5] Access Your Inventory" +
                                                    $"\n[6] Where am I..." +
                                                    $"\n[7] Exit Game");
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
                                    killCount++;
                                    exitBattle = true;
                                    Display.Green($"You find a {handHook.Name} after the fight!");
                                    weapons.Add(handHook);
                                }
                                if (player.Life <= 0)
                                {
                                    lostGame = true;
                                    exitBattle = true;
                                    exitAdventure = true;
                                }
                                break;

                            case ConsoleKey.D2:
                            case ConsoleKey.NumPad2:
                                int q = rand.Next(0, chats.Count);
                                System.Threading.Thread.Sleep(50);
                                Console.WriteLine(chats[q]);
                                if (chats[q].Message == "The enemy lowers his guard for a moment, allowing you to do extra damage.")
                                {
                                    Display.Green("Max Damage Increased!");
                                    player.EquippedWeapon.MaxDamage += 2;
                                }
                                if (chats[q].Message == "Taking offense to your diplomacy, the enemy lunges out and strikes you with someone's detached peg leg.")
                                {
                                    Display.Red("Hit for 2 damage...");
                                    player.Life -= 2;
                                }
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

                            case ConsoleKey.D6:
                            case ConsoleKey.NumPad6:
                                Console.WriteLine(sea);
                                break;

                            case ConsoleKey.D7:
                            case ConsoleKey.NumPad7:
                                lostGame = true;
                                exitBattle = true;
                                exitAdventure = true;                                
                                break;

                            default:
                                break;
                        }
                    } while (player.Life > 0 && !exitBattle);
                }

                exitBattle = false;

                if (!exitAdventure)
                {
                    //Sea fight goes here
                    do
                    {
                        Foe enemy = enemyPirateCaptain;
                        Display.DisplayEnemyShip();
                        Console.WriteLine("Word seems to have spread about your altercation at port earlier.");
                        Console.WriteLine($"Choose an Action:" +
                                                    $"\n[1] Attack the {enemy.Name}" +
                                                    $"\n[2] Chat" +
                                                    $"\n[3] View Your Stats" +
                                                    $"\n[4] View {enemy.Name}'s Stats" +
                                                    $"\n[5] Access Your Inventory" +
                                                    $"\n[6] Where am I..." +
                                                    $"\n[7] Exit Game");
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
                                    killCount++;
                                    exitBattle = true;
                                    Display.Green($"You find a {cutlass.Name} after the fight!");
                                    weapons.Add(cutlass);
                                }
                                if (player.Life <= 0)
                                {
                                    lostGame = true;
                                    exitBattle = true;
                                    exitAdventure = true;
                                }
                                break;

                            case ConsoleKey.D2:
                            case ConsoleKey.NumPad2:
                                int x = rand.Next(0, chats.Count);
                                System.Threading.Thread.Sleep(50);
                                Console.WriteLine(chats[x]);
                                if (chats[x].Message == "The enemy lowers his guard for a moment, allowing you to do extra damage.")
                                {
                                    Display.Green("Max Damage Increased!");
                                    player.EquippedWeapon.MaxDamage += 2;
                                }
                                if (chats[x].Message == "Taking offense to your diplomacy, the enemy lunges out and strikes you with someone's detached peg leg.")
                                {
                                    Display.Red("Hit for 6 damage...");
                                    player.Life -= 6;
                                }
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

                            case ConsoleKey.D6:
                            case ConsoleKey.NumPad6:
                                Console.WriteLine(sea);
                                break;

                            case ConsoleKey.D7:
                            case ConsoleKey.NumPad7:
                                lostGame = true;
                                exitBattle = true;
                                exitAdventure = true;
                                break;

                            default:
                                break;
                        }
                    } while (player.Life > 0 && !exitBattle);
                }

                exitBattle = false;

                if (!exitAdventure)
                {
                    //Sea fight goes here
                    do
                    {
                        Foe enemy = chestGuard;
                        Display.DisplayIsland();
                        Console.WriteLine("An intriguing island lies before you.");
                        Console.WriteLine($"Choose an Action:" +
                                                    $"\n[1] Attack the {enemy.Name}" +
                                                    $"\n[2] Chat" +
                                                    $"\n[3] View Your Stats" +
                                                    $"\n[4] View {enemy.Name}'s Stats" +
                                                    $"\n[5] Access Your Inventory" +
                                                    $"\n[6] Where am I..." +
                                                    $"\n[7] Exit Game");
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
                                    killCount++;
                                    exitBattle = true;
                                    exitAdventure = true;
                                }
                                else if (player.Life <= 0)
                                {
                                    exitBattle = true;
                                    exitAdventure = true;
                                    lostGame = true;
                                }
                                break;

                            case ConsoleKey.D2:
                            case ConsoleKey.NumPad2:
                                int y = rand.Next(0, chats.Count);
                                System.Threading.Thread.Sleep(50);
                                Console.WriteLine(chats[y]);
                                if (chats[y].Message == "The enemy lowers his guard for a moment, allowing you to do extra damage.")
                                {
                                    Display.Green("Max Damage Increased!");
                                    player.EquippedWeapon.MaxDamage += 2;
                                }
                                if (chats[y].Message == "Taking offense to your diplomacy, the enemy lunges out and strikes you with someone's detached peg leg.")
                                {
                                    Display.Red("Hit for 10 damage...");
                                    player.Life -= 10;
                                }
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

                            case ConsoleKey.D6:
                            case ConsoleKey.NumPad6:
                                Console.WriteLine(island);
                                break;

                            case ConsoleKey.D7:
                            case ConsoleKey.NumPad7:
                                lostGame = true;
                                exitBattle = true;
                                exitAdventure = true;                             
                                break;

                            default:
                                break;
                        }

                    } while (player.Life > 0 && !exitBattle);
                }             
            } while (!exitAdventure);
            //Closing sequence
            if (lostGame)
            {
                Console.WriteLine("Final Score: " + killCount);
                Display.DeathCard();
            }
            else
            {
                Console.WriteLine("Final Score: " + killCount);
                Display.WinCard();
            }

        }
    }
}
