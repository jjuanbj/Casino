using System;
using System.Collections.Generic;
using System.Text;

namespace Casino
{
    class Player
    {
        public string Name { get; set; }
        public List<Card> Cards { get; set; }

        public Player(string name) {
            Name = name;
        }
    }
}
