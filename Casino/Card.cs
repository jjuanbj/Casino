using System;
using System.Collections.Generic;
using System.Linq;

namespace Casino
{
    class Card
    {        
        public string Name { get; set; }        
        public Rank Rank { get; set; }
        public Suit Suit { get; set; }

        public Card(Rank rank, Suit suit)
        {
            Rank = rank;

            Suit = suit;

            CreateName(rank, suit);            
        }

        private void CreateName(Rank rank, Suit suit)
        {
            Name = CardUtils.CreateRankName(rank);

            switch (suit)
            {
                case Suit.Club:
                    Name = string.Concat(Name, "♣");
                    break;
                case Suit.Diamond:
                    Name = string.Concat(Name, "♦");
                    break;
                case Suit.Heart:
                    Name = string.Concat(Name, "♥");
                    break;
                case Suit.Spade:
                    Name = string.Concat(Name, "♠");
                    break;
            }
        }
    }
}
