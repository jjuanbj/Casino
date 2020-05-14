using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Casino
{
    class Languages
    {
        
        public string WelcomeToCasinoGame;

        Language language = new Language();


        public void ChooseLanguage()
        {
            ConsoleOutput consoleOutput = new ConsoleOutput();

            consoleOutput.ChooseLanguage();

            string userinput = Console.ReadLine();

            switch (userinput)
            {
                case Keyboard.one:
                    
                    Language language = new Language();
                    ChoosenLanguage(language);
                    break;
                //case Keyboard.two:
                //    Language spanish = new Spanish();
                //    ChoosenLanguage(spanish);
                //    break;

            }
        }
        // reflection to copy properties
        private void ChoosenLanguage(Language language)
        {
            this.WelcomeToCasinoGame = language.WelcomeToCasinoGame;
        }       
    }
}
