using System;
using System.Collections.Generic;
using System.Linq;

namespace Casino
{
    class Program
    {        
        static void Main(string[] args)
        {            
            Start start = new Start();
            start.ChooseLanguage();
            
            Game game = new Game
            {
                ConsoleOutput = new ConsoleOutput(start.Speak)
            };            
                        
            start.StartGame(game);            
            
            game.ExcecuteGame(game);
        }
    }
}
