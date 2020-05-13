using System;
using System.Collections.Generic;
using System.Text;

namespace Casino
{
    class Language
    {
        public string WelcomeToCasinoGame;

        public string PleaseWritePlayerNamesPressFWhenFinished;

        public string Welcome;

        public string Computer;

        public string ThisNameIsNotAllowed;

        public string OnTable;

        public string ItsYourTurn;

        public string SelectOneCardByIndexNumber;

        public string YouSelected;

        public string TypeValidCardNumber;

        public string ChooseOneAction;

        public List<string> GetPhrases()
        {
            List<string> phrases = new List<string>
            {
                this.GetType().GetProperties().ToString()
            };

            return phrases;
        }
    }
}
