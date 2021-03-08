using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureLibrary
{
   public abstract class Being
    {
        private string _name;
        private int _life;

        public int MaxLife { get; set; }
        public int Accuracy { get; set; }
        public int Defense { get; set; }
        public bool IsChat { get; set; }

        public string Name
        {
            get { return _name; }
            set { _name = value.Trim(); }
        }//end
        
        public int Life
        {
            get { return _life; }
            set
            {
                _life = value <= MaxLife ? value : MaxLife;
            }//end set
        }//end

        public Being(string name, int life, int maxLife, int accuracy, int defense, bool isChat)
        {
            MaxLife = maxLife;
            Name = name;
            Life = life;
            Accuracy = accuracy;
            Defense = defense;
            IsChat = isChat;
        }//end Full and Qualified

        public virtual int CalcDefense()
        {
            return Defense;
        }//end

        public virtual int CalcAccuracy()
        {
            return Accuracy;
        }//end

        public abstract int CalcDamage();
    }
}
