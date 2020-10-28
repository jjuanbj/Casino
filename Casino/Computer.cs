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

            Card card = SelectYourCard(actionSelected);

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
        }        

        private string ChooseOneAction(Table table)
        {
            string actionSelected = "";
            
            if (!table.Cards.Any(x => this.Cards.Any(y => y.Rank == x.Rank)) 
             && (table.BuildedCards != null 
             && !table.BuildedCards.Any(x => this.Cards.Any(y => y.Rank == x.BuildedCardsRank))))
            {
                actionSelected = Keyboard.TWO;
                Console.WriteLine("Test this");
            }           

            return actionSelected;
        }

        private Card SelectYourCard(String actionSelected)
        {            
            Card card = null;            

            if (actionSelected == Keyboard.TWO)
            {
                // Return the card with minimum rank (but no Ace, unless it is the only card in computer)
                card = this.Cards.Min();
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