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
            while (game.Deck.DeckCards.Any())
            {
                while (game.Players.Select(p => p.Cards).Any())
                {
                    foreach (var player in game.Players)
                    {
                        game.ConsoleOutput.ItsYourTurn(player);
                        
                        player.Play(game.Table);                                   
                    }        
                }

                game.Deck.DealCardsTable(game.Table);
                game.Deck.DealCardsPlayer(game.Players);
            }             
        }        
    }
}
