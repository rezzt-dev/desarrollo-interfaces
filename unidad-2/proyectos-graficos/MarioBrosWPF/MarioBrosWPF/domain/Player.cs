using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioBrosWPF.domain
{
    public class Player
    {
        public string name { get; set; }
        public int posI { get; set; }
        public int posJ { get; set; }
        public int lifes { get; set; }
        public int potions { get; set; }

        public Player(string name) { 
            this.name = name;
            posI = 0;
            posJ = 0;
            lifes = 3;
            potions = 0;
        }
    }
}
