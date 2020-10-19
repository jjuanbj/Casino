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

        public Player(string name, ConsoleOutput consoleOutput)
        {
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
                && userinput != Keyboard.FIVE)
            {

                userinput = Console.ReadLine().Trim();

                if (userinput != Keyboard.ONE
                 && userinput != Keyboard.TWO
                 && userinput != Keyboard.THREE
                 && userinput != Keyboard.FOUR
                 && userinput != Keyboard.FIVE)
                {

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

        private Table SelectCardsFromTheTable(Table table)
        {
            int cardsOnTheTable = ConsoleOutput.WhichCardWouldYouLikeToTakeFromTheTable(table);
            ConsoleOutput.PressFWhenFinished();

            string cardRank = "";

            Table cardsSelectedFromTheTable = new Table();

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
                        cardsSelectedFromTheTable.Cards = new List<Card>();
                        cardsSelectedFromTheTable.Cards.Add(table.Cards.ElementAt(Int32.Parse(cardRank)));
                    }
                    else
                    {
                        int buildedCardsSelected = Int32.Parse(cardRank) - table.Cards.Count;

                        cardsSelectedFromTheTable.BuildedCards = new List<BuildedCard>();
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

            return cardsSelectedFromTheTable;
        }

        private void TakeCardFromTheTable(Card selectedCard, Table table)
        {

            Table cardsSelectedFromTheTable = SelectCardsFromTheTable(table);
    
            if (!ValidateTakenCards(cardsSelectedFromTheTable, selectedCard))
            {
                ConsoleOutput.YouJustLostYourCardBecauseItIsInvalid();
                ThrowTheCardToTheTable(selectedCard, table);

            }
            else
            {
                table.Cards.RemoveAll(c => cardsSelectedFromTheTable.Cards.Contains(c));
                CapturedCards.AddRange(cardsSelectedFromTheTable.Cards);
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
            const bool SELECTED_CARD_AND_PAIRED_CARDS_DO_NOT_HAVE_SAME_RANK = false;

            if (cardsSelectedFromTheTable.Cards == null && cardsSelectedFromTheTable.BuildedCards == null)
            {
                takenCardsFromTableAreValid = USER_DID_NOT_TAKE_CARDS_FROM_TABLE;    

            } else if (cardsSelectedFromTheTable.Cards != null)
            {
                if (cardsSelectedFromTheTable.Cards.Sum(c => Convert.ToInt32(c.Rank)) 
                % Convert.ToInt32(selectedCard.Rank) != THESE_NUMBERS_ARE_MULTIPLES_OF_EACH_OTHER)
                {
                    takenCardsFromTableAreValid = SELECTED_CARD_AND_CARDS_TAKEN_FROM_TABLE_DO_NOT_HAVE_SAME_RANK;

                } else if (selectedCard.Rank == Rank.Ace && (cardsSelectedFromTheTable.Cards.Sum(c => Convert.ToInt32(c.Rank)) 
                % ACE_MAX_VALUE != THESE_NUMBERS_ARE_MULTIPLES_OF_EACH_OTHER))
                {
                    takenCardsFromTableAreValid = SELECTED_ACE_BUT_TAKEN_CARDS_FROM_TABLE_ARE_NOT_EQUAL_TO_FOURTEEN;        
                }
            } else if (cardsSelectedFromTheTable.BuildedCards != null
                    && cardsSelectedFromTheTable.BuildedCards.Where(b => b.IsPair == true)
                                                             .Any(b => b.BuildedCardsRank != selectedCard.Rank))
            {
                takenCardsFromTableAreValid = SELECTED_CARD_AND_PAIRED_CARDS_DO_NOT_HAVE_SAME_RANK;
            }

            return takenCardsFromTableAreValid;
        }

        private Card SelectBuildingRank(Card selectedCard)
        {

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

        private void CombineCards(Card selectedCard, Table table)
        {

            Card buildingRankCard = SelectBuildingRank(selectedCard);

            List<Card> cardsSelectedFromTheTable = SelectCardsFromTheTable(table).Cards;
            cardsSelectedFromTheTable.Add(selectedCard);

            const int THESE_NUMBERS_ARE_MULTIPLES_OF_EACH_OTHER = 0;

            if (!cardsSelectedFromTheTable.Any()
              || cardsSelectedFromTheTable.Sum(c => Convert.ToInt32(c.Rank))
              % Convert.ToInt32(buildingRankCard.Rank) != THESE_NUMBERS_ARE_MULTIPLES_OF_EACH_OTHER)
            {
                ConsoleOutput.YouJustLostYourCardBecauseItIsInvalid();
                ThrowTheCardToTheTable(selectedCard, table);
            }
            else
            {
                table.Cards.RemoveAll(c => cardsSelectedFromTheTable.Contains(c));

                BuildedCard buildedCard = new BuildedCard();
                buildedCard.BuildedCards = cardsSelectedFromTheTable;
                buildedCard.BuildedCardsRank = buildingRankCard.Rank;

                if (table.BuildedCards == null)
                {
                    buildedCard.IsPair = false;
                }
                else if (table.BuildedCards.Any(c => c.BuildedCardsRank == buildedCard.BuildedCardsRank))
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

        private void PairCards(Card selectedCard, Table table)
        {

            Card buildingRankCard = SelectBuildingRank(selectedCard);

            List<Card> cardsSelectedFromTheTable = SelectCardsFromTheTable(table).Cards;
            cardsSelectedFromTheTable.Add(selectedCard);

            const int THESE_NUMBERS_ARE_MULTIPLES_OF_EACH_OTHER = 0;

            if (!cardsSelectedFromTheTable.Any()
              || cardsSelectedFromTheTable.All(c => c.Rank != buildingRankCard.Rank)
              || cardsSelectedFromTheTable.Sum(c => Convert.ToInt32(c.Rank))
              % Convert.ToInt32(buildingRankCard.Rank) != THESE_NUMBERS_ARE_MULTIPLES_OF_EACH_OTHER)
            {
                ConsoleOutput.YouJustLostYourCardBecauseItIsInvalid();

                ThrowTheCardToTheTable(selectedCard, table);
            }
            else
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
