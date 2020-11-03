using System;
using System.Collections.Generic;
using System.Linq;

namespace Casino
{
    class Computer : Player {

        public Computer() : base(Constants.Computer, ConsoleOutput) { }   

        public override void Play(Table table)
        {            
            string actionSelected = ChooseOneAction(table);
            Console.WriteLine("Action selected: " + actionSelected); // Test

            Card selectedCard = SelectYourCard(actionSelected, table);
            Console.Write("Computer cards: "); // Test
            Console.WriteLine(string.Format(": {0}.",
                              string.Join(", ", this.Cards
                                    .Select(c => c.CardName)))); // Test
            Console.WriteLine("Selected card: " + selectedCard.CardName); // Test

            switch (actionSelected)
            {
                case Keyboard.ONE:
                    ThrowTheCardToTheTable(selectedCard, table);
                    Console.WriteLine("ThrowTheCardToTheTable"); // Test
                    break;
                case Keyboard.TWO:
                    TakeCardFromTheTable(selectedCard, table);
            
                    Console.WriteLine("TakeCardFromTheTable"); // Test
                    break;
                case Keyboard.THREE:
                    CombineCards(selectedCard, table);
                    break;
                case Keyboard.FOUR:
                    PairCards(selectedCard, table);
                    break;
            }

            ConsoleOutput.ShowTableCards(table);
        }        

        private string ChooseOneAction(Table table)
        {
            string actionSelected = "";
            
            if (table.Cards.Any(x => this.Cards.Any(y => y.Rank == x.Rank)) 
            || (table.BuildedCards != null 
             && table.BuildedCards.Any(x => this.Cards.Any(y => y.Rank == x.BuildedCardsRank))))
            {
                actionSelected = Keyboard.TWO;                                                
            } else
            {
                actionSelected = Keyboard.ONE;
            }           

            return actionSelected;
        }

        private Card SelectYourCard(String actionSelected, Table table)
        {            
            Card selectedCard = null;            

            if (actionSelected == Keyboard.ONE)
            {                
                selectedCard = this.Cards.OrderBy(c => c.Rank).FirstOrDefault();                

            } else if (actionSelected == Keyboard.TWO)
            {   
                if (this.Cards.Where(a => table.Cards
                              .Any(b => a.Rank == b.Rank))
                              .OrderBy(a => a.Rank)
                              .Any())
                {
                    selectedCard = this.Cards.Where(a => table.Cards
                                             .Any(b => a.Rank == b.Rank))
                                             .OrderBy(a => a.Rank)
                                             .FirstOrDefault();                    
                } else
                {
                    selectedCard = this.Cards.Where(a => table.BuildedCards
                                             .Any(b => a.Rank == b.BuildedCardsRank))
                                             .OrderBy(a => a.Rank)
                                             .FirstOrDefault();
                }                    
                
                Console.WriteLine(selectedCard.CardName);             
            }

            return selectedCard;
        }

        public override void ThrowTheCardToTheTable(Card selectedCard, Table table)
        {
            table.Cards.Add(selectedCard);
            
            Cards.RemoveAll(c => c.CardName == selectedCard.CardName);
        }

        public override void TakeCardFromTheTable(Card selectedCard, Table table) 
        {
            List<Card> capturedCards = new List<Card>();

            if (table.Cards.Where(c => c.Rank == selectedCard.Rank).Any() 
            && (table.BuildedCards != null 
            &&  table.BuildedCards.Any(x => this.Cards.Any(y => y.Rank == x.BuildedCardsRank))))
            {
                capturedCards = table.Cards.Where(c => c.Rank == selectedCard.Rank).ToList();    

                foreach (Card card in capturedCards)
                {
                    table.Cards.RemoveAll(c => c.CardName == card.CardName);
                }

                List<Card> capturedBuildedCards = new List<Card>();
                capturedBuildedCards = table.BuildedCards.Where(c => c.BuildedCardsRank == selectedCard.Rank)
                                                         .SelectMany(b => b.BuildedCards)
                                                         .ToList();

                foreach (Card card in capturedCards)
                {
                    table.BuildedCards.Where(c => c.BuildedCardsRank == selectedCard.Rank)
                                      .Select(b => b.BuildedCards
                                      .RemoveAll(d => d.CardName == card.CardName));
                }

                table.BuildedCards.Remove(table.BuildedCards
                                  .Where(c => c.BuildedCardsRank == selectedCard.Rank)
                                  .FirstOrDefault());

                foreach (Card card in capturedBuildedCards)
                {
                    capturedCards.Add(card);
                }
                
            } else if (table.Cards.Where(c => c.Rank == selectedCard.Rank).Any())
            {
                capturedCards = table.Cards.Where(c => c.Rank == selectedCard.Rank).ToList();    

                foreach (Card card in capturedCards)
                {
                    table.Cards.RemoveAll(c => c.CardName == card.CardName);
                }

            } else
            {
                capturedCards = table.BuildedCards.Where(c => c.BuildedCardsRank == selectedCard.Rank)
                                                  .SelectMany(b => b.BuildedCards)
                                                  .ToList();

                foreach (Card card in capturedCards)
                {
                    table.BuildedCards.Where(c => c.BuildedCardsRank == selectedCard.Rank)
                                      .Select(b => b.BuildedCards
                                      .RemoveAll(c => c.CardName == card.CardName));                                                                      
                }

                table.BuildedCards.Remove(table.BuildedCards
                                  .Where(c => c.BuildedCardsRank == selectedCard.Rank)
                                  .FirstOrDefault());
            }
            
            Cards.RemoveAll(c => c.CardName == selectedCard.CardName);

            CapturedCards = capturedCards;
            CapturedCards.Add(selectedCard);            
        }

        public override void CombineCards(Card selectedCard, Table table) { }

        public override void PairCards(Card selectedCard, Table table) { }
    }
}
