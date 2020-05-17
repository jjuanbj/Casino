using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Casino
{
    class Speak
    {
        public string WelcomeToCasinoGame { get; private set; }

        public string PleaseWritePlayerNamesPressFWhenFinished { get; private set; }

        public string Welcome { get; private set; }

        public string Computer { get; private set; }

        public string ThisNameIsNotAllowed { get; private set; }

        public string OnTable { get; private set; }

        public string ItsYourTurn { get; private set; }

        public string SelectOneCardByIndexNumber { get; private set; }

        public string YouSelected { get; private set; }

        public string TypeValidCardNumber { get; private set; }

        public string ChooseOneAction { get; private set; }
        //private string _ChooseYourLanguage;
        //public string ChooseYourLanguage { get { return _ChooseYourLanguage; } private set { _ChooseYourLanguage = "Choose your language: 1- English, 2- Español"; } }
        public string ChooseYourLanguage { get; set; }
                
        public void ChooseLanguage()
        {
            ConsoleOutput consoleOutput = new ConsoleOutput();

            consoleOutput.ChooseLanguage();

            string userinput = Console.ReadLine();

            switch (userinput)
            {
                case Keyboard.one:
                    English english = new English();                    
                    this.CopyPropertiesFromObjectToAnother(english);
                    break;
                case Keyboard.two:
                    Spanish spanish = new Spanish();
                    this.CopyPropertiesFromObjectToAnother(spanish);
                    break;
            }
        }                
    }
}
