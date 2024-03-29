﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace AdventureLibrary
{
    public class Display
    {
        #region Player Inventory
        public static void ViewPlayerInventory(PlayerPirate player)
        {
            bool exitAll = false;
            do
            {
                bool viewWeapons = false;
                bool viewOther = false;
                bool exitType = false;
                do
                {
                    Console.WriteLine($"{player.Life}/{player.MaxLife} health."
                    +
                    $"\n\n" +
                    "[1] Weapons\n" +
                    "[2] Other Items\n" +
                    "[3] Exit");
                    ConsoleKey choice = Console.ReadKey(true).Key;

                    switch (choice)
                    {
                        case ConsoleKey.D1:
                        case ConsoleKey.NumPad1:
                            Console.Clear();
                            exitType = true;
                            viewWeapons = true;
                            break;

                        case ConsoleKey.D2:
                        case ConsoleKey.NumPad2:
                            Console.Clear();
                            exitType = true;
                            viewOther = true;
                            break;

                        case ConsoleKey.D3:
                        case ConsoleKey.NumPad3:
                            Console.Clear();
                            exitAll = true;
                            break;

                        default:
                            Console.Clear();
                            Console.WriteLine($"{choice} is not a valid option. Try again.");
                            break;
                    }//item select

                } while (!exitType && !exitAll);//exit item select

                while (viewWeapons) // WEAPONS INV
                {
                    foreach (Weapon weapon in player.WeaponInventory)
                    {
                        bool exitChoice = false;
                        do
                        {
                            Console.WriteLine($"You have: {weapon.Name}\n" +
                                                $"[1] Equip {weapon.Name}\n" +
                                                $"[2] Leave {weapon.Name}\n");

                            ConsoleKey userChoice = Console.ReadKey(true).Key;
                            switch (userChoice)
                            {
                                case ConsoleKey.D1:
                                case ConsoleKey.NumPad1:
                                    Console.Clear();
                                    player.EquippedWeapon = weapon;
                                    Console.WriteLine($"The {weapon.Name} has been equipped.");
                                    exitChoice = true;
                                    break;

                                case ConsoleKey.D2:
                                case ConsoleKey.NumPad2:
                                    Console.Clear();
                                    Console.WriteLine($"The {weapon.Name} has not been equipped.");
                                    exitChoice = true;
                                    break;

                                default:
                                    Console.Clear();
                                    Console.WriteLine($"{userChoice} is an invalid choice. Try again.");
                                    break;
                            }
                        } while (!exitChoice);
                    }
                    viewWeapons = false;
                }
                while (viewOther) // OTHER INV
                {
                    foreach (OtherObject @object in player.OtherInventory)
                    {
                        bool exitChoice = false;
                        do
                        {
                            Console.WriteLine($"You have: {@object.Name}\n" +
                                                $"[1] View {@object.Name}\n" +
                                                $"[2] Leave {@object.Name}");

                            ConsoleKey userChoice = Console.ReadKey(true).Key;

                            switch (userChoice)
                            {
                                case ConsoleKey.D1://examine
                                case ConsoleKey.NumPad1:
                                    Console.Clear();
                                    Console.WriteLine($"You examine the {@object.Name}: " +
                                        $"\n{@object.Description}");
                                    if (@object.Name == "Bread")
                                    {
                                        Console.WriteLine("\nDo you want to eat the bread?\n" +
                                            "[1] Yes\n[2] No");
                                        ConsoleKey breadChoice = Console.ReadKey(true).Key;
                                        bool inLoop = true;
                                        do
                                        {
                                            switch (breadChoice)
                                            {
                                                case ConsoleKey.D1:
                                                case ConsoleKey.NumPad1:
                                                    Console.Clear();
                                                    EatBread(player);                                                    
                                                    inLoop = false;
                                                    break;

                                                case ConsoleKey.D2:
                                                case ConsoleKey.NumPad2:
                                                    Console.Clear();
                                                    Console.WriteLine("Savin' that bread for later.");
                                                    inLoop = false;
                                                    break;

                                                default:
                                                    Console.Clear();
                                                    Console.WriteLine($"{breadChoice} is not a valid option. Try again.");
                                                    break;
                                            }
                                        } while (inLoop);
                                    }
                                    exitChoice = true;
                                    break;

                                case ConsoleKey.D2:
                                case ConsoleKey.NumPad2:
                                    Console.Clear();
                                    Console.WriteLine($"You leave the {@object.Name}.");
                                    exitChoice = true;
                                    break;

                                default:
                                    Console.Clear();
                                    Console.WriteLine($"{userChoice} was not a valid option. Try again.");
                                    break;
                            }
                        } while (!exitChoice);
                    }
                    viewOther = false;
                } // END OTHER INV
                exitAll = true;
            } while (!exitAll);
        } // method end
        #endregion

        #region Text Colors
        public static void Red(string input)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(input);
            Console.ResetColor();
            // All this happens when we pass a string through this method.
        }

        public static void Green(string input)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(input);
            Console.ResetColor();
        }
        #endregion

        #region Ascii Art
        public static void DisplayPort()// lol
        {
            string portAscii = @"
                              ___        ___       T__
                    ________   | |~~~~~~~~| ||~~~~| |||
__|~~~~~~~~|   _/\_ |^^^^^^|  _| |--------| ||    | |##
|_|HHHHHHHH|  _|--| |------|_-#########################
";
            Console.WriteLine(portAscii);
        }
        public static void DisplayKraken()
        {
            string krakenAscii = @"
        ___
       / o \
  __   \   /   _
    \__/ | \__/ \
   \___//|\\___/\
    ___/ | \___ 
         |     \
        /                        
";
            Console.WriteLine(krakenAscii);
        }
        public static void DisplaySea()
        {
            string seaAscii = @"
_-=-__    \_/
(______)  -(_)-  ,;,
           / \   _|__
~~~~~~~~~~~~~~~~(____
~~~  ~  -+-  ~~ ~ ~
  ---*--(_)--*---
 ~~~   /   \   ~ ~~
~ ~ ~ U-----U ~ ~ ~
~~~ ~`'`~~~`'`~~ ~~
~ ~~~/ \~~~/ \~~~ ~
";
            Console.WriteLine(seaAscii);
        }
        public static void DisplayIsland()
        {
            string island = @"
                                                    ____
                                         v        _(    )
        _ ^ _                          v         (___(__)
       '_\V/ `                             v
       ' oX`
          X                           
          X             
          X                                                                                                     
          X                                           cool,      (_( (_(
          X.a##a.[chest]                             a chest.   (___(___(
       .aa##############a.>>                                    __|___|___
    .a######################aa.                                 \        /
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
";
            Console.WriteLine(island);
        }
        public static void DisplayEnemyShip()
        {
            string enemyShip = @"
    __|__ |___| |\
    |o__| |___| | \    we want
    |___| |___| |o \  your stuff   
   _|___| |___| |__o\
  /...\_____|___|____\_/
  \   o * o * * o o  /
~~~~~~~~~~~~~~~~~~~~~~~~~~
";
            Console.WriteLine(enemyShip);
        }

        #endregion

        //#region Scenario Objects

        //public static void ViewScenarioWeaponInventory(List<Weapon> inputInventory, List<Weapon> playerInventory)
        //{
        //    bool exitLoop = false;
        //    do
        //    {
        //        Console.WriteLine("Searching for items...");
        //        List<Weapon> weaponsToRemove = new List<Weapon>();
        //        foreach (Weapon item in inputInventory)
        //        {
        //            bool exitItemChoice = false;
        //            do
        //            {

        //                Console.WriteLine($"You found: {item.Name}\n" +
        //                    $"[1] Examine {item.Name}\n" +
        //                    $"[2] Take {item.Name}\n" +
        //                    $"[3] Leave {item.Name} where it is");
        //                ConsoleKey userChoice = Console.ReadKey(true).Key;

        //                switch (userChoice)
        //                {
        //                    case ConsoleKey.D1:
        //                    case ConsoleKey.NumPad1:
        //                        Console.Clear();
        //                        Console.WriteLine("You examine the item: " +
        //                            $"\n{item.Description}" +
        //                            $"\nChoose whether to take or leave it.");
        //                        break;

        //                    case ConsoleKey.D2:
        //                    case ConsoleKey.NumPad2:
        //                        Console.Clear();
        //                        playerInventory.Add(item);
        //                        Console.WriteLine($"{item.Name} added to your inventory.");
        //                        weaponsToRemove.Add(item);
        //                        exitItemChoice = true;
        //                        break;

        //                    case ConsoleKey.D3:
        //                    case ConsoleKey.NumPad3:
        //                        Console.Clear();
        //                        Console.WriteLine($"You leave the {item.Name} where it is.");
        //                        exitItemChoice = true;
        //                        break;

        //                    default:
        //                        Console.Clear();
        //                        Console.WriteLine($"{userChoice} was not a valid option, please choose again");
        //                        break;
        //                }//end switch

        //            } while (!exitItemChoice);

        //        }//end foreach item loop
        //        foreach (Weapon item in weaponsToRemove)
        //        {
        //            inputInventory.Remove(item);
        //        }//end removal foreach
        //        exitLoop = true;
        //    } while (!exitLoop);
        //}//end

        //public static void ViewScenarioOtherItemInventory(List<OtherObject> inputInventory, List<OtherObject> playerInventory)
        //{
        //    List<OtherObject> itemsToRemove = new List<OtherObject>();
        //    bool exitLoop = false;
        //    do
        //    {
        //        Console.WriteLine("You search for any useable items: " +
        //            "\n(Items may be equipped, read, or used from your inventory screen)\n");

        //        foreach (OtherObject @object in inputInventory)
        //        {
        //            bool exitItemChoice = false;
        //            do
        //            {

        //                Console.WriteLine($"You found: {@object.Name}\n" +
        //                    $"[1] Examine {@object.Name}\n" +
        //                    $"[2] Take {@object.Name}\n" +
        //                    $"[3] Leave {@object.Name} where it is");
        //                ConsoleKey userChoice = Console.ReadKey(true).Key;

        //                switch (userChoice)
        //                {
        //                    case ConsoleKey.D1:
        //                    case ConsoleKey.NumPad1:
        //                        Console.Clear();
        //                        Console.WriteLine("You examine the item: " +
        //                            $"\n{@object.Description}" +
        //                            $"\nChoose whether to take or leave it.");
        //                        break;

        //                    case ConsoleKey.D2:
        //                    case ConsoleKey.NumPad2:
        //                        Console.Clear();
        //                        playerInventory.Add(@object);
        //                        Console.WriteLine($"{@object.Name} added to your inventory.");
        //                        itemsToRemove.Add(@object);
        //                        exitItemChoice = true;
        //                        break;

        //                    case ConsoleKey.D3:
        //                    case ConsoleKey.NumPad3:
        //                        Console.Clear();
        //                        Console.WriteLine($"You leave the {@object.Name} where it is.");
        //                        exitItemChoice = true;
        //                        break;

        //                    default:
        //                        Console.Clear();
        //                        Console.WriteLine($"{userChoice} was not a valid option, please choose again");
        //                        break;
        //                }//end switch

        //            } while (!exitItemChoice);

        //        }//end foreach item loop
        //        foreach (OtherObject item in itemsToRemove)
        //        {
        //            inputInventory.Remove(item);
        //        }//end removal foreach
        //        exitLoop = true;
        //    } while (!exitLoop);
        //}

        //#endregion

        #region Console Beep
        public static void SeaTheme()
        {
            Console.WriteLine(@"
                            _                 _                   
                           | |               | |                  
 ___  ___  __ _    __ _  __| |_   _____ _ __ | |_ _   _ _ __ ___  
/ __|/ _ \/ _` |  / _` |/ _` \ \ / / _ \ '_ \| __| | | | '__/ _ \ 
\__ \  __/ (_| | | (_| | (_| |\ V /  __/ | | | |_| |_| | | |  __/ 
|___/\___|\__,_|  \__,_|\__,_| \_/ \___|_| |_|\__|\__,_|_|  \___| 
                                                                                              
              |    |    |
             )_)  )_)  )_)        
            )___))___))___)\      wes nelson 2021
           )____)____)_____)\\
         _____|____|____|____\\\__
---------\                   /---------
  ^^^^^ ^^^^^^^^^^^^^^^^^^^^^
    ^^^^      ^^^^     ^^^    ^^
         ^^^^      ^^^       
");

            Console.Beep(220, 500); // A Quarter
            Console.Beep(293, 750); // D Dotted Quarter
            Console.Beep(330, 250); // E Eigth
            Console.Beep(349, 500); // F Quarter
            Console.Beep(392, 500); // G Quarter
            Console.Beep(349, 500); // F Quarter
            Console.Beep(330, 500); // E Quarter
            Console.Beep(293, 750); // D Dotted Quarter
            Console.Beep(330, 250); // E Eighth
            Console.Beep(262, 500); // C Quarter
            Console.Beep(293, 125); // D Sixteenth
            Console.Beep(293, 125); // D Sixteenth
            Console.Beep(293, 125); // D Sixteenth
        }

        public static void DeathCard()
        {
            Console.WriteLine(@"
┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼
███▀▀▀██┼███▀▀▀███┼███▀█▄█▀███┼██▀▀▀
██┼┼┼┼██┼██┼┼┼┼┼██┼██┼┼┼█┼┼┼██┼██┼┼┼
██┼┼┼▄▄▄┼██▄▄▄▄▄██┼██┼┼┼▀┼┼┼██┼██▀▀▀
██┼┼┼┼██┼██┼┼┼┼┼██┼██┼┼┼┼┼┼┼██┼██┼┼┼
███▄▄▄██┼██┼┼┼┼┼██┼██┼┼┼┼┼┼┼██┼██▄▄▄
┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼
███▀▀▀███┼▀███┼┼██▀┼██▀▀▀┼██▀▀▀▀██▄┼
██┼┼┼┼┼██┼┼┼██┼┼██┼┼██┼┼┼┼██┼┼┼┼┼██┼
██┼┼┼┼┼██┼┼┼██┼┼██┼┼██▀▀▀┼██▄▄▄▄▄▀▀┼
██┼┼┼┼┼██┼┼┼██┼┼█▀┼┼██┼┼┼┼██┼┼┼┼┼██┼
███▄▄▄███┼┼┼─▀█▀┼┼─┼██▄▄▄┼██┼┼┼┼┼██▄
┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼
┼┼┼┼┼┼┼┼██┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼██┼┼┼┼┼┼┼┼┼
┼┼┼┼┼┼████▄┼┼┼▄▄▄▄▄▄▄┼┼┼▄████┼┼┼┼┼┼┼
┼┼┼┼┼┼┼┼┼▀▀█▄█████████▄█▀▀┼┼┼┼┼┼┼┼┼┼
┼┼┼┼┼┼┼┼┼┼┼█████████████┼┼┼┼┼┼┼┼┼┼┼┼
┼┼┼┼┼┼┼┼┼┼┼██▀▀▀███▀▀▀██┼┼┼┼┼┼┼┼┼┼┼┼
┼┼┼┼┼┼┼┼┼┼┼██┼┼┼███┼┼┼██┼┼┼┼┼┼┼┼┼┼┼┼
┼┼┼┼┼┼┼┼┼┼┼█████▀▄▀█████┼┼┼┼┼┼┼┼┼┼┼┼
┼┼┼┼┼┼┼┼┼┼┼┼███████████┼┼┼┼┼┼┼┼┼┼┼┼┼
┼┼┼┼┼┼┼┼▄▄▄██┼┼█▀█▀█┼┼██▄▄▄┼┼┼┼┼┼┼┼┼
┼┼┼┼┼┼┼┼▀▀██┼┼┼┼┼┼┼┼┼┼┼██▀▀┼┼┼┼┼┼┼┼┼
┼┼┼┼┼┼┼┼┼┼▀▀┼┼┼┼┼┼┼┼┼┼┼▀▀┼┼┼┼┼┼┼┼┼┼┼
┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼
");

            Console.Beep(392, 500); // G Quarter
            Console.Beep(349, 500); // F Quarter
            Console.Beep(330, 500); // E Quarter
            Console.Beep(293, 500); // D Quarter
            Console.Beep(277, 250); // Db Eigth
            Console.Beep(262, 250); // C Eigth
            Console.Beep(247, 250); // B Eigth
            Console.Beep(233, 250); // Bb Eigth
            Console.Beep(220, 1000); // A Half
        }

        public static void WinCard()
        {
            Console.WriteLine(@"
██    ██  ██████  ██    ██     ██     ██ ██ ███    ██ 
 ██  ██  ██    ██ ██    ██     ██     ██ ██ ████   ██ 
  ████   ██    ██ ██    ██     ██  █  ██ ██ ██ ██  ██ 
   ██    ██    ██ ██    ██     ██ ███ ██ ██ ██  ██ ██ 
   ██     ██████   ██████       ███ ███  ██ ██   ████                                                     
");
            Console.Beep(293, 500);
            Console.Beep(330, 750);
            Console.Beep(293, 250);
            Console.Beep(440, 1000);
        }
        #endregion

        #region Healing Methods
        public static void Heal(Being being)
        {
            being.Life = being.MaxLife;
        }
        public static void EatBread(PlayerPirate player)
        {
            player.Life += 5;
            Console.WriteLine("You ate some bread.");
        }
        #endregion      
    }
}
