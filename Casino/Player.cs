using Microsoft.VisualBasic;
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
        public List<Card> CapturedCards { get; set; }

        public Player(string name, ConsoleOutput consoleOutput) {
            Name = name;
            ConsoleOutput = consoleOutput;
            CapturedCards = new List<Card>();
        }

        public void Play(Table table, Player player)
        {            
            Actuate(table, player);
        }
 
        private Card SelectYourCard()
        {            
            
            ConsoleOutput.SelectOneCardByIndexNumber(this);            
            ConsoleOutput.PressAIfYouWantToSelectAnotherAction();

            string cardNumber = "";
            Card card = null;

            while (String.IsNullOrEmpty(cardNumber))
            {
                cardNumber = Console.ReadLine().Trim();

                if (cardNumber == "A"){
                    //TODO It need to let the user to select another action if press A    
                }

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
                    cardNumber = "";
                    continue;                    
                }
            }
            return card;
        }

        private void Actuate(Table table, Player player)
        {
            ConsoleOutput.ChooseOneAction();
            
            string userinput = "";

            while (userinput != Keyboard.ONE && userinput != Keyboard.TWO){
                
                userinput = Console.ReadLine().Trim();

                if (userinput != Keyboard.ONE && userinput != Keyboard.TWO){
                    ConsoleOutput.ThisIsNotAnAllowedAction();
                    ConsoleOutput.ChooseOneAction();
                }
            }

            Card card = SelectYourCard();

            switch (userinput)
            {
                case Keyboard.ONE:
                    ThrowTheCardToTheTable(card, table, player);
                    break;
                case Keyboard.TWO:
                    TakeCardFromTheTable(table, card);
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

        private void TakeCardFromTheTable(Table table, Card cardSelected)
        {
            ConsoleOutput.WhichCardWouldYouLikeToTakeFromTheTable(table);

            string cardNumber = "";
            
            Card card = null;

            while (String.IsNullOrEmpty(cardNumber))
            {
                cardNumber = Console.ReadLine().Trim();

                if (!String.IsNullOrEmpty(cardNumber)
                && cardNumber.All(char.IsDigit)
                && Enumerable.Range((int)General.Zero, table.Cards.Count).Contains(Int32.Parse(cardNumber)))
                {
                    ConsoleOutput.YouSelected(table.Cards, cardNumber);

                    card = new Card(table.Cards.ElementAt(Int32.Parse(cardNumber)).CardName);
                }
                else
                {
                    ConsoleOutput.TypeValidCardNumber();
                    cardNumber = "";
                    continue;
                }

                if (cardSelected.Rank == card.Rank)
                {
                    table.Cards.RemoveAll(c => c.Rank == card.Rank);
                    CapturedCards.Add(card);
                    CapturedCards.Add(cardSelected);

                    ConsoleOutput.ShowTableCards(table);
                    ConsoleOutput.ShowCapturedCards(this);
                } else
                {
                    ConsoleOutput.TypeValidCardNumber();
                    cardNumber = "";
                    continue;
                }
            }                        
        }
    }
}
