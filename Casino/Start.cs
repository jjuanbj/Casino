using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Casino
{
    class Start
    {                
        public void StartGame(Deck deck, List<Player> players, Table table)
        {            
            deck.CreateCards();
            deck.ShuffleCards();

            ConsoleOutput consoleOutput = new ConsoleOutput();

            consoleOutput.WelcomeToCasinoGame();

            // Debo usar Computer en un enum para no instanciar speak aquí
            Speak speak = new Speak();

            speak.ChooseLanguage();

            string username = "";            

            while (username != Keyboard.F && username != Keyboard.f)
            {
                consoleOutput.PleaseWritePlayerNamesPressFWhenFinished();

                username = Console.ReadLine().Trim();

                if (username != Keyboard.F && username != Keyboard.f)
                {                    
                    if (username == speak.Computer || String.IsNullOrEmpty(username))
                    {
                        consoleOutput.ThisNameIsNotAllowed();
                    }
                    else
                    {
                        players.Add(new Player(username));
                    }
                }
            }

            players.Add(new Player(speak.Computer));

            consoleOutput.WelcomePlayers(players);            

            deck.DealCardsTable(table);
            deck.DealCardsPlayer(players);

            consoleOutput.ShowTableCards(table);
            consoleOutput.ShowPlayersCards(players);
        }        
    }
}
