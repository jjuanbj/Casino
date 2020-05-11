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

        public Player(Table table)
        {

        }

        public void Play(Table table)
        {
            Card card = SelectYourCard();
            Move(card, table);
        }

        private Card SelectYourCard()
        {
            Console.WriteLine(string.Format(Name + English.SelectOneCardByIndexNumber + "{0}.", string.Join(", ", Cards.Select((c, count) => new { Index = count, c.CardName }))));

            string cardNumber = Console.ReadLine().Trim();
            Card card = null;

            while (card == null)
            {
                if (!String.IsNullOrEmpty(cardNumber)
                && cardNumber.All(char.IsDigit)
                && Enumerable.Range((int)General.Zero, Cards.Count).Contains(Int32.Parse(cardNumber)))
                {
                    Console.WriteLine(English.YouSelected + Cards.ElementAt(Int32.Parse(cardNumber)).CardName);
                    card = new Card(Cards.ElementAt(Int32.Parse(cardNumber)).CardName);
                }
                else
                {
                    Console.WriteLine(English.TypeValidCardNumber);
                }
            }
            return card;
        }

        private void Move(Card card, Table table)
        {
            Console.WriteLine("Choose one action: 1- Throw the card to the table, 2-Take a card from the table");

            string userinput = Console.ReadLine();

            switch (userinput)
            {
                case "1":
                    table.Cards.Add(card);
                    this.Cards.Remove(card);
                    break;
                //default:
            }
        }
    }
}
