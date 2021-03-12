using System;
using System.Collections.Generic;
using System.Text;
using AdventureLibrary;

namespace FoeLibrary
{
    public class Combat
    {
        public static void Attack(Being attacker, Being defender)
        {
            Random diceRoll = new Random();
            int result = diceRoll.Next(1, 101);
            //Sleep to allow random results
            System.Threading.Thread.Sleep(35);

            if (result <= attacker.CalcAccuracy() - defender.CalcDefense())
            {
                int damageDealt = attacker.CalcDamage();
                defender.Life -= damageDealt;
                Display.Red($"{attacker.Name} hit {defender.Name} for {damageDealt} points of damage.");
            }//end if
            else
            {
                Console.WriteLine($"{attacker.Name} missed!");
            }//end else
        }//end attack

        public static void Battle(PlayerPirate player, Foe foe)
        {
            Attack(player, foe);
            if (foe.Life > 0)
            {
                Attack(foe, player);
            }//end reply attack
        }//end battle

        
    }
}
