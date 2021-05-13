using System;

namespace AdventureLibrary
{
    public class Weapon : Object
    {
        public WeaponType WeaponType { get; set; }
        public int AccuracyMod { get; set; }
        public int MinDamage { get; set; }
        public int MaxDamage { get; set; }

        //Contruct It!
        public Weapon(string name, string description, WeaponType weaponType, int accuracyMod, int minDamage, int maxDamage) : base(name, description)
        {
            WeaponType = weaponType;
            AccuracyMod = accuracyMod;
            MinDamage = minDamage;
            MaxDamage = maxDamage;
        }

        //ToString()
        public override string ToString()
        {
            return string.Format($"Weapon Accuracy Modifier: {AccuracyMod}%\nDamage: {MinDamage} to {MaxDamage}");
        }
    }
}
