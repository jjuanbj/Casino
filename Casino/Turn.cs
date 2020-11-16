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
                // TODO: check why not deal cards when there is no cards to play 
                while (game.Players.Select(p => p.Cards).Any())
                {                                                               
                    foreach (var player in game.Players)
                    {
                        game.ConsoleOutput.ItsYourTurn(player);
                        
                        player.Play(game.Table);                                   
                    }

                    // foreach (var player in game.Players.Where(p => p.Name != Constants.Computer))
                    // {
                    //     Console.ForegroundColor = ConsoleColor.Magenta;
                    //     int test = game.Players.Select(p => p.Cards).Count();

                    //     Console.WriteLine("TEST PLAYERS CARDS" + test);
                    //     Console.Write(player.Name);
                        
                    //     Console.ForegroundColor = ConsoleColor.Green;
                    //     Console.WriteLine(string.Format(": {0}.",
                    //                       string.Join(", ", player.Cards
                    //                             .Select(c => c.CardName))));
                    // }

                    // Console.ResetColor();
                }                

                Console.WriteLine("Prueba");
                game.Deck.DealCardsTable(game.Table);
                game.Deck.DealCardsPlayer(game.Players);
            }             
        }        
    }
}
