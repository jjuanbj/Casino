using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace Casino
{
    class Turn
    {
        public void TurnToPlay(List<Player> players, Table table)
        {
            ConsoleOutput consoleOutput = new ConsoleOutput();

            // Debo usar Computer en un enum para no instanciar speak aquí
            Speak speak = new Speak();

            foreach (var player in players)
            {
                consoleOutput.ItsYourTurn(player);
                
                if (player.Name != speak.Computer)
                {
                    player.Play(table, player);                    
                }
            }
        }        
    }
}
