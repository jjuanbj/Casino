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

        public void Play(Table table)
        {
            Card card = SelectYourCard();
            Action(card, table);
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

        private void Action(Card card, Table table)
        {
            Console.WriteLine("Choose one action: 1- Throw the card to the table, 2-Take a card from the table");

            string userinput = Console.ReadLine();

            switch (userinput)
            {
                case "1":
                    ThrowTheCardToTheTable(card, table);
                    break;
            }
        }

        private void ThrowTheCardToTheTable(Card card, Table table)
        {
            table.Cards.Add(card);
            Cards.RemoveAll(c => c.CardName == card.CardName);

            ConsoleOutput consoleOutput = new ConsoleOutput();

            consoleOutput.ShowTableCards(table);

            //consoleOutput.ShowPlayersCards();
            
        }
    }
}
