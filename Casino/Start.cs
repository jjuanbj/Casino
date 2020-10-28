using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Drawing;
using Casino.Extension;

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
            
            while (username != Keyboard.UPPERCASE_F && username != Keyboard.LOWERCASE_F)
            {
                game.ConsoleOutput.PleaseWritePlayerNamesPressFWhenFinished();

                username = Console.ReadLine().Trim();

                if (username != Keyboard.UPPERCASE_F && username != Keyboard.LOWERCASE_F)
                {                    
                    if (username == Constants.Computer || String.IsNullOrEmpty(username))
                    {
                        game.ConsoleOutput.ThisNameIsNotAllowed();
                    }
                    else
                    {
                        game.Players.Add(new Player(username, game.ConsoleOutput));                        
                    }                    
                } else if (!game.Players.Any()) {
                    username = "";
                }                
            }

            game.Players.Add(new Computer());

            game.ConsoleOutput.WelcomePlayers(game.Players);            

            game.Deck.DealCardsTable(game.Table);
            game.Deck.DealCardsPlayer(game.Players);

            game.ConsoleOutput.ShowTableCards(game.Table);
            game.ConsoleOutput.ShowPlayersCards(game.Players);
        }

        public void ChooseLanguage()
        {           
            Console.ForegroundColor = ConsoleColor.Yellow;
            const string WELCOME_TO_CASINO_GAME = "Welcome to Casino Game!";
            Console.WriteLine(WELCOME_TO_CASINO_GAME);

            Console.ForegroundColor = ConsoleColor.Magenta;
            const string CHOOSE_YOUR_LANGUAGE = "Choose your language: ";
            Console.Write(CHOOSE_YOUR_LANGUAGE);

            Console.ForegroundColor = ConsoleColor.Green;
            const string ENGLISH_ESPANOL = "1- English, 2- Español";
            Console.WriteLine(ENGLISH_ESPANOL);
            
            Console.ResetColor();

            string userinput = "";

            while (userinput != Keyboard.ONE && userinput != Keyboard.TWO){
                
                userinput = Console.ReadLine().Trim();

                switch (userinput)
                {
                    case Keyboard.ONE:
                        English english = new English();
                        GetSpeak.CopyPropertiesFromObjectToAnother(english);
                        break;
                    case Keyboard.TWO:
                        Spanish spanish = new Spanish();
                        GetSpeak.CopyPropertiesFromObjectToAnother(spanish);
                        break;                                        
                }
            }            
        }
    }
}
