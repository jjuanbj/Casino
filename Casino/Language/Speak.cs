﻿using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;

namespace Casino
{
    class Speak
    {
        public string WelcomeToCasinoGame { get; private set; }

        public string PleaseWritePlayerNamesPress { get; private set; }

        public string F { get; private set; }

        public string WhenFinished { get; private set; }

        public string Welcome { get; private set; }
                
        public string ThisNameIsNotAllowed { get; private set; }

        public string ThisIsNotAnAllowedAction { get; private set; }

        public string OnTable { get; private set; }

        public string ItsYourTurn { get; private set; }

        public string SelectOneCardByIndexNumber { get; private set; }

        public string YouSelected { get; private set; }

        public string TypeValidCardNumber { get; private set; }

        public string ChooseOneAction { get; private set; }
      
        public string ChooseYourLanguage { get; set; }

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

        public string MostCards { get; set; }

        public string MostSpades { get; set; }

        public string TenOfDiamonds { get; set; }

        public string TwoOfSpades { get; set; }

        public string AceOfDiamonds { get; set; }

        public string AceOfSpades { get; set; }

        public string AceOfHearts { get; set; }

        public string AceOfClub { get; set; }

        public string Sweep { get; set; }

        public Speak(){
            TenOfDiamonds = "10♦";
            TwoOfSpades = "2♠";
            AceOfDiamonds = "A♦";
            AceOfSpades = "A♠";
            AceOfHearts = "A♥";
            AceOfClub = "A♣";
        }
    }
}
