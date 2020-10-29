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

            Card selectedCard = SelectYourCard(actionSelected, table);
            
            switch (actionSelected)
            {
                case Keyboard.ONE:
                    ThrowTheCardToTheTable(selectedCard, table);
                    break;
                case Keyboard.TWO:
                    TakeCardFromTheTable(selectedCard, table);
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
             && (table.BuildedCards != null 
             && table.BuildedCards.Any(x => this.Cards.Any(y => y.Rank == x.BuildedCardsRank))))
            {
                actionSelected = Keyboard.TWO;                                
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
                selectedCard = this.Cards.Where(a => table.Cards
                                         .Any(b => a.Rank == b.Rank))
                                         .OrderBy(a => a.Rank)
                                         .FirstOrDefault();                
            }

            return selectedCard;
        }

        public override void ThrowTheCardToTheTable(Card card, Table table)
        {
            table.Cards.Add(card);
            Cards.RemoveAll(c => c.CardName == card.CardName);
        }

        public override void TakeCardFromTheTable(Card selectedCard, Table table) 
        {
            List<Card> capturedCards = new List<Card>();
            capturedCards = table.Cards.Where(c => c.Rank == selectedCard.Rank).ToList();

            foreach (Card tableCards in capturedCards)
            {
                table.Cards.Remove(tableCards);
            }

            this.CapturedCards = capturedCards;
            this.CapturedCards.Add(selectedCard);            
        }

        public override void CombineCards(Card selectedCard, Table table) { }

        public override void PairCards(Card selectedCard, Table table) { }
    }
}
