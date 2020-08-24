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
        public void TurnToPlay(Game game)
        {                        
            foreach (var player in game.Players)
            {
                game.ConsoleOutput.ItsYourTurn(player);
                
                if (player.Name != Constants.Computer)
                {
                    player.Play(game.Table);                    
                }
            }
        }        
    }
}
