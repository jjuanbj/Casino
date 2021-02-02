using System;
using System.Collections.Generic;
using System.Linq;

namespace Casino
{
    class Card
    {
        // TODO: unify CardName and Name
        public string CardName { get; set; }
        public string Name { get; set; }        
        public Rank Rank { get; set; }
        public Suit Suit { get; set; }

        public Card(Rank rank, Suit suit)
        {
            CardName = rank.ToString() + " of " + suit.ToString();            

            Rank = rank;

            Suit = suit;

            CreateName(rank, suit);
        }

        public Card(string cardName)
        {
            CardName = cardName;

            Rank = (Rank)Enum.Parse(typeof(Rank), cardName.Split(' ').First(), true);

            Suit = (Suit)Enum.Parse(typeof(Suit), cardName.Split(' ').Last(), true);

            CreateName(Rank, Suit);
        }

        private string CreateName(Rank rank, Suit suit)
        {
            string rankSuit = null;

            switch (rank)
            {
                case Rank.Ace:
                    Name = "A";
                    rankSuit = nameof(Rank.Ace);
                    break;
                case Rank.Two:
                    Name = "2";
                    rankSuit = nameof(Rank.Two);
                    break;
                case Rank.Three:
                    Name = "3";
                    rankSuit = nameof(Rank.Three);
                    break;
                case Rank.Four:
                    Name = "4";
                    rankSuit = nameof(Rank.Four);
                    break;
                case Rank.Five:
                    Name = "5";
                    rankSuit = nameof(Rank.Five);
                    break;
                case Rank.Six:
                    Name = "6";
                    rankSuit = nameof(Rank.Six);
                    break;
                case Rank.Seven:
                    Name = "7";
                    rankSuit = nameof(Rank.Seven);
                    break;
                case Rank.Eight:
                    Name = "8";
                    rankSuit = nameof(Rank.Eight);
                    break;
                case Rank.Nine:
                    Name = "9";
                    rankSuit = nameof(Rank.Nine);
                    break;
                case Rank.Ten:
                    Name = "10";
                    rankSuit = nameof(Rank.Ten);
                    break;
                case Rank.Jack:
                    Name = "J";
                    rankSuit = nameof(Rank.Jack);
                    break;
                case Rank.Queen:
                    Name = "Q";
                    rankSuit = nameof(Rank.Queen);
                    break;
                case Rank.King:
                    Name = "K";
                    rankSuit = nameof(Rank.King);
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

            return rankSuit;
        }
    }
}
