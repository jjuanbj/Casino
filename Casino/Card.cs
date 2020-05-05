using System;
using System.Collections.Generic;
using System.Text;

namespace Casino
{
    class Card
    {
        public Suit Suit { get; set; }
        public Rank Rank { get; set; }

        public Card(Suit suit, Rank rank)
        {
            Suit = suit;

            Rank = rank;
        }
    }
}
