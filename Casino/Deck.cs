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

        // Dealing with Ace cards value
        
        /*public void DealCardsPlayer(List<Player> Players)
        {
            foreach (var player in Players)
            {                
                player.Cards = DeckCards.Take((int)General.NumberCardsToDeal).ToList();
                DeckCards.RemoveRange((int)General.Zero, (int)General.NumberCardsToDeal);
            }
        }*/

        public void DealCardsPlayer(List<Player> Players)
        {
            List<Card> card = new List<Card>();

            foreach (var item in Players)
            {
                if (item.Name == "Juan")
                {
                    Console.WriteLine("Hola");
                    Console.WriteLine("Prueba: " + DeckCards.ElementAt(1).CardName);
                    Console.WriteLine("Prueba 2: " + DeckCards.Where(c => c.CardName == "Four of Club").FirstOrDefault().CardName);
                    
                    Card card1 = DeckCards.Where(c => c.CardName == "Four of Club").FirstOrDefault();
                    Console.WriteLine("Prueba 3: " + card1.CardName);

                    var rankValue = Enum.GetValues(typeof(Rank));
                    var suitValue = Enum.GetValues(typeof(Suit));

                    List<Card> DeckCards2 = new List<Card>();


                    DeckCards2.Add(new Card(Rank.Ace, Suit.Diamond));
                    
                    item.Cards = DeckCards2;
                    item.Cards.Add(DeckCards.Where(c => c.CardName == "Four of Club").FirstOrDefault());
                    /*item.Cards.Add(DeckCards.Where(c => c.CardName == "Club of Five").FirstOrDefault());
                    item.Cards.Add(DeckCards.Where(c => c.CardName == "Club of Seven").FirstOrDefault());*/
                }
            }
        }

        public void DealCardsTable(Table table)
        {
            table.Cards = DeckCards.Take((int)General.NumberCardsToDeal).ToList();
            DeckCards.RemoveRange((int)General.Zero, (int)General.NumberCardsToDeal);
        }
    }
}
