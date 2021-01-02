using System;
using System.Collections.Generic;
using System.Linq;

namespace Casino
{
    class Counter
    {
        private int userCards = 0;

        private int computerCards = 0;

        private Points points = new Points();

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

            CalculatePoints(players, points.Score.Where(p => p.PointName == Constants.MOST_CARDS).FirstOrDefault());
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
                CalculatePoints(players, points.Score.Where(p => p.PointName == Constants.MOST_SPADES).FirstOrDefault());                            
        }

        private void CalculatePoints(List<Player> players, Points.Point point)
        {

            if (userCards > computerCards && !players.Any(p => p.Hit.Score
                                                     .Any(h => h.PointName == point.PointName)))
            {
                players.Where(p => p.Name != Constants.COMPUTER)
                       .FirstOrDefault().Hit.Score
                       .Add(point);

                if (players.Where(p => p.Name == Constants.COMPUTER)
                           .FirstOrDefault().Hit.Score
                           .Contains(point))
                {
                    players.Where(p => p.Name == Constants.COMPUTER)
                           .FirstOrDefault().Hit.Score
                           .Remove(point);
                }
            }
            else if (userCards < computerCards && !players.Where(p => p.Name == Constants.COMPUTER)
                                                          .FirstOrDefault().Hit.Score
                                                          .Contains(point))
            {
                players.Where(p => p.Name == Constants.COMPUTER)
                       .FirstOrDefault().Hit.Score
                       .Add(point);

                if (players.Where(p => p.Name != Constants.COMPUTER)
                           .FirstOrDefault().Hit.Score
                           .Contains(point))
                {
                    players.Where(p => p.Name != Constants.COMPUTER)
                           .FirstOrDefault().Hit.Score
                           .Remove(point);
                }
            }
            else if (userCards == computerCards && players.Any(p => p.Hit.Score
                                                          .Any(h => h.PointName == point.PointName)))
            {
                players.FirstOrDefault().Hit.Score
                       .Remove(point);
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
                                if (!player.Hit.Score.Any(p => p.PointName.Equals(Constants.ACE_OF_CLUBS)))
                                    player.Hit.Score.Add(new Points.Point(Constants.ACE_OF_CLUBS));
                                break;
                            case Suit.Diamond:
                                if (!player.Hit.Score.Any(p => p.PointName.Equals(Constants.ACE_OF_DIAMONDS)))
                                    player.Hit.Score.Add(new Points.Point(Constants.ACE_OF_DIAMONDS));
                                break;
                            case Suit.Heart:
                                if (!player.Hit.Score.Any(p => p.PointName.Equals(Constants.ACE_OF_HEARTS)))
                                    player.Hit.Score.Add(new Points.Point(Constants.ACE_OF_HEARTS));
                                break;
                            case Suit.Spade:
                                if (!player.Hit.Score.Any(p => p.PointName.Equals(Constants.ACE_OF_SPADES)))
                                    player.Hit.Score.Add(new Points.Point(Constants.ACE_OF_SPADES));
                                break;
                        }
                    }
                    else if (card.Rank == Rank.Two
                          && card.Suit == Suit.Spade)
                    {
                        if (!player.Hit.Score.Any(p => p.PointName.Equals(Constants.TWO_OF_SPADES)))
                            player.Hit.Score.Add(new Points.Point(Constants.TWO_OF_SPADES));

                    }
                    else if (card.Rank == Rank.Ten
                         && card.Suit == Suit.Diamond)
                    {
                        if (!player.Hit.Score.Any(p => p.PointName.Equals(Constants.TEN_OF_DIAMONDS)))
                            player.Hit.Score.Add(new Points.Point(Constants.TEN_OF_DIAMONDS));
                    }
                }
            }
        }

        public void CalculateSweep(List<Player> players, Player player, Table table)
        {
            if (!table.Cards.Any())
            {
                if (players.Where(p => p.Name != player.Name)
                           .Any(s => s.Hit.Score
                           .Any(h => h.PointName == Constants.SWEEP)))
                {
                    players.RemoveAll(p => p.Hit.Score
                           .Select(h => h.PointName)
                           .Equals(Constants.SWEEP));
                }
                else
                {
                    player.Hit.Score.Add(new Points.Point(Constants.SWEEP));
                }
            }
        }

        public void CountScore(List<Player> players)
        {
            players.ForEach(p => p.GetConsoleOutput.CountScore(p));
        }

        public void DeclareWinner(Game game)
        {
            if (game.Players.Select(p => p.Hit.Score.Count).ToList().Distinct().Skip(1).Any())
            {
                game.ConsoleOutput.DeclareWinner(game.Players);
            }
        }
    }
}