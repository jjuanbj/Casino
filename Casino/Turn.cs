using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

using Casino.Extension;

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
                        game.Counter.CalculateSweep(game.Players, player, game.Table);

                        foreach (var item in player.Score)
                        {
                            Console.WriteLine(player.Name + " points: " + item.GetType()
                                                                              .GetMember(item.ToString())
                                                                              .First()
                                                                              .GetCustomAttribute<DisplayAttribute>()
                                                                              .GetName());
                        }                        
                    }
                }            
                
                game.Deck.DealCardsPlayer(game.Players);
            }             
        }        
    }
}
