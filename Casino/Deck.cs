using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Casino
{
    class Deck
    {
        private List<Card> DeckCards { get; set; }

        public void CreateCards()
        {            
            var rankValue = Enum.GetValues(typeof(Rank));
            var suitValue = Enum.GetValues(typeof(Suit));

            DeckCards = new List<Card>();

            foreach (Suit suit in suitValue)
            {
                foreach (Rank rank in rankValue)
                {
                    DeckCards.Add(new Card(rank, suit));
                }
            }            
        }

        public void ShuffleCards()
        {
            var shuffledCards = new List<Card>();
            
            for (int i = 0; i < (int)General.TotalCards; i++)
            {
                Random random = new Random();
                int index = random.Next(DeckCards.Count);
                shuffledCards.Add(DeckCards[index]);
                DeckCards.RemoveAt(index);
            }

            DeckCards = shuffledCards;           
        }

        public void DealCardsPlayer(List<Player> Players)
        {
            foreach (var player in Players)
            {                
                player.Cards = DeckCards.Take((int)General.NumberCardsToDeal).ToList();
                DeckCards.RemoveRange((int)General.Zero, (int)General.NumberCardsToDeal);

                // Dealing with Ace cards rank
                if (player.Name == "Juan")
                {
                    player.Cards.Add(new Card(Rank.Ace, Suit.Diamond));
                }
            }            
        }
        
        public void DealCardsTable(Table table)
        {
            table.Cards = DeckCards.Take((int)General.NumberCardsToDeal).ToList();
            DeckCards.RemoveRange((int)General.Zero, (int)General.NumberCardsToDeal);

            // Dealing with Ace cards value
            table.Cards.Add(new Card(Rank.Ace, Suit.Club));
        }
    }
}
