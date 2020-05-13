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
            foreach (var player in players)
            {
                Console.WriteLine(player.Name + English.ItsYourTurn);

                if (player.Name != English.Computer)
                {
                    player.Play(table, player);                    
                }
            }
        }        
    }
}
