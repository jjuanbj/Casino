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

        public Player(string name) {
            Name = name;
        }

        public void Play(Table table, Player player)
        {
            Card card = SelectYourCard();
            Action(card, table, player);
        }

        private Card SelectYourCard()
        {
            ConsoleOutput consoleOutput = new ConsoleOutput();

            consoleOutput.SelectOneCardByIndexNumber(this);            

            string cardNumber = Console.ReadLine().Trim();
            Card card = null;

            while (card == null)
            {
                if (!String.IsNullOrEmpty(cardNumber)
                && cardNumber.All(char.IsDigit)
                && Enumerable.Range((int)General.Zero, Cards.Count).Contains(Int32.Parse(cardNumber)))
                {
                    consoleOutput.YouSelected(this.Cards, cardNumber);

                    card = new Card(Cards.ElementAt(Int32.Parse(cardNumber)).CardName);
                }
                else
                {
                    consoleOutput.TypeValidCardNumber();
                }
            }
            return card;
        }

        private void Action(Card card, Table table, Player player)
        {
            ConsoleOutput consoleOutput = new ConsoleOutput();

            consoleOutput.ChooseOneAction();

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

            ConsoleOutput consoleOutput = new ConsoleOutput();

            consoleOutput.ShowTableCards(table);

            consoleOutput.ShowPlayerCards(player);
            
        }
    }
}
