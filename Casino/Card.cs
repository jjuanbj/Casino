using System;
using System.Collections.Generic;
using System.Linq;

namespace Casino
{
    class Card
    {
        public string CardName { get; set; }
        public string DisplayName { get; set; }        
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
            switch (suit)
            {
                case Suit.Club:
                    DisplayName = "♣";
                    break;
                case Suit.Diamond:
                    DisplayName = "♦";
                    break;
                case Suit.Heart:
                    DisplayName = "♥";
                    break;
                case Suit.Spade:
                    DisplayName = "♠";
                    break;
            }

            switch (rank)
            {
                case Rank.Ace:
                    DisplayName = String.Concat(DisplayName, "A");
                    break;
                case Rank.Two:
                    DisplayName = String.Concat(DisplayName, "2");
                    break;
                case Rank.Three:
                    DisplayName = String.Concat(DisplayName, "3");
                    break;
                case Rank.Four:
                    DisplayName = String.Concat(DisplayName, "4");
                    break;
                case Rank.Five:
                    DisplayName = String.Concat(DisplayName, "5");
                    break;
                case Rank.Six:
                    DisplayName = String.Concat(DisplayName, "6");
                    break;
                case Rank.Seven:
                    DisplayName = String.Concat(DisplayName, "7");
                    break;
                case Rank.Eight:
                    DisplayName = String.Concat(DisplayName, "8");
                    break;
                case Rank.Nine:
                    DisplayName = String.Concat(DisplayName, "9");
                    break;
                case Rank.Ten:
                    DisplayName = String.Concat(DisplayName, "10");
                    break;
                case Rank.Jack:
                    DisplayName = String.Concat(DisplayName, "J");
                    break;
                case Rank.Queen:
                    DisplayName = String.Concat(DisplayName, "Q");
                    break;
                case Rank.King:
                    DisplayName = String.Concat(DisplayName, "K");
                    break;
            }            
        }
    }
}
