using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Casino
{
    class Languages
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

        Language language = new Language();

        public void ChooseLanguage()
        {
            ConsoleOutput consoleOutput = new ConsoleOutput();

            consoleOutput.ChooseLanguage();

            string userinput = Console.ReadLine();

            switch (userinput)
            {
                case Keyboard.one:
                    Language english = new English();
                    ChoosenLanguage(english);
                    break;
                case Keyboard.two:
                    Language spanish = new Spanish();
                    ChoosenLanguage(spanish);
                    break;
            }
        }        

        private void ChoosenLanguage(Language languageChoosen)
        {
            foreach (var item in this.GetPhrases())
            {
                this.GetPhrases().Where(l => l.GetType().Name == languageChoosen.GetType().Name);
            }
        }

        private List<string> GetPhrases()
        {
            List<string> phrases = new List<string>
            {
                this.GetType().GetProperties().ToString()
            };

            return phrases;
        }
    }
}
