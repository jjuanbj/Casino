using System;
using System.Collections.Generic;
using System.Linq;

namespace Casino
{
    class Card
    {
        public string CardName { get; set; }
        public string Name { get; set; }        
        public Rank Rank { get; set; }
        public Suit Suit { get; set; }

        public Card(Rank rank, Suit suit)
        {
            CardName = rank.ToString() + " of " + suit.ToString();            

            Rank = rank;

            Suit = suit;

            CreateDisplayName(rank, suit);
        }

        public Card(string cardName)
        {
            CardName = cardName;

            Rank = (Rank)Enum.Parse(typeof(Rank), cardName.Split(' ').First(), true);

            Suit = (Suit)Enum.Parse(typeof(Suit), cardName.Split(' ').Last(), true);

            CreateDisplayName(Rank, Suit);
        }

        private void CreateDisplayName(Rank rank, Suit suit)
        {
            switch (rank)
            {
                case Rank.Ace:
                    Name = "A";
                    break;
                case Rank.Two:
                    Name = "2";
                    break;
                case Rank.Three:
                    Name = "3";
                    break;
                case Rank.Four:
                    Name = "4";
                    break;
                case Rank.Five:
                    Name = "5";
                    break;
                case Rank.Six:
                    Name = "6";
                    break;
                case Rank.Seven:
                    Name = "7";
                    break;
                case Rank.Eight:
                    Name = "8";
                    break;
                case Rank.Nine:
                    Name = "9";
                    break;
                case Rank.Ten:
                    Name = "10";
                    break;
                case Rank.Jack:
                    Name = "J";
                    break;
                case Rank.Queen:
                    Name = "Q";
                    break;
                case Rank.King:
                    Name = "K";
                    break;
            }

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
