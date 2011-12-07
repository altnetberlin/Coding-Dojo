using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tennis
{
    public class Player
    {
        public Player(string name)
        {
            // TODO: Complete member initialization
            this.Name = name;
        }

        public string Name { get; set; }
        public Points Points { get; set; } 
     

        /*public static Player operator ++(Player player)
        {
            
            return 
        }*/
    }
}
