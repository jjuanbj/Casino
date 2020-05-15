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
        public string WelcomeToCasinoGame { get; set; }

        public string PleaseWritePlayerNamesPressFWhenFinished { get; set; }

        public string Welcome { get; set; }

        /*public string Computer;

        public string ThisNameIsNotAllowed;

        public string OnTable;

        public string ItsYourTurn;

        public string SelectOneCardByIndexNumber;

        public string YouSelected;

        public string TypeValidCardNumber;

        public string ChooseOneAction;*/

        public void ChooseLanguage()
        {
            ConsoleOutput consoleOutput = new ConsoleOutput();

            consoleOutput.ChooseLanguage();

            string userinput = Console.ReadLine();

            switch (userinput)
            {
                case Keyboard.one:
                    Spanish spanish = new Spanish();
                    //Copy(spanish);
                    this.CopyPropertiesFrom(spanish);
                    break;
                //case Keyboard.two:
                //    Language spanish = new Spanish();
                //    ChoosenLanguage(spanish);
                //    break;

            }
        }        

        public void Copy(Spanish parent)
        {
            var parentProperties = parent.GetType().GetProperties();
            var childProperties = this.GetType().GetProperties();

            foreach (var parentProperty in parentProperties)
            {
                foreach (var childProperty in childProperties)
                {
                    if (parentProperty.Name == childProperty.Name && parentProperty.PropertyType == childProperty.PropertyType)
                    {
                        childProperty.SetValue(this, parentProperty.GetValue(parent));
                        break;
                    }
                }
            }
        }
    }
}
