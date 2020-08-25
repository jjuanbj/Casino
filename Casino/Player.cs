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

        public void Play(Table table)
        {
            Card card = SelectYourCard();

            ConsoleOutput.ChooseOneAction();
            
            string userinput = "";

            while (userinput != Keyboard.ONE && userinput != Keyboard.TWO){
                
                userinput = Console.ReadLine().Trim();

                if (userinput != Keyboard.ONE && userinput != Keyboard.TWO){
                    ConsoleOutput.ThisIsNotAnAllowedAction();
                    ConsoleOutput.ChooseOneAction();
                }
            }            

            // Create action: 3-Gather two cards from the table, 4-Match your card with other cards on the table
            switch (userinput)
            {
                case Keyboard.ONE:
                    ThrowTheCardToTheTable(card, table);
                    break;
                case Keyboard.TWO:
                    TakeCardFromTheTable(card, table);
                    break;
            }            
        }

        private Card SelectYourCard()
        {                   
            ConsoleOutput.SelectOneCardByIndexNumber(this);            

            string cardNumber = "";
            Card card = null;

            while (String.IsNullOrEmpty(cardNumber))
            {
                cardNumber = Console.ReadLine().Trim();

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

        private void ThrowTheCardToTheTable(Card card, Table table)
        {
            table.Cards.Add(card);
            Cards.RemoveAll(c => c.CardName == card.CardName);

            ConsoleOutput.ShowTableCards(table);

            ConsoleOutput.ShowPlayerCards(this);            
        }

        private void TakeCardFromTheTable(Card selectedCard, Table table)
        {
            ConsoleOutput.WhichCardWouldYouLikeToTakeFromTheTable(table);

            string cardRank = "";
            
            List<Card> tableCards = new List<Card>();

            while (cardRank != Keyboard.UPPERCASE_F && cardRank != Keyboard.LOWERCASE_F)
            {
                cardRank = Console.ReadLine().Trim();
                
                // Fix DRY
                if(String.IsNullOrEmpty(cardRank)){
                    ConsoleOutput.TypeValidCardNumber();
                    cardRank = "";
                    continue;
                } else if (cardRank != Keyboard.UPPERCASE_F 
                        && cardRank != Keyboard.LOWERCASE_F
                        && cardRank.All(char.IsDigit)
                        && Enumerable.Range((int)General.Zero, table.Cards.Count).Contains(Int32.Parse(cardRank)))
                        {
                    ConsoleOutput.YouSelected(table.Cards, cardRank);

                    tableCards.Add(table.Cards.ElementAt(Int32.Parse(cardRank)));                    
                }  else if ((cardRank == Keyboard.UPPERCASE_F || cardRank == Keyboard.LOWERCASE_F) && tableCards.Any()){
                    break;
                }
                else
                {
                    ConsoleOutput.TypeValidCardNumber();
                    cardRank = "";
                    continue;
                }                
            }   

            if (tableCards.Sum(c => Convert.ToInt32(c.Rank)) % Convert.ToInt32(selectedCard.Rank) == 0)
            {
                table.Cards.RemoveAll(c => tableCards.Contains(c));
                CapturedCards.AddRange(tableCards);
                CapturedCards.Add(selectedCard);

                ConsoleOutput.ShowTableCards(table);
                ConsoleOutput.ShowCapturedCards(this);
            } else
            {
                ConsoleOutput.YouJustLostYourCardBecauseItIsInvalid();
                ThrowTheCardToTheTable(selectedCard, table);                    
            }                     
        }
    }
}
