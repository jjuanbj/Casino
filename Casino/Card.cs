using System;
using System.Collections.Generic;
using System.Linq;

namespace Casino
{
    class Card
    {
        public string CardName { get; set; }
        public Tuple<string, string> DisplayName { get; set; }        
        public Rank Rank { get; set; }
        public Suit Suit { get; set; }

        public Card(Rank rank, Suit suit)
        {
            CardName = rank.ToString() + " of " + suit.ToString();            

            Rank = rank;

            Suit = suit;
        }

        public Card(string cardName)
        {
            CardName = cardName;

            Rank = (Rank)Enum.Parse(typeof(Rank), cardName.Split(' ').First(), true);

            Suit = (Suit)Enum.Parse(typeof(Suit), cardName.Split(' ').Last(), true);
        }

        private void CreateDisplayName(Rank rank, Suit suit)
        {
            string displayRank = "";
            string displaySuit = "";

            switch (rank)
            {
                case Rank.Ace:
                    displayRank = "A";
                    break;
                case Rank.Two:
                    displayRank = "2";
                    break;
                case Rank.Three:
                    displayRank = "3";
                    break;
                case Rank.Four:
                    displayRank = "4";
                    break;
                case Rank.Five:
                    displayRank = "5";
                    break;
                case Rank.Six:
                    displayRank = "6";
                    break;
                case Rank.Seven:
                    displayRank = "7";
                    break;
                case Rank.Eight:
                    displayRank = "8";
                    break;
                case Rank.Nine:
                    displayRank = "9";
                    break;
                case Rank.Ten:
                    displayRank = "10";
                    break;
                case Rank.Jack:
                    displayRank = "J";
                    break;
                case Rank.Queen:
                    displayRank = "Q";
                    break;
                case Rank.King:
                    displayRank = "K";
                    break;
            }

            switch (suit)
            {
                case Suit.Club:
                    displaySuit = "♣";
                    break;
                case Suit.Diamond:
                    displaySuit = "♦";
                    break;
                case Suit.Heart:
                    displaySuit = "♥";
                    break;
                case Suit.Spade:
                    displaySuit = "♠";
                    break;
            }

            DisplayName = new Tuple<string, string>(displayRank, displaySuit);            
        }
    }
}
