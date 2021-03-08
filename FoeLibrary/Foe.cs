using System;
using AdventureLibrary;

namespace FoeLibrary
{
    public class Foe : Being
    {
        public string Description { get; set; }
        public int MinDamage { get; set; }
        public int MaxDamage { get; set; }

        public Foe(string name, int life, int maxLife, int accuracy, int defense, bool isChat, string description, int minDamage, int maxDamage) : base(name, life, maxLife, accuracy, defense, isChat)
        {
            Description = description;
            MinDamage = minDamage;
            MaxDamage = maxDamage;
        }//end

        public override string ToString()
        {
            return string.Format($"{Name}\n{Description}\n{(Life == MaxLife ? "Enemy at full strength." : Life >= MaxLife / 2 ? "Enemy is slightly harmed." : "Enemy very weak.")}");
        }

        public override int CalcDamage()
        {
            return new Random().Next(MinDamage, MaxDamage + 1);
        }
    }
}
