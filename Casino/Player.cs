using System;
using System.Collections.Generic;
using System.Linq;

namespace Casino
{
    class Player
    {
        public string Name { get; set; }
        public List<Card> Cards { get; set; }
        public static ConsoleOutput ConsoleOutput { get; set; }
        public List<Card> CapturedCards { get; set; }
        public List<Points> Score { get; set; }

        public Player(string name, ConsoleOutput consoleOutput)
        {
            Name = name;
            ConsoleOutput = consoleOutput;
            CapturedCards = new List<Card>();
            Score = new List<Points>();
        }

        public virtual void Play(Table table)
        {
            Card selectedCard = SelectYourCard();

            ConsoleOutput.ChooseOneAction(table);

            string userinput = "";

            while (userinput != Keyboard.ONE
                && userinput != Keyboard.TWO
                && userinput != Keyboard.THREE
                && userinput != Keyboard.FOUR)
            {

                userinput = Console.ReadLine().Trim();

                if (userinput != Keyboard.ONE
                 && userinput != Keyboard.TWO
                 && userinput != Keyboard.THREE
                 && userinput != Keyboard.FOUR)
                {
                    ConsoleOutput.ThisIsNotAnAllowedAction();
                    ConsoleOutput.ChooseOneAction(table);
                }
            }

            switch (userinput)
            {
                case Keyboard.ONE:
                    ThrowTheCardToTheTable(selectedCard, table);
                    break;
                case Keyboard.TWO:
                    TakeCardFromTheTable(selectedCard, table);
                    break;
                case Keyboard.THREE:
                    CreateSingleBuildCards(selectedCard, table);
                    break;
                case Keyboard.FOUR:
                    CreateMultipleBuildCards(selectedCard, table);
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

        public virtual void ThrowTheCardToTheTable(Card selectedCard, Table table)
        {
            table.Cards.Add(selectedCard);
            
            Cards.RemoveAll(c => c.CardName == selectedCard.CardName);

            ConsoleOutput.ShowTableCards(table);

            if (this.Cards.Any())
            {
                ConsoleOutput.ShowPlayerCards(this);    
            }            
        }

        private Table SelectCardsFromTheTable(Table table)
        {
            int cardsOnTheTable = ConsoleOutput.WhichCardWouldYouLikeToTakeFromTheTable(table);
            ConsoleOutput.PressFWhenFinished();

            string cardRank = "";

            Table cardsSelectedFromTheTable = new Table();
            cardsSelectedFromTheTable.Cards = new List<Card>();
            cardsSelectedFromTheTable.BuildedCards = new List<BuildedCard>();

            while (cardRank != Keyboard.UPPERCASE_F && cardRank != Keyboard.LOWERCASE_F)
            {
                cardRank = Console.ReadLine().Trim();

                if (String.IsNullOrEmpty(cardRank))
                {

                    ConsoleOutput.TypeValidCardNumber();
                    continue;

                }
                else if (cardRank != Keyboard.UPPERCASE_F
                      && cardRank != Keyboard.LOWERCASE_F
                      && cardRank.All(char.IsDigit)
                      && Enumerable.Range((int)General.Zero, cardsOnTheTable).Contains(Int32.Parse(cardRank)))
                {
                    bool isBuildedCard = ConsoleOutput.YouSelected(table, cardRank);

                    if (!isBuildedCard)
                    {                        
                        cardsSelectedFromTheTable.Cards.Add(table.Cards.ElementAt(Int32.Parse(cardRank)));
                    } else
                    {
                        int buildedCardsSelected = Int32.Parse(cardRank) - table.Cards.Count;
                        
                        cardsSelectedFromTheTable.BuildedCards.Add(table.BuildedCards.ElementAt(buildedCardsSelected));
                    }

                }
                else if (cardRank == Keyboard.UPPERCASE_F || cardRank == Keyboard.LOWERCASE_F)
                {
                    break;
                }
                else
                {
                    ConsoleOutput.TypeValidCardNumber();
                    cardRank = "";
                    continue;
                }
            }

            if (!cardsSelectedFromTheTable.Cards.Any()) 
                 cardsSelectedFromTheTable.Cards = null;
            
            if (!cardsSelectedFromTheTable.BuildedCards.Any())            
                 cardsSelectedFromTheTable.BuildedCards = null;
            
            return cardsSelectedFromTheTable;
        }

        public virtual void TakeCardFromTheTable(Card selectedCard, Table table)
        {
            Table cardsSelectedFromTheTable = SelectCardsFromTheTable(table);
    
            if (!ValidateTakenCards(cardsSelectedFromTheTable, selectedCard))
            {
                ConsoleOutput.YouJustLostYourCardBecauseItIsInvalid();
         
                ThrowTheCardToTheTable(selectedCard, table);
            }
            else
            {
                if(cardsSelectedFromTheTable.Cards != null) {
                    
                    table.Cards.RemoveAll(c => cardsSelectedFromTheTable.Cards.Contains(c));

                    CapturedCards.AddRange(cardsSelectedFromTheTable.Cards);                    
                } 
                  
                if(cardsSelectedFromTheTable.BuildedCards != null) {

                    table.BuildedCards.RemoveAll(c => cardsSelectedFromTheTable.BuildedCards.Contains(c));

                    CapturedCards.AddRange(cardsSelectedFromTheTable.BuildedCards
                                 .SelectMany(b => b.BuildedCards)
                                 .Distinct());
                }                    
                
                Cards.RemoveAll(c => c.CardName == selectedCard.CardName);

                CapturedCards.Add(selectedCard);

                ConsoleOutput.ShowTableCards(table);
                ConsoleOutput.ShowCapturedCards(this);
            }
        }
        
        private bool ValidateTakenCards(Table cardsSelectedFromTheTable, Card selectedCard){

            bool takenCardsFromTableAreValid = true;
            
            const int THESE_NUMBERS_ARE_MULTIPLES_OF_EACH_OTHER = 0;
            const int ACE_MAX_VALUE = 14;

            const bool USER_DID_NOT_TAKE_CARDS_FROM_TABLE = false;
            const bool SELECTED_CARD_AND_CARDS_TAKEN_FROM_TABLE_DO_NOT_HAVE_SAME_RANK = false;
            const bool SELECTED_ACE_BUT_TAKEN_CARDS_FROM_TABLE_ARE_NOT_EQUAL_TO_FOURTEEN = false;
            const bool SELECTED_CARD_AND_BUILDED_CARDS_DO_NOT_HAVE_SAME_RANK = false;
            const bool SELECTED_ACE_AND_OTHER_CARDS_BUT_THOSE_CARDS_ARE_NOT_EQUAL_TO_FOURTEEN = false;
            const bool SELECTED_ACE_BUT_BUILDED_CARDS_DO_NOT_HAVE_ACE_MAX_VALUE = false;
            
            if (cardsSelectedFromTheTable.Cards == null && cardsSelectedFromTheTable.BuildedCards == null)
            {
                takenCardsFromTableAreValid = USER_DID_NOT_TAKE_CARDS_FROM_TABLE;                    

            } else if (cardsSelectedFromTheTable.Cards != null)
            {
                if (cardsSelectedFromTheTable.Cards.Sum(c => Convert.ToInt32(c.Rank)) 
                % Convert.ToInt32(selectedCard.Rank) != THESE_NUMBERS_ARE_MULTIPLES_OF_EACH_OTHER)
                {
                    takenCardsFromTableAreValid = SELECTED_CARD_AND_CARDS_TAKEN_FROM_TABLE_DO_NOT_HAVE_SAME_RANK;                    

                } else if (selectedCard.Rank == Rank.Ace && (!cardsSelectedFromTheTable.Cards.Any(c => c.Rank == Rank.Ace)
                                                         &&   cardsSelectedFromTheTable.Cards.Sum(c => Convert.ToInt32(c.Rank)) 
                                                          % ACE_MAX_VALUE != THESE_NUMBERS_ARE_MULTIPLES_OF_EACH_OTHER))
                {
                    takenCardsFromTableAreValid = SELECTED_ACE_BUT_TAKEN_CARDS_FROM_TABLE_ARE_NOT_EQUAL_TO_FOURTEEN;         

                } else if (selectedCard.Rank == Rank.Ace && (cardsSelectedFromTheTable.Cards.Any(c => c.Rank == Rank.Ace) 
                                                         &&  cardsSelectedFromTheTable.Cards.Any(c => c.Rank != Rank.Ace) 
                                                         && (cardsSelectedFromTheTable.Cards.Where(c => c.Rank != Rank.Ace)
                                                                                            .Sum(c => Convert.ToInt32(c.Rank)) 
                                                          % ACE_MAX_VALUE != THESE_NUMBERS_ARE_MULTIPLES_OF_EACH_OTHER)
                                                         && cardsSelectedFromTheTable.Cards.Sum(c => Convert.ToInt32(c.Rank))
                                                          % ACE_MAX_VALUE != THESE_NUMBERS_ARE_MULTIPLES_OF_EACH_OTHER))
                {
                    takenCardsFromTableAreValid = SELECTED_ACE_AND_OTHER_CARDS_BUT_THOSE_CARDS_ARE_NOT_EQUAL_TO_FOURTEEN;                    
                }

            } else if (cardsSelectedFromTheTable.BuildedCards != null)
            {
                if (cardsSelectedFromTheTable.BuildedCards.Any(b => b.BuildedCardsRank != selectedCard.Rank))
                {
                    takenCardsFromTableAreValid = SELECTED_CARD_AND_BUILDED_CARDS_DO_NOT_HAVE_SAME_RANK;    
                    
                } else if (selectedCard.Rank == Rank.Ace 
                          && cardsSelectedFromTheTable.BuildedCards.Any(b => Convert.ToInt32(b.BuildedCardsRank) != ACE_MAX_VALUE))
                {
                    takenCardsFromTableAreValid = SELECTED_ACE_BUT_BUILDED_CARDS_DO_NOT_HAVE_ACE_MAX_VALUE;         
                }                
            }

            return takenCardsFromTableAreValid;
        }

        private Rank SelectBuildingRank(Card selectedCard)
        {

            ConsoleOutput.SelectYourBuildingRank(this, selectedCard);

            string cardNumber = "";
            Card buildingRankCard = null;
            int cardsCount = this.Cards.Count; // TODO: Index out of range

            while (String.IsNullOrEmpty(cardNumber))
            {
                cardNumber = Console.ReadLine().Trim();

                Console.WriteLine("Test: " + cardsCount);

                if (!String.IsNullOrEmpty(cardNumber)
                && cardNumber.All(char.IsDigit)
                && Enumerable.Range((int)General.Zero, cardsCount).Contains(Int32.Parse(cardNumber)))
                {
                    cardsCount = cardsCount - 1;

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

            return buildingRankCard.Rank;
        }

        public virtual void CreateSingleBuildCards(Card selectedCard, Table table)
        {
            Rank buildingRankCard = SelectBuildingRank(selectedCard);

            List<Card> cardsSelectedFromTheTable = SelectCardsFromTheTable(table).Cards;
            cardsSelectedFromTheTable.Add(selectedCard);

            const int THESE_NUMBERS_ARE_MULTIPLES_OF_EACH_OTHER = 0;

            if (!cardsSelectedFromTheTable.Any()
              || cardsSelectedFromTheTable.Sum(c => Convert.ToInt32(c.Rank))
              % Convert.ToInt32(buildingRankCard) != THESE_NUMBERS_ARE_MULTIPLES_OF_EACH_OTHER)
            {
                ConsoleOutput.YouJustLostYourCardBecauseItIsInvalid();
                ThrowTheCardToTheTable(selectedCard, table);
            }
            else
            {
                Cards.RemoveAll(c => c.CardName == selectedCard.CardName);

                table.Cards.RemoveAll(c => cardsSelectedFromTheTable.Contains(c));

                BuildedCard buildedCard = new BuildedCard();
                buildedCard.BuildedCards = cardsSelectedFromTheTable;
                buildedCard.BuildedCardsRank = buildingRankCard;

                if (table.BuildedCards == null)
                {
                    buildedCard.IsMultiple = false;
                }
                else if (table.BuildedCards.Any(c => c.BuildedCardsRank == buildedCard.BuildedCardsRank))
                {
                    buildedCard.IsMultiple = true;

                    table.BuildedCards.Where(c => c.BuildedCardsRank == buildedCard.BuildedCardsRank)
                                      .FirstOrDefault().IsMultiple = true;
                }

                List<BuildedCard> buildedCards = new List<BuildedCard>();
                buildedCards.Add(buildedCard);

                table.BuildedCards = buildedCards;

                ConsoleOutput.ShowTableCards(table);
            }
        }
        
        public virtual void CreateMultipleBuildCards(Card selectedCard, Table table)
        {
            
            Rank buildingRankCard = SelectBuildingRank(selectedCard);
            
            Table cardsSelectedFromTheTable = SelectCardsFromTheTable(table);
            
            const int THERE_IS_ONLY_ONE_BUILDED_CARD = 1;

            if (cardsSelectedFromTheTable.BuildedCards != null)
            {                
                if (cardsSelectedFromTheTable.BuildedCards.FirstOrDefault().BuildedCardsRank == selectedCard.Rank
                &&  cardsSelectedFromTheTable.BuildedCards.FirstOrDefault().IsMultiple != true
                &&  cardsSelectedFromTheTable.BuildedCards.Take(2).Count() == THERE_IS_ONLY_ONE_BUILDED_CARD
                &&  selectedCard.Rank == buildingRankCard
                &&  cardsSelectedFromTheTable.Cards == null)
                {
                    foreach (var item in cardsSelectedFromTheTable.BuildedCards)
                    {
                        table.BuildedCards.RemoveAll(b => b.BuildedCardsRank == item.BuildedCardsRank);
                    }
                                                      
                    cardsSelectedFromTheTable.BuildedCards.FirstOrDefault().IsMultiple = true;

                    cardsSelectedFromTheTable.BuildedCards.FirstOrDefault().BuildedCardsRank = buildingRankCard;

                    cardsSelectedFromTheTable.BuildedCards.FirstOrDefault()
                                             .BuildedCards.Add(selectedCard);

                    table.BuildedCards.Add(cardsSelectedFromTheTable.BuildedCards.FirstOrDefault());
                    
                    this.Cards.RemoveAll(c => c.CardName == selectedCard.CardName);
                                        
                    ConsoleOutput.ShowTableCards(table);

                } else if (cardsSelectedFromTheTable.BuildedCards.FirstOrDefault().BuildedCardsRank == buildingRankCard
                        && cardsSelectedFromTheTable.Cards != null
                        && cardsSelectedFromTheTable.Cards.Sum(c => Convert.ToInt32(c.Rank)) + Convert.ToInt32(selectedCard.Rank) == Convert.ToInt32(buildingRankCard)
                        && cardsSelectedFromTheTable.BuildedCards.Take(2).Count() == THERE_IS_ONLY_ONE_BUILDED_CARD)
                {
                    table.BuildedCards.RemoveAll(b => cardsSelectedFromTheTable.BuildedCards.Contains(b));
                    
                    foreach (var item in cardsSelectedFromTheTable.BuildedCards)
                    {
                        table.BuildedCards.RemoveAll(b => b.BuildedCardsRank == item.BuildedCardsRank);
                    }
                    
                    cardsSelectedFromTheTable.BuildedCards.FirstOrDefault().IsMultiple = true;
                    
                    cardsSelectedFromTheTable.BuildedCards.FirstOrDefault()
                                             .BuildedCards.Add(selectedCard);
                    
                    foreach (Card card in cardsSelectedFromTheTable.Cards)
                    {
                        cardsSelectedFromTheTable.BuildedCards.FirstOrDefault()
                                                 .BuildedCards.Add(card);
                    }

                    table.BuildedCards.Add(cardsSelectedFromTheTable.BuildedCards.FirstOrDefault());
                    
                    this.Cards.RemoveAll(c => c.CardName == selectedCard.CardName);
                                        
                    ConsoleOutput.ShowTableCards(table);
                    
                } else if ((cardsSelectedFromTheTable.BuildedCards.Sum(b => Convert.ToInt32(b.BuildedCardsRank)) 
                 + Convert.ToInt32(selectedCard.Rank)) % Convert.ToInt32(buildingRankCard) == 0
                 && cardsSelectedFromTheTable.Cards == null)
                {                    
                    foreach (var item in cardsSelectedFromTheTable.BuildedCards)
                    {
                        table.BuildedCards.RemoveAll(b => b.BuildedCardsRank == item.BuildedCardsRank);    
                    }
                    
                    BuildedCard newBuildedCard = new BuildedCard();
                    newBuildedCard.BuildedCards = new List<Card>();

                    foreach (List<Card> card in cardsSelectedFromTheTable.BuildedCards.Select(c => c.BuildedCards))
                    {
                        newBuildedCard.BuildedCards.AddRange(card);
                    }

                    newBuildedCard.IsMultiple = true;
                    newBuildedCard.BuildedCardsRank = buildingRankCard;
                    newBuildedCard.BuildedCards.Add(selectedCard);
                    
                    table.BuildedCards.Add(newBuildedCard);
                    this.Cards.RemoveAll(c => c.CardName == selectedCard.CardName);
                    Console.WriteLine("Prueba2");                    
                    ConsoleOutput.ShowTableCards(table);

                } else
                {
                    ConsoleOutput.YouJustLostYourCardBecauseItIsInvalid();

                    this.Cards.RemoveAll(c => c.CardName == selectedCard.CardName);

                    ThrowTheCardToTheTable(selectedCard, table);                    
                }                

            } else if (cardsSelectedFromTheTable.Cards != null)
            {
                cardsSelectedFromTheTable.Cards.Add(selectedCard);

                const int THESE_NUMBERS_ARE_MULTIPLES_OF_EACH_OTHER = 0;
                const int ACE_MAX_VALUE = 14;

                // TODO: This if is too big
                if ( !cardsSelectedFromTheTable.Cards.Any()
                  || (cardsSelectedFromTheTable.Cards.Sum(c => Convert.ToInt32(c.Rank)) / Convert.ToInt32(buildingRankCard) == 1 
                  &&  cardsSelectedFromTheTable.Cards.All(c => c.Rank != buildingRankCard))
                  || (cardsSelectedFromTheTable.Cards.Sum(c => Convert.ToInt32(c.Rank)) / Convert.ToInt32(buildingRankCard) == 1
                  &&  cardsSelectedFromTheTable.Cards.Where(c => c.CardName != selectedCard.CardName)
                                                     .Sum(c => Convert.ToInt32(c.Rank))
                  % Convert.ToInt32(buildingRankCard) != THESE_NUMBERS_ARE_MULTIPLES_OF_EACH_OTHER)
                  || (cardsSelectedFromTheTable.Cards.Sum(c => Convert.ToInt32(c.Rank)) / Convert.ToInt32(buildingRankCard) != 1
                  &&  cardsSelectedFromTheTable.Cards.Sum(c => Convert.ToInt32(c.Rank))
                  % Convert.ToInt32(buildingRankCard) != THESE_NUMBERS_ARE_MULTIPLES_OF_EACH_OTHER)
                  || (buildingRankCard == Rank.Ace 
                  && cardsSelectedFromTheTable.Cards.Where(c => c.CardName != selectedCard.CardName)
                                                    .Sum(c => Convert.ToInt32(c.Rank))
                  % ACE_MAX_VALUE != THESE_NUMBERS_ARE_MULTIPLES_OF_EACH_OTHER))
                {
                    ConsoleOutput.YouJustLostYourCardBecauseItIsInvalid();

                    this.Cards.RemoveAll(c => c.CardName == selectedCard.CardName);
                    
                    ThrowTheCardToTheTable(selectedCard, table);
                }
                else
                {                    
                    Cards.RemoveAll(c => c.CardName == selectedCard.CardName);

                    foreach (var item in cardsSelectedFromTheTable.Cards)
                    {
                        table.Cards.RemoveAll(b => b.Rank == item.Rank);
                    }

                    BuildedCard buildedCard = new BuildedCard();
                    buildedCard.BuildedCards = cardsSelectedFromTheTable.Cards;
                    buildedCard.BuildedCardsRank = buildingRankCard;
                    buildedCard.IsMultiple = true;

                    List<BuildedCard> buildedCards = new List<BuildedCard>();
                    buildedCards.Add(buildedCard);

                    table.BuildedCards = buildedCards;
                    
                    this.Cards.RemoveAll(c => c.CardName == selectedCard.CardName);

                    ConsoleOutput.ShowTableCards(table);
                }   
            }
        }
    }
}
