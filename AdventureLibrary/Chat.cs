using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureLibrary
{
    public class Chat
    {
        public string Message { get; set; }

        public Chat(string message)
        {
            Message = message;
        }

        public override string ToString()
        {
            return $"{Message}";
        }
    }

    
}
