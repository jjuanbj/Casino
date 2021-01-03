using System;
using System.Collections.Generic;
using System.Linq;

namespace Casino
{
    class Counter
    {
        private int userCards = 0;
        private int computerCards = 0;
        //private Points points = new Points();

        public void CountPoints(List<Player> players)
        {
            CountMostCards(players);
            CountMostSpades(players);
            CalculateValuableCards(players);
        }

        private void CountMostCards(List<Player> players)
        {

            userCards = players.Where(p => p.Name != Constants.COMPUTER)
                               .FirstOrDefault().CapturedCards
                               .Count;

            computerCards = players.Where(p => p.Name == Constants.COMPUTER)
                                   .FirstOrDefault().CapturedCards
                                   .Count;

            CalculatePoints(players, new Point(PointName.MostCards));
        }

        private void CountMostSpades(List<Player> players)
        {

            if (players.Where(p => p.Name != Constants.COMPUTER)
                       .FirstOrDefault().CapturedCards
                       .Any(c => c.Suit == Suit.Spade))
            {
                userCards = players.Where(p => p.Name != Constants.COMPUTER)
                                   .FirstOrDefault().CapturedCards
                                   .Where(c => c.Suit == Suit.Spade)
                                   .Count();
            }

            if (players.Where(p => p.Name == Constants.COMPUTER)
                       .FirstOrDefault().CapturedCards
                       .Any(c => c.Suit == Suit.Spade))
            {
                computerCards = players.Where(p => p.Name == Constants.COMPUTER)
                                       .FirstOrDefault().CapturedCards
                                       .Where(c => c.Suit == Suit.Spade)
                                       .Count();
            }

            if (userCards != 0 || computerCards != 0)            
                CalculatePoints(players, new Point(PointName.MostSpades));                            
        }

        private void CalculatePoints(List<Player> players, Point point)
        {

            if (userCards > computerCards && !players.Any(p => p.Points
                                                     .Any(h => h.PointName == point.PointName)))
            {
                players.Where(p => p.Name != Constants.COMPUTER)
                       .FirstOrDefault().Points
                       .Add(point);

                if (players.Where(p => p.Name == Constants.COMPUTER)
                           .FirstOrDefault().Points
                           .Contains(point))
                {
                    players.Where(p => p.Name == Constants.COMPUTER)
                           .FirstOrDefault().Points
                           .Remove(point);
                }
            }
            else if (userCards < computerCards && !players.Where(p => p.Name == Constants.COMPUTER)
                                                          .FirstOrDefault().Points
                                                          .Contains(point))
            {
                players.Where(p => p.Name == Constants.COMPUTER)
                       .FirstOrDefault().Points
                       .Add(point);

                if (players.Where(p => p.Name != Constants.COMPUTER)
                           .FirstOrDefault().Points
                           .Contains(point))
                {
                    players.Where(p => p.Name != Constants.COMPUTER)
                           .FirstOrDefault().Points
                           .Remove(point);
                }
            }
            else if (userCards == computerCards && players.Any(p => p.Points
                                                          .Any(h => h.PointName == point.PointName)))
            {
                players.RemoveAll(p => p.Points
                       .Any(h => h.PointName == point.PointName));
            }

            userCards =
            computerCards = 0;
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
                                if (!player.Points.Any(p => p.PointName == PointName.AceOfClub))
                                     player.Points.Add(new Point(PointName.AceOfClub));
                                break;
                            case Suit.Diamond:
                                if (!player.Points.Any(p => p.PointName == PointName.AceOfDiamonds))
                                     player.Points.Add(new Point(PointName.AceOfDiamonds));
                                break;
                            case Suit.Heart:
                                if (!player.Points.Any(p => p.PointName == PointName.AceOfHearts))
                                     player.Points.Add(new Point(PointName.AceOfHearts));
                                break;
                            case Suit.Spade:
                                if (!player.Points.Any(p => p.PointName == PointName.AceOfSpades))
                                     player.Points.Add(new Point(PointName.AceOfSpades));
                                break;
                        }
                    }
                    else if (card.Rank == Rank.Two
                          && card.Suit == Suit.Spade)
                    {
                        if (!player.Points.Any(p => p.PointName == PointName.TwoOfSpades))
                             player.Points.Add(new Point(PointName.TwoOfSpades));

                    }
                    else if (card.Rank == Rank.Ten
                         && card.Suit == Suit.Diamond)
                    {
                        if (!player.Points.Any(p => p.PointName == PointName.TenOfDiamonds))
                             player.Points.Add(new Point(PointName.TenOfDiamonds));
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
                           .Any(h => h.PointName == PointName.Sweep)))
                {
                    players.RemoveAll(p => p.Points
                           .Any(h => h.PointName == PointName.Sweep));
                }
                else
                {
                    player.Points.Add(new Point(PointName.Sweep));
                }
            }
        }

        public void CountScore(List<Player> players)
        {
            players.ForEach(p => p.GetConsoleOutput.CountScore(p));
        }

        public void DeclareWinner(Game game)
        {
            //TODO: use a most readable code to check if there is a draw
            if (game.Players.Select(p => p.Points
                            .Sum(points => points.PointValue))
                            .ToList()
                            .Distinct()
                            .Skip(1)
                            .Any())
            {
                //System.Linq.Enumerable+SelectIPartitionIterator`2[Casino.Player,System.String]
                game.ConsoleOutput.DeclareWinner(game.Players);
            }
        }
    }
}