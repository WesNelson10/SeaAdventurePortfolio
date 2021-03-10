using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureLibrary
{
    public class OtherObject : Object
    {
        public bool IsAvailable { get; set; }

        public OtherObject(string name, string description, bool isAvailable) : base(name, description)
        {
            IsAvailable = isAvailable;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
