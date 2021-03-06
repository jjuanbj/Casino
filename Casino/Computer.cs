using System;
using System.Collections.Generic;
using System.Linq;

namespace Casino
{
    class Computer : Player {

        public Computer() : base(Constants.COMPUTER, ConsoleOutput) { }   

        public override void Play(Table table)
        {            
            string actionSelected = ChooseOneAction(table);
            Console.WriteLine("Action selected: " + actionSelected); // Test

            Card selectedCard = SelectYourCard(actionSelected, table);            
        
            Console.WriteLine("Selected card: " + selectedCard.Name); // Test

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
                    CreateSingleBuildCards(selectedCard, table);
                    break;
                case Keyboard.FOUR:
                    CreateMultipleBuildCards(selectedCard, table);
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
                List<Card> computerCards = this.Cards.ToList();
                List<Card> valuableComputerCards = new List<Card>();
                
                foreach (var card in this.Cards)
                {
                    switch (card.Rank)
                    {
                        case Rank.Ace:
                            valuableComputerCards.AddRange(computerCards.Where(c => c.Rank == Rank.Ace));
                            computerCards.RemoveAll(c => c.Rank == Rank.Ace);                            
                            break;
                        case Rank.Ten when card.Suit == Suit.Diamond:
                            valuableComputerCards.Add(card);
                            computerCards.RemoveAll(c => c.Rank == Rank.Ten && c.Suit == Suit.Diamond);
                            break;
                        case Rank.Two when card.Suit == Suit.Spade:
                            valuableComputerCards.Add(card);
                            computerCards.RemoveAll(c => c.Rank == Rank.Two && c.Suit == Suit.Spade);
                            break;                        
                    }
                }

                selectedCard = computerCards.Any() ? computerCards.OrderBy(c => c.Rank).FirstOrDefault()
                                                   : valuableComputerCards.OrderBy(c => c.Rank).FirstOrDefault();                

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
                
                Console.WriteLine(selectedCard.Name);             
            }

            return selectedCard;
        }

        public override void ThrowTheCardToTheTable(Card selectedCard, Table table)
        {
            table.Cards.Add(selectedCard);
            
            Cards.RemoveAll(c => c.Name == selectedCard.Name);
        }

        public override bool TakeCardFromTheTable(Card selectedCard, Table table) 
        {
            List<Card> capturedCards = new List<Card>();

            if (table.Cards.Where(c => c.Rank == selectedCard.Rank).Any() 
            && (table.BuildedCards != null 
            &&  table.BuildedCards.Any(x => this.Cards.Any(y => y.Rank == x.BuildedCardsRank))))
            {
                capturedCards = table.Cards.Where(c => c.Rank == selectedCard.Rank).ToList();

                capturedCards.ForEach(card => table.Cards
                             .RemoveAll(c => c.Name == card.Name));

                List<Card> capturedBuildedCards = new List<Card>();
                capturedBuildedCards = table.BuildedCards.Where(c => c.BuildedCardsRank == selectedCard.Rank)
                                                         .SelectMany(b => b.BuildedCards)
                                                         .ToList();

                capturedCards.ForEach(card => table.BuildedCards
                             .Where(c => c.BuildedCardsRank == selectedCard.Rank)
                             .Select(b => b.BuildedCards
                             .RemoveAll(d => d.Name == card.Name)));

                table.BuildedCards.Remove(table.BuildedCards
                                  .Where(c => c.BuildedCardsRank == selectedCard.Rank)
                                  .FirstOrDefault());

                capturedBuildedCards.ForEach(card => capturedCards.Add(card));

            } else if (table.Cards.Where(c => c.Rank == selectedCard.Rank).Any())
            {
                capturedCards = table.Cards.Where(c => c.Rank == selectedCard.Rank).ToList();

                capturedCards.ForEach(card => table.Cards
                             .RemoveAll(c => c.Name == card.Name));
            } else
            {
                capturedCards = table.BuildedCards.Where(c => c.BuildedCardsRank == selectedCard.Rank)
                                                  .SelectMany(b => b.BuildedCards)
                                                  .ToList();

                capturedCards.ForEach(card => table.BuildedCards
                             .Where(c => c.BuildedCardsRank == selectedCard.Rank)
                             .Select(b => b.BuildedCards
                             .RemoveAll(c => c.Name == card.Name)));

                table.BuildedCards.Remove(table.BuildedCards
                                  .Where(c => c.BuildedCardsRank == selectedCard.Rank)
                                  .FirstOrDefault());
            }
            
            Cards.RemoveAll(c => c.Name == selectedCard.Name);
            
            CapturedCards.Add(selectedCard);

            return false;
        }

        public override void CreateSingleBuildCards(Card selectedCard, Table table) { }

        public override void CreateMultipleBuildCards(Card selectedCard, Table table) { }
    }
}
