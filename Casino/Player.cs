using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Casino
{
    class Player
    {
        public string Name { get; set; }
        public List<Card> Cards { get; set; }
        public ConsoleOutput ConsoleOutput { get; set; }

        public Player(string name, ConsoleOutput consoleOutput) {
            Name = name;
            ConsoleOutput = consoleOutput;
        }

        public void Play(Table table, Player player)
        {
            Card card = SelectYourCard();
            Action(card, table, player);
        }

        private Card SelectYourCard()
        {            
            
            ConsoleOutput.SelectOneCardByIndexNumber(this);            

            string cardNumber = Console.ReadLine().Trim();
            Card card = null;

            while (card == null)
            {
                if (!String.IsNullOrEmpty(cardNumber)
                && cardNumber.All(char.IsDigit)
                && Enumerable.Range((int)General.Zero, Cards.Count).Contains(Int32.Parse(cardNumber)))
                {
                    ConsoleOutput.YouSelected(this.Cards, cardNumber);

                    card = new Card(Cards.ElementAt(Int32.Parse(cardNumber)).CardName);
                }
                else
                {
                    ConsoleOutput.TypeValidCardNumber();
                }
            }
            return card;
        }

        private void Action(Card card, Table table, Player player)
        {
            ConsoleOutput.ChooseOneAction();

            string userinput = Console.ReadLine();

            switch (userinput)
            {
                case Keyboard.one:
                    ThrowTheCardToTheTable(card, table, player);
                    break;
            }
        }

        private void ThrowTheCardToTheTable(Card card, Table table, Player player)
        {
            table.Cards.Add(card);
            Cards.RemoveAll(c => c.CardName == card.CardName);

            ConsoleOutput.ShowTableCards(table);

            ConsoleOutput.ShowPlayerCards(player);
            
        }
    }
}
