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
        public void StartGame(Game game)
        {            
            game.Deck.CreateCards();
            game.Deck.ShuffleCards();                        

            string username = "";            

            while (username != Keyboard.F && username != Keyboard.f)
            {
                game.ConsoleOutput.PleaseWritePlayerNamesPressFWhenFinished();

                username = Console.ReadLine().Trim();

                if (username != Keyboard.F && username != Keyboard.f)
                {                    
                    if (username == Constants.Computer || String.IsNullOrEmpty(username))
                    {
                        game.ConsoleOutput.ThisNameIsNotAllowed();
                    }
                    else
                    {
                        game.Players.Add(new Player(username, game.ConsoleOutput));
                    }
                }
            }

            game.Players.Add(new Player(Constants.Computer, game.ConsoleOutput));

            game.ConsoleOutput.WelcomePlayers(game.Players);            

            game.Deck.DealCardsTable(game.Table);
            game.Deck.DealCardsPlayer(game.Players);

            game.ConsoleOutput.ShowTableCards(game.Table);
            game.ConsoleOutput.ShowPlayersCards(game.Players);
        }

        public void ChooseLanguage()
        {            
            Console.WriteLine(Constants.WelcomeToCasinoGame);
            Console.WriteLine(Constants.ChooseYourLanguageEnglishEspañol);

            string userinput = Console.ReadLine();

            switch (userinput)
            {
                case Keyboard.One:
                    English english = new English();
                    GetSpeak.CopyPropertiesFromObjectToAnother(english);
                    break;
                case Keyboard.Two:
                    Spanish spanish = new Spanish();
                    GetSpeak.CopyPropertiesFromObjectToAnother(spanish);
                    break;
            }
        }
    }
}
