using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Casino
{
    class Turn
    {
        public void TurnToPlay(Game game)
        {                        
            foreach (var player in game.Players)
            {
                game.ConsoleOutput.ItsYourTurn(player);
                
                player.Play(game.Table);                                   
            }
        }        
    }
}
