using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureLibrary
{
    public class PlayerPirate : Being
    {
        int KillCount { get; set; }
        public PirateOption PirateOption { get; set; }
        public Weapon EquippedWeapon { get; set; }
        public List<Weapon> WeaponInventory { get; set; }
        public List<OtherObject> OtherInventory { get; set; }

        public PlayerPirate(string name, int life, int maxLife, int accuracy, int defense, bool isChat, int killCount, PirateOption pirateOption, Weapon equippedWeapon, List<Weapon> weaponInventory, List<OtherObject> otherInventory, bool isFoeAlive) : base(name, life, maxLife, accuracy, defense, isChat)
        {
            KillCount = killCount;
            PirateOption = PirateOption;
            EquippedWeapon = equippedWeapon;
            WeaponInventory = weaponInventory;
            OtherInventory = otherInventory;
            isFoeAlive = true;

            switch (PirateOption)
            {
                case PirateOption.Corsair:
                    Accuracy += 10;
                    break;
                case PirateOption.Buccaneer:
                    Defense += 10;
                    break;
                case PirateOption.Privateer:
                    MaxLife += 4;
                    Accuracy += 4;
                    break;
            }//end switch
        }

        public override string ToString()
        {
            return string.Format($"Pirate Name: {Name}\nPirate Type: {PirateOption}\nHealth: {Life}/{MaxLife}\nKills: {KillCount}\nAccuracy: {CalcAccuracy()}% (Hit Chance)\nDefense: {Defense}% (Chance to evade an ememy attack)\nEquipped Weapon: {EquippedWeapon.Name}");
        }//end ToString

        public override int CalcAccuracy()
        {
            return Accuracy + EquippedWeapon.AccuracyMod;
        }

        public override int CalcDamage()
        {
            Random rand = new Random();
            int damage = rand.Next(EquippedWeapon.MinDamage, EquippedWeapon.MaxDamage + 1);
                return damage;
        }
    }
}
