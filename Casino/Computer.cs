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

            Card card = SelectYourCard(actionSelected, table);
            
            switch (actionSelected)
            {
                case Keyboard.ONE:
                    ThrowTheCardToTheTable(card, table);
                    break;
                case Keyboard.TWO:
                    TakeCardFromTheTable(card, table);
                    break;
                case Keyboard.THREE:
                    CombineCards(card, table);
                    break;
                case Keyboard.FOUR:
                    PairCards(card, table);
                    break;
            }

            ConsoleOutput.ShowTableCards(table);
        }        

        private string ChooseOneAction(Table table)
        {
            string actionSelected = "";
            
            if (!table.Cards.Any(x => this.Cards.Any(y => y.Rank == x.Rank)) 
             && (table.BuildedCards != null 
             && !table.BuildedCards.Any(x => this.Cards.Any(y => y.Rank == x.BuildedCardsRank))))
            {
                actionSelected = Keyboard.TWO;                
            }           

            return actionSelected;
        }

        private Card SelectYourCard(String actionSelected, Table table)
        {            
            Card card = null;            

            if (actionSelected == Keyboard.ONE)
            {                
                card = this.Cards.OrderBy(c => c.Rank).FirstOrDefault();                

            } else if (actionSelected == Keyboard.TWO)
            {
                List<Card> cards = new List<Card>();
                cards = this.Cards.Where(a => table.Cards.Any(b => a.Rank == b.Rank)).ToList(); //Test
            }

            return card;
        }

        public override void ThrowTheCardToTheTable(Card card, Table table)
        {
            table.Cards.Add(card);
            Cards.RemoveAll(c => c.CardName == card.CardName);
        }

        public override void TakeCardFromTheTable(Card selectedCard, Table table) { }

        public override void CombineCards(Card selectedCard, Table table) { }

        public override void PairCards(Card selectedCard, Table table) { }
    }
}