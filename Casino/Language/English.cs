using System;
using System.Collections.Generic;

namespace Casino
{
    class English
    {   
        public string WelcomeToCasinoGame { get; private set; }

        public string PleaseWritePlayerNamesPress { get; private set; }

        public string F { get; private set; }

        public string WhenFinished { get; private set; }

        public string Welcome { get; private set; }

        public string Computer { get; private set; }

        public string ThisNameIsNotAllowed { get; private set; }

        public string ThisIsNotAnAllowedAction { get; private set; }

        public string OnTable { get; private set; }

        public string ItsYourTurn { get; private set; }

        public string SelectOneCardByIndexNumber { get; private set; }

        public string YouSelected { get; private set; }

        public string TypeValidCardNumber { get; private set; }

        public string ChooseOneAction { get; private set; }

        public string ChooseYourLanguage { get; private set; }

        public string WhichCardWouldYouLikeToTakeFromTheTable { get; set; }

        public string CapturedCards { get; set; }

        public string YourCards { get; set; }

        public string Press { get; set; }

        public string A { get; set; }

        public string IfYouWantToSelectAnotherAction { get; set; }

        public string YouJustLostYourCardBecauseItIsInvalid { get; set; }

        public string SelectYourBuildingRank { get; set; }

        public string SingleBuild { get; set; }

        public string MultipleBuild { get; set; }    

        public string YouCannotThrowCardsWhenYouAreABuildingCardOwner { get; set; }

        public string IfYouDontHaveMoreMoveYouMustCaptureYourBuildingCard { get; set; }

        public string Player { get; set; }

        public string Score { get; set; }

        public string Winner { get; set; }

        public string Points { get; set; }

        public English()
        {
            WelcomeToCasinoGame = "Welcome to casino game!";
            PleaseWritePlayerNamesPress = "Please write player names, press ";
            F = "F";
            WhenFinished = " when finished";
            Welcome = "Welcome";
            Computer = "Computer";
            ThisNameIsNotAllowed = "This name is not allowed.";
            ThisIsNotAnAllowedAction = "This is not an allowed action";
            OnTable = "On table";
            ItsYourTurn = " it's your turn!";
            SelectOneCardByIndexNumber = " select one card by index number: ";
            YouSelected = "You selected: ";
            TypeValidCardNumber = "Type a valid card number.";
            ChooseOneAction = "Choose one action: 1-Throw the card to the table, 2-Take cards from the table, 3-Combine cards, 4-Pair cards";
            ChooseYourLanguage = "Choose your language: 1-English, 2-Español";
            WhichCardWouldYouLikeToTakeFromTheTable = "Which card would you like to take from the table? ";
            CapturedCards = "Captured cards: ";
            YourCards = "Your cards: ";
            Press = "Press ";
            A = "A";
            IfYouWantToSelectAnotherAction = " if you want to select another action.";                        
            YouJustLostYourCardBecauseItIsInvalid = "You just lost your card because it is invalid";
            SelectYourBuildingRank = " select your building rank: ";
            SingleBuild = "Single build";
            MultipleBuild = "Multiple build";
            YouCannotThrowCardsWhenYouAreABuildingCardOwner = "You cannot throw cards when you are a building card owner";
            IfYouDontHaveMoreMoveYouMustCaptureYourBuildingCard = "If you dont have more move, you must capture your building card";
            Player = "Player: ";
            Score = ", score: ";
            Winner = "Winner: ";
            Points = " points: ";
        }
    }
}
