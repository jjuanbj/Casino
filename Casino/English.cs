﻿using System;
using System.Collections.Generic;
using System.Text;

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
            ChooseOneAction = "Choose one action: 1- Throw the card to the table, 2-Take a card from the table";
            ChooseYourLanguage = "Choose your language: 1- English, 2- Español";
            WhichCardWouldYouLikeToTakeFromTheTable = "Which card would you like to take from the table? ";
            CapturedCards = "Captured cards: ";
            YourCards = "Your cards: ";
        }
    }
}
