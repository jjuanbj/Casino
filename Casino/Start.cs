using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Casino
{
    class Start
    {
        public Speak Speak { get; set; }
        private Speak GetSpeak = new Speak();
        
        public Start()
        {
            Speak = GetSpeak;
        }
        public void StartGame(Deck deck, List<Player> players, Table table, ConsoleOutput consoleOutput)
        {            
            deck.CreateCards();
            deck.ShuffleCards();                        

            string username = "";            

            while (username != Keyboard.F && username != Keyboard.f)
            {
                consoleOutput.PleaseWritePlayerNamesPressFWhenFinished();

                username = Console.ReadLine().Trim();

                if (username != Keyboard.F && username != Keyboard.f)
                {                    
                    if (username == Constants.Computer || String.IsNullOrEmpty(username))
                    {
                        consoleOutput.ThisNameIsNotAllowed();
                    }
                    else
                    {
                        players.Add(new Player(username, consoleOutput));
                    }
                }
            }

            players.Add(new Player(Constants.Computer, consoleOutput));

            consoleOutput.WelcomePlayers(players);            

            deck.DealCardsTable(table);
            deck.DealCardsPlayer(players);

            consoleOutput.ShowTableCards(table);
            consoleOutput.ShowPlayersCards(players);
        }

        public void ChooseLanguage()
        {            
            Console.WriteLine(Constants.WelcomeToCasinoGame);
            Console.WriteLine(Constants.ChooseYourLanguageEnglishEspañol);

            string userinput = Console.ReadLine();

            switch (userinput)
            {
                case Keyboard.one:
                    English english = new English();
                    GetSpeak.CopyPropertiesFromObjectToAnother(english);
                    break;
                case Keyboard.two:
                    Spanish spanish = new Spanish();
                    GetSpeak.CopyPropertiesFromObjectToAnother(spanish);
                    break;
            }
        }
    }
}
