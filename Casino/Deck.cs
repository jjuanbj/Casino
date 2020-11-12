using System;
using System.Collections.Generic;
using System.Linq;

namespace Casino
{
    class Deck
    {
        public List<Card> DeckCards { get; set; }

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
            foreach (var player in Players.Where(p => p.Name != Constants.Computer))
            {                
                player.Cards = DeckCards.Take((int)General.NumberCardsToDeal).ToList();
                
                #region Test
                player.Cards.Add(new Card("King of Heart"));
                player.Cards.Add(new Card("Six of Heart"));
                #endregion
                
                DeckCards.RemoveRange((int)General.Zero, (int)General.NumberCardsToDeal);
            }
            
            foreach (var player in Players.Where(p => p.Name == Constants.Computer))
            {                
                player.Cards = DeckCards.Take((int)General.NumberCardsToDeal).ToList();                

                DeckCards.RemoveRange((int)General.Zero, (int)General.NumberCardsToDeal);                            
            }
        }
        
        public void DealCardsTable(Table table)
        {
            table.Cards = DeckCards.Take((int)General.NumberCardsToDeal).ToList();

            #region Test
            
            List<Card> listCards = new List<Card>();
            listCards.Add(new Card("Seven of Diamond"));
            listCards.Add(new Card("Five of Heart"));
            listCards.Add(new Card("Ace of Diamond"));
            listCards.Add(new Card("Nine of Heart"));

            BuildedCard builded = new BuildedCard();
            builded.BuildedCards = listCards;
            builded.BuildedCardsRank = Rank.Queen;
            builded.IsPair = false;
            
            List<Card> listCards1 = new List<Card>();
            listCards1.Add(new Card("Three of Diamond"));
            listCards1.Add(new Card("Four of Heart"));
            
            BuildedCard builded1 = new BuildedCard();
            builded1.BuildedCards = listCards1;
            builded1.BuildedCardsRank = Rank.Seven;
            builded1.IsPair = false;
            
            List<Card> listCards2 = new List<Card>();
            listCards2.Add(new Card("Six of Diamond"));
            listCards2.Add(new Card("Six of Heart"));
            
            BuildedCard builded2 = new BuildedCard();
            builded2.BuildedCards = listCards2;
            builded2.BuildedCardsRank = Rank.Six;
            builded2.IsPair = true;

            List<BuildedCard> listBuildedCards = new List<BuildedCard>();
            listBuildedCards.Add(builded);
            listBuildedCards.Add(builded1);
            listBuildedCards.Add(builded2);

            table.BuildedCards = listBuildedCards;
            
            table.Cards.Add(new Card("Queen of Diamond"));
            table.Cards.Add(new Card("Five of Heart"));
            table.Cards.Add(new Card("Nine of Heart"));
            table.Cards.Add(new Card("Four of Heart"));
            table.Cards = listCards;

            #endregion

            DeckCards.RemoveRange((int)General.Zero, (int)General.NumberCardsToDeal);
        }
    }
}
