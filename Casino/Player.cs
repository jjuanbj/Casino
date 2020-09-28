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
            ConsoleOutput.PressFWhenFinished();
            
            string cardRank = "";
            
            List<Card> tableCards = new List<Card>();

            while (cardRank != Keyboard.UPPERCASE_F && cardRank != Keyboard.LOWERCASE_F)
            {
                cardRank = Console.ReadLine().Trim();
                
                if(String.IsNullOrEmpty(cardRank)){
                    ConsoleOutput.TypeValidCardNumber();                    
                    continue;
                } else if (cardRank != Keyboard.UPPERCASE_F 
                        && cardRank != Keyboard.LOWERCASE_F
                        && cardRank.All(char.IsDigit)
                        && Enumerable.Range((int)General.Zero, table.Cards.Count).Contains(Int32.Parse(cardRank)))
                        {
                    ConsoleOutput.YouSelected(table.Cards, cardRank);
                                
                    tableCards.Add(table.Cards.ElementAt(Int32.Parse(cardRank)));                    
                }  else if (cardRank == Keyboard.UPPERCASE_F || cardRank == Keyboard.LOWERCASE_F){
                    break;                
                }
                else
                {
                    ConsoleOutput.TypeValidCardNumber();
                    cardRank = "";
                    continue;
                }                
            }   

            const int ACE_MAX_VALUE = 14;
            const int ACE_MIN_VALUE = 1;
            const int THESE_NUMBERS_ARE_MULTIPLES_OF_EACH_OTHER = 0;

            if (!tableCards.Any() || tableCards.Sum(c => Convert.ToInt32(c.Rank)) % Convert.ToInt32(selectedCard.Rank) != THESE_NUMBERS_ARE_MULTIPLES_OF_EACH_OTHER)
            {
                ConsoleOutput.YouJustLostYourCardBecauseItIsInvalid();
                ThrowTheCardToTheTable(selectedCard, table);
            } else if (tableCards.Sum(c => Convert.ToInt32(c.Rank)) % ACE_MAX_VALUE == THESE_NUMBERS_ARE_MULTIPLES_OF_EACH_OTHER 
                    || tableCards.Sum(c => Convert.ToInt32(c.Rank) == ACE_MIN_VALUE ? ACE_MAX_VALUE : Convert.ToInt32(c.Rank)) % ACE_MAX_VALUE == THESE_NUMBERS_ARE_MULTIPLES_OF_EACH_OTHER)
            {
                table.Cards.RemoveAll(c => tableCards.Contains(c));
                CapturedCards.AddRange(tableCards);
                CapturedCards.Add(selectedCard);

                ConsoleOutput.ShowTableCards(table);
                ConsoleOutput.ShowCapturedCards(this);
            }
        }

        private void BuildCards(Card selectedCard, Table table){
                                    
        }
    }
}
