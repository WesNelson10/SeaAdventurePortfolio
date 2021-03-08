using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventureLibrary;

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
            Console.WriteLine(starterSword);
        }
    }
}
