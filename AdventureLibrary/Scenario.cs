using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureLibrary
{
    public class Scenario
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Weapon> ScenarioDrop { get; set; }
        public List<OtherObject> OtherDrop { get; set; }
        public bool IsCurrentScenario { get; set; }
        public bool IsEnemyDead { get; set; }
        public bool IsScenarioComplete { get; set; }

        public Scenario(string name, string description, List<Weapon> scenarioDrop, List<OtherObject> otherDrop, bool isCurrentScenario, bool isEnemyDead, bool isScenarioComplete)
        {
            IsEnemyDead = isEnemyDead;
            Name = name;
            Description = description;
            ScenarioDrop = scenarioDrop;
            OtherDrop = otherDrop;
            IsCurrentScenario = isCurrentScenario;
            IsScenarioComplete = isScenarioComplete;
        }

        public override string ToString()
        {
            return string.Format($"{Name}\n*****\n{Description}");
        }
    }//class
}
