using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureLibrary
{
    public class Object
    {
        public string Name { get; set; }
        public string Description { get; set; }

        // Full And Qualified Constructor!
        public Object(string name, string description)
        {
            Name = name;
            Description = description;
        }// end

        // Override here
        public override string ToString()
        {
            return string.Format($"Object: {Name}/nDescription: {Description}");
        }
    }
}
