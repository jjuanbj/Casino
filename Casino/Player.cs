using System;
using System.Collections.Generic;
using System.Linq;

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

            ConsoleOutput.ChooseOneAction(table);
            
            string userinput = "";

            while (userinput != Keyboard.ONE 
                && userinput != Keyboard.TWO 
                && userinput != Keyboard.THREE
                && userinput != Keyboard.FOUR
                && userinput != Keyboard.FIVE){
                
                userinput = Console.ReadLine().Trim();

                if (userinput != Keyboard.ONE 
                 && userinput != Keyboard.TWO 
                 && userinput != Keyboard.THREE
                 && userinput != Keyboard.FOUR
                 && userinput != Keyboard.FIVE){
                    
                    ConsoleOutput.ThisIsNotAnAllowedAction();
                    ConsoleOutput.ChooseOneAction(table);
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
                case Keyboard.THREE:
                    CombineCards(card, table);
                    break;
                case Keyboard.FOUR:
                    PairCards(card, table);
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

        private List<Card> SelectCardsFromTheTable(Table table)
        {
            int cardsOnTheTable = ConsoleOutput.WhichCardWouldYouLikeToTakeFromTheTable(table);
            ConsoleOutput.PressFWhenFinished();
            
            string cardRank = "";
            
            List<Card> cardsSelectedFromTheTable = new List<Card>();

            while (cardRank != Keyboard.UPPERCASE_F && cardRank != Keyboard.LOWERCASE_F)
            {
                cardRank = Console.ReadLine().Trim();
                
                if(String.IsNullOrEmpty(cardRank)){

                    ConsoleOutput.TypeValidCardNumber();                    
                    continue;

                } else if (cardRank != Keyboard.UPPERCASE_F 
                        && cardRank != Keyboard.LOWERCASE_F
                        && cardRank.All(char.IsDigit)
                        && Enumerable.Range((int)General.Zero, cardsOnTheTable).Contains(Int32.Parse(cardRank)))
                        {
                    bool isBuildedCard = ConsoleOutput.YouSelected(table, cardRank);
                                
                    if (!isBuildedCard)
                    {
                        cardsSelectedFromTheTable.Add(table.Cards.ElementAt(Int32.Parse(cardRank)));                        
                    } else
                    {
                        int buildedCardsSelected = Int32.Parse(cardRank) - table.Cards.Count;

                        foreach (var item in table.BuildedCards.ElementAt(buildedCardsSelected).BuildedCards)
                        {
                            cardsSelectedFromTheTable.Add(item);    
                        }                        
                    }
                    
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

            return cardsSelectedFromTheTable;
        }

        private void TakeCardFromTheTable(Card selectedCard, Table table){

            List<Card> cardsSelectedFromTheTable = SelectCardsFromTheTable(table);

            const int ACE_MAX_VALUE = 14;
            const int ACE_MIN_VALUE = 1;
            const int THESE_NUMBERS_ARE_MULTIPLES_OF_EACH_OTHER = 0;

            //TODO: validate if any selected card are in PairedCard
            if (!cardsSelectedFromTheTable.Any() 
              || cardsSelectedFromTheTable.Sum(c => Convert.ToInt32(c.Rank)) 
            % Convert.ToInt32(selectedCard.Rank) != THESE_NUMBERS_ARE_MULTIPLES_OF_EACH_OTHER)
            {
                ConsoleOutput.YouJustLostYourCardBecauseItIsInvalid();
                ThrowTheCardToTheTable(selectedCard, table);
            } else if (cardsSelectedFromTheTable.Sum(c => Convert.ToInt32(c.Rank)) % ACE_MAX_VALUE == THESE_NUMBERS_ARE_MULTIPLES_OF_EACH_OTHER 
                    || cardsSelectedFromTheTable.Sum(c => Convert.ToInt32(c.Rank) == ACE_MIN_VALUE ? ACE_MAX_VALUE : Convert.ToInt32(c.Rank)) 
                    % ACE_MAX_VALUE == THESE_NUMBERS_ARE_MULTIPLES_OF_EACH_OTHER)
            {
                table.Cards.RemoveAll(c => cardsSelectedFromTheTable.Contains(c));
                CapturedCards.AddRange(cardsSelectedFromTheTable);
                CapturedCards.Add(selectedCard);

                ConsoleOutput.ShowTableCards(table);
                ConsoleOutput.ShowCapturedCards(this);
            }
        }

        private Card SelectBuildingRank(Card selectedCard){

            ConsoleOutput.SelectYourBuildingRank(this, selectedCard);            

            string cardNumber = "";
            Card buildingRankCard = null;

            while (String.IsNullOrEmpty(cardNumber))
            {
                cardNumber = Console.ReadLine().Trim();

                if (!String.IsNullOrEmpty(cardNumber)
                && cardNumber.All(char.IsDigit)
                && Enumerable.Range((int)General.Zero, Cards.Count).Contains(Int32.Parse(cardNumber)))
                {
                    List<Card> playerCardsWithoutSelectedCard = new List<Card>(Cards.Where(c => c.CardName != selectedCard.CardName));

                    buildingRankCard = new Card(playerCardsWithoutSelectedCard.ElementAt(Int32.Parse(cardNumber)).CardName);

                    if (Cards.Any(c => c.CardName == buildingRankCard.CardName))
                    {                        
                        ConsoleOutput.YouSelected(playerCardsWithoutSelectedCard.ToList(), cardNumber);    
                    }
                }
                else
                {
                    ConsoleOutput.TypeValidCardNumber();
                    cardNumber = "";
                    continue;                    
                }
            }

            return buildingRankCard;
        }

        private void CombineCards(Card selectedCard, Table table){
            
            Card buildingRankCard = SelectBuildingRank(selectedCard);                        
            
            List<Card> cardsSelectedFromTheTable = SelectCardsFromTheTable(table);
            cardsSelectedFromTheTable.Add(selectedCard);
            
            const int THESE_NUMBERS_ARE_MULTIPLES_OF_EACH_OTHER = 0;

            if (!cardsSelectedFromTheTable.Any() 
              || cardsSelectedFromTheTable.Sum(c => Convert.ToInt32(c.Rank)) 
              % Convert.ToInt32(buildingRankCard.Rank) != THESE_NUMBERS_ARE_MULTIPLES_OF_EACH_OTHER)
            {
                ConsoleOutput.YouJustLostYourCardBecauseItIsInvalid();
                ThrowTheCardToTheTable(selectedCard, table);
            } else 
            {                        
                table.Cards.RemoveAll(c => cardsSelectedFromTheTable.Contains(c));

                BuildedCard buildedCard = new BuildedCard();         
                buildedCard.BuildedCards = cardsSelectedFromTheTable;
                buildedCard.BuildedCardsRank = buildingRankCard.Rank;

                if (table.BuildedCards == null)
                {
                    buildedCard.IsPair = false;    
                } else if (table.BuildedCards.Any(c => c.BuildedCardsRank == buildedCard.BuildedCardsRank))
                {
                    buildedCard.IsPair = true;
                                        
                    table.BuildedCards.Where(c => c.BuildedCardsRank == buildedCard.BuildedCardsRank)
                                      .FirstOrDefault().IsPair = true;
                }

                List<BuildedCard> buildedCards = new List<BuildedCard>();
                buildedCards.Add(buildedCard);
                
                table.BuildedCards = buildedCards;
                
                ConsoleOutput.ShowTableCards(table);                
            }                  
        }

        private void PairCards(Card selectedCard, Table table){
            
            Card buildingRankCard = SelectBuildingRank(selectedCard);                        
            
            List<Card> cardsSelectedFromTheTable = SelectCardsFromTheTable(table);
            cardsSelectedFromTheTable.Add(selectedCard);

            const int THESE_NUMBERS_ARE_MULTIPLES_OF_EACH_OTHER = 0;

            if (!cardsSelectedFromTheTable.Any() 
              || cardsSelectedFromTheTable.All(c => c.Rank != buildingRankCard.Rank)
              || cardsSelectedFromTheTable.Sum(c => Convert.ToInt32(c.Rank)) 
              % Convert.ToInt32(buildingRankCard.Rank) != THESE_NUMBERS_ARE_MULTIPLES_OF_EACH_OTHER)
            {
                ConsoleOutput.YouJustLostYourCardBecauseItIsInvalid();
              
                ThrowTheCardToTheTable(selectedCard, table);
            } else 
            {
                table.Cards.RemoveAll(c => cardsSelectedFromTheTable.Contains(c));

                BuildedCard buildedCard = new BuildedCard();                
                buildedCard.BuildedCards = cardsSelectedFromTheTable;
                buildedCard.BuildedCardsRank = buildingRankCard.Rank;
                buildedCard.IsPair = true;

                List<BuildedCard> buildedCards = new List<BuildedCard>();
                buildedCards.Add(buildedCard);
                
                table.BuildedCards = buildedCards;
                
                ConsoleOutput.ShowTableCards(table);                
            }                  
        }
    }
}
