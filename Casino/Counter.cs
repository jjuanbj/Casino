using System;
using System.Collections.Generic;
using System.Linq;

namespace Casino
{
    class Counter
    {
        public void CountPoints(List<Player> players){
            
            int firstPlayerCards = players.Where(p => p.Name != Constants.Computer)
                                          .FirstOrDefault().CapturedCards.Count;

            int computerCards = players.Where(p => p.Name == Constants.Computer)
                                       .FirstOrDefault().CapturedCards.Count;

            if (firstPlayerCards > computerCards)
            {
                // TODO: Maybe I need to instanciate Score inside Player
                players.Where(p => p.Name != Constants.Computer)
                       .FirstOrDefault().Score
                       .Add(Points.MostCards);

                if (players.Where(p => p.Name == Constants.Computer)
                           .FirstOrDefault().Score
                           .Contains(Points.MostCards))
                {
                    players.Where(p => p.Name == Constants.Computer)
                           .FirstOrDefault().Score
                           .Remove(Points.MostCards);
                }

                Console.WriteLine("Prueba: " + players.Where(p => p.Name != Constants.Computer)
                                                      .FirstOrDefault().Score
                                                      .FirstOrDefault()
                                                      .ToString());
            } else
            {
                players.Where(p => p.Name == Constants.Computer)
                       .FirstOrDefault().Score
                       .Add(Points.MostCards);

                if (players.Where(p => p.Name != Constants.Computer)
                           .FirstOrDefault().Score
                           .Contains(Points.MostCards))
                {
                    players.Where(p => p.Name != Constants.Computer)
                           .FirstOrDefault().Score
                           .Remove(Points.MostCards);
                }

                Console.WriteLine("Prueba: " + players.Where(p => p.Name == Constants.Computer)
                                                      .FirstOrDefault().Score
                                                      .FirstOrDefault()
                                                      .ToString());
            }
        }
    }
}
