using System;
using System.Collections.Generic;
using System.Linq;

namespace Casino
{
    class Computer : Player {
        
        public new static ConsoleOutput ConsoleOutput { get; set; }

        public Computer() : base(Constants.Computer, ConsoleOutput) { }   

        public override void Play(Table table)
        {
            Card card = SelectYourCard();

            string actionSelected = ChooseOneAction(table);

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

        public override Card SelectYourCard()
        {            
            Card card = null;
 
            return card;
        }

        private string ChooseOneAction(Table table)
        {
            string actionSelected = "";

            return actionSelected;
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