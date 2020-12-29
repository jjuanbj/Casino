using System;
using System.Collections.Generic;
using System.Linq;

namespace Casino
{
    class Counter
    {
        private int userCards = 0;

        private int computerCards = 0;

        public void CountPoints(List<Player> players)
        {
            CountMostCards(players);            
            CountMostSpades(players);
            CalculateValuableCards(players);
        }

        private void CountMostCards(List<Player> players){

            userCards = players.Where(p => p.Name != Constants.Computer)
                               .FirstOrDefault().CapturedCards
                               .Count;

            computerCards = players.Where(p => p.Name == Constants.Computer)
                                   .FirstOrDefault().CapturedCards
                                   .Count;

            CalculatePoints(players, Points.MostCards);            
        }

        private void CountMostSpades(List<Player> players){

            if (players.Where(p => p.Name != Constants.Computer)
                       .FirstOrDefault().CapturedCards
                       .Any(c => c.Suit == Suit.Spade))
            {
                userCards = players.Where(p => p.Name != Constants.Computer)
                                   .FirstOrDefault().CapturedCards
                                   .Where(c => c.Suit == Suit.Spade)
                                   .Count();    
            }
            
            if (players.Where(p => p.Name == Constants.Computer)
                       .FirstOrDefault().CapturedCards
                       .Any(c => c.Suit == Suit.Spade))
            {
                computerCards = players.Where(p => p.Name == Constants.Computer)
                                       .FirstOrDefault().CapturedCards
                                       .Where(c => c.Suit == Suit.Spade)
                                       .Count();
            }

            CalculatePoints(players, Points.MostSpades);
        }

        private void CalculatePoints(List<Player> players, Points points){

            if (userCards > computerCards && !players.Where(p => p.Name != Constants.Computer)
                                                     .FirstOrDefault().Points
                                                     .Contains(points))
            {
                players.Where(p => p.Name != Constants.Computer)
                       .FirstOrDefault().Points
                       .Add(points);

                players.Where(p => p.Name != Constants.Computer)
                       .FirstOrDefault().Score
                       .Add((int)points);

                if (players.Where(p => p.Name == Constants.Computer)
                           .FirstOrDefault().Points
                           .Contains(points))
                {
                    players.Where(p => p.Name == Constants.Computer)
                           .FirstOrDefault().Points
                           .Remove(points);

                    players.Where(p => p.Name == Constants.Computer)
                           .FirstOrDefault().Score
                           .Remove((int)points);
                }
            }
            else if (userCards < computerCards && !players.Where(p => p.Name == Constants.Computer)
                                                          .FirstOrDefault().Points
                                                          .Contains(points))
            {
                players.Where(p => p.Name == Constants.Computer)
                       .FirstOrDefault().Points
                       .Add(points);

                players.Where(p => p.Name == Constants.Computer)
                       .FirstOrDefault().Score
                       .Add((int)points);

                if (players.Where(p => p.Name != Constants.Computer)
                           .FirstOrDefault().Points
                           .Contains(points))
                {
                    players.Where(p => p.Name != Constants.Computer)
                           .FirstOrDefault().Points
                           .Remove(points);

                    players.Where(p => p.Name != Constants.Computer)
                           .FirstOrDefault().Score
                           .Remove((int)points);
                }
            }
            else if (userCards == computerCards && players.SelectMany(p => p.Points)
                                                          .Contains(points))
            {
                players.FirstOrDefault().Points
                       .Remove(points);

                players.FirstOrDefault().Score
                       .Remove((int)points);             
            }
        }

        private void CalculateValuableCards(List<Player> players)
        {
            foreach (var player in players)
            {
                foreach (var card in player.CapturedCards)
                {
                    if (card.Rank == Rank.Ace)
                    {                        
                        switch (card.Suit)
                        {
                            case Suit.Club:
                                if (!player.Points.Contains(Points.AceOfClubs))                                
                                     player.Points.Add(Points.AceOfClubs);                                                                    
                                break;
                            case Suit.Diamond:
                                if (!player.Points.Contains(Points.AceOfDiamonds))
                                     player.Points.Add(Points.AceOfDiamonds);
                                break;
                            case Suit.Heart:
                                if (!player.Points.Contains(Points.AceOfHearts))
                                     player.Points.Add(Points.AceOfHearts);
                                break;
                            case Suit.Spade:
                                if (!player.Points.Contains(Points.AceOfSpades))
                                     player.Points.Add(Points.AceOfSpades);
                                break;
                        }
                    } else if (card.Rank == Rank.Two
                            && card.Suit == Suit.Spade
                            && !player.Points.Contains(Points.TwoOfSpades)) 
                    {
                        player.Points.Add(Points.TwoOfSpades);

                    } else if(card.Rank == Rank.Ten
                           && card.Suit == Suit.Diamond
                           && !player.Points.Contains(Points.TenOfDiamonds))
                    {
                        player.Points.Add(Points.TenOfDiamonds);
                    }
                }
            }
        }

        public void CalculateSweep(List<Player> players, Player player, Table table) 
        {
            if (!table.Cards.Any())
            {
                if (players.Where(p => p.Name != player.Name)
                           .Any(s => s.Points
                           .Contains(Points.Sweep)))
                {                   
                    players.RemoveAll(p => p.Points
                           .Contains(Points.Sweep));
                } else
                {
                    player.Points.Add(Points.Sweep);   
                }                
            }            
        }

        public void CountScore(List<Player> players) 
        {
            players.ForEach(p => p.GetConsoleOutput.CountScore(p));
        }

        public void DeclareWinner(Game game)
        {
            if (game.Players.Select(p => p.Points.Count).ToList().Distinct().Skip(1).Any())
            {
                game.ConsoleOutput.DeclareWinner(game.Players);
            }
        }
    }
}
