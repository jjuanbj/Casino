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
            game.Deck.DealCardsTable(game.Table);
            game.ConsoleOutput.ShowTableCards(game.Table);
              
            while (game.Deck.DeckCards.Any())
            {                
                while (game.Players.SelectMany(p => p.Cards).Any())
                {                                                               
                    foreach (var player in game.Players)
                    {
                        game.ConsoleOutput.ItsYourTurn(player);
                        
                        player.Play(game.Table);

                        game.Counter.CountPoints(game.Players);

                        //Console.WriteLine(game.Players.SelectMany(p => p.Score == Points.MostCards));
                        // TODO: count Most Cards and Most Spades here
                    }
                }            
                
                game.Deck.DealCardsPlayer(game.Players);
            }             
        }        
    }
}
