using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureLibrary
{
    public class Scenario
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsCurrentScenario { get; set; }
        public bool IsEnemyDead { get; set; }
        public bool IsScenarioComplete { get; set; }

        public Scenario(string name, string description, bool isCurrentScenario, bool isEnemyDead, bool isScenarioComplete)
        {
            IsEnemyDead = isEnemyDead;
            Name = name;
            Description = description;
            IsCurrentScenario = isCurrentScenario;
            IsScenarioComplete = isScenarioComplete;
        }

        public override string ToString()
        {
            return string.Format($"{Name}\n*****\n{Description}");
        }
    }//class
}
