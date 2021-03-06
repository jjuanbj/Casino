using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Casino
{
    class ConsoleOutput
    {
        public Speak GetSpeak { get; set; }

        public ConsoleOutput(Speak speak)
        {
            GetSpeak = speak;
        }

        public void WelcomeToCasinoGame()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(GetSpeak.WelcomeToCasinoGame);

            Console.ResetColor();
        }

        public void PleaseWritePlayerNamesPressFWhenFinished()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write(GetSpeak.PleaseWritePlayerNamesPress);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(GetSpeak.F);

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(GetSpeak.WhenFinished);

            Console.ResetColor();
        }

        public void PressFWhenFinished()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write(GetSpeak.Press);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(GetSpeak.F);

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(GetSpeak.WhenFinished);

            Console.ResetColor();
        }

        public void ThisNameIsNotAllowed()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(GetSpeak.ThisNameIsNotAllowed);

            Console.ResetColor();
        }

        public void ThisIsNotAnAllowedAction()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(GetSpeak.ThisIsNotAnAllowedAction);

            Console.ResetColor();
        }

        public void WelcomePlayers(List<Player> players)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write(GetSpeak.Welcome);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(string.Format(": {0}.",
                              string.Join(", ", players
                                    .Select(j => j.Name))));

            Console.ResetColor();
        }

        // TODO: merge this method with WhichCardWouldYouLikeToTakeFromTheTable
        // Or unify cards displaying 
        public void ShowTableCards(Table table)
        {

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write(GetSpeak.OnTable);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(string.Format(": {0}.",
                              string.Join(", ", table.Cards
                                    .Select(c => c.Name))));
            
            if (table.BuildedCards != null)
            {
                foreach (var buildedCard in table.BuildedCards)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    if (buildedCard.IsMultiple == true)
                        Console.Write(GetSpeak.MultipleBuild);
                    else
                        Console.Write(GetSpeak.SingleBuild);
                    
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(string.Format(" {0}->",
                                        string.Join(", ", table.BuildedCards
                                            .Select((r) => new { buildedCard.Owner })
                                            .FirstOrDefault())) +
                                        string.Format(" {0}->",
                                        string.Join(", ", table.BuildedCards
                                            .Select((r) => new { buildedCard.Name })
                                            .FirstOrDefault())) +
                                        string.Format(" {0}.",
                                        string.Join(", ", table.BuildedCards
                                            .Where(b => b.BuildedCardsRank == buildedCard.BuildedCardsRank)
                                            .SelectMany(a => buildedCard.BuildedCards, (a, b) => b.Name))));
                }
            }
        
            Console.ResetColor();
        }

        public void ShowPlayersCards(List<Player> players)
        {
            foreach (var player in players.Where(p => p.Name != Constants.COMPUTER))
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write(player.Name);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(string.Format(": {0}.",
                                  string.Join(", ", player.Cards
                                        .Select(c => c.Name))));
            }

            Console.ResetColor();
        }

        public void ShowPlayerCards(Player player)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write(GetSpeak.YourCards);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(string.Format(": {0}.",
                              string.Join(", ", player.Cards
                                    .Select(c => c.Name))));

            Console.ResetColor();
        }

        public void SelectOneCardByIndexNumber(Player player)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write(player.Name + GetSpeak.SelectOneCardByIndexNumber);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(string.Format("{0}.",
                              string.Join(", ", player.Cards
                                    .Select((c, count) => new { Index = count, c.Name }))));

            Console.ResetColor();
        }

        public void YouSelected(List<Card> cards, string cardNumber)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write(GetSpeak.YouSelected);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(cards.ElementAt(Int32.Parse(cardNumber)).Name);

            Console.ResetColor();
        }

        public bool YouSelected(Table table, string cardRank)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write(GetSpeak.YouSelected);

            bool isBuildedCard = false;

            Console.ForegroundColor = ConsoleColor.Green;
            if (table.Cards.Count > Int32.Parse(cardRank))
            {
                Console.WriteLine(table.Cards.ElementAt(Int32.Parse(cardRank)).Name);
            }
            else
            {
                isBuildedCard = true;

                int buildedCardsSelected = Int32.Parse(cardRank) - table.Cards.Count;

                var buildedCardsRank = table.BuildedCards.ElementAt(buildedCardsSelected).BuildedCardsRank;

                Console.Write(buildedCardsRank + "-> ");
                Console.WriteLine(string.Format(" {0}.",
                                  string.Join(", ", table.BuildedCards
                                        .Where(b => b.BuildedCardsRank == buildedCardsRank)
                                        .SelectMany(a => a.BuildedCards, (a, b) => b.Name))));
            }

            Console.ResetColor();

            return isBuildedCard;
        }

        public void TypeValidCardNumber()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(GetSpeak.TypeValidCardNumber);

            Console.ResetColor();
        }

        public void YouJustLostYourCardBecauseItIsInvalid()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(GetSpeak.YouJustLostYourCardBecauseItIsInvalid);

            Console.ResetColor();
        }

        public void ChooseOneAction(Table table)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(GetSpeak.ChooseOneAction);

            Console.ResetColor();
        }

        public int WhichCardWouldYouLikeToTakeFromTheTable(Table table)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write(GetSpeak.WhichCardWouldYouLikeToTakeFromTheTable);

            int cardsOnTheTable = 0;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(string.Format("{0}.",
                              string.Join(", ", table.Cards
                                    .Select((c) => new { Index = cardsOnTheTable++, c.Name }))));

            if (table.BuildedCards != null)
            {
                foreach (var buildedCard in table.BuildedCards)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    if (buildedCard.IsMultiple == true)
                        Console.Write(GetSpeak.MultipleBuild);
                    else
                        Console.Write(GetSpeak.SingleBuild);

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(string.Format(" {0}->",
                                      string.Join(", ", table.BuildedCards
                                            .Select((r) => new { Index = cardsOnTheTable++, buildedCard.Owner })
                                            .FirstOrDefault())) +
                                      string.Format(" {0}->",
                                      string.Join(", ", table.BuildedCards
                                            .Select((r) => new { buildedCard.Name })
                                            .FirstOrDefault())) +
                                      string.Format(" {0}.",
                                      string.Join(", ", table.BuildedCards
                                            .Where(b => b.BuildedCardsRank == buildedCard.BuildedCardsRank)
                                            .SelectMany(a => buildedCard.BuildedCards, (a, b) => b.Name))));
                }
            }

            Console.ResetColor();

            return cardsOnTheTable;
        }

        public void ItsYourTurn(Player player)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(player.Name);

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(GetSpeak.ItsYourTurn);

            Console.ResetColor();
        }

        public void ShowCapturedCards(Player player)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write(GetSpeak.CapturedCards);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(string.Format(" {0}.",
                              string.Join(", ", player.CapturedCards
                                    .Select(c => c.Name))));

            Console.ResetColor();
        }

        public void PressAIfYouWantToSelectAnotherAction()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write(GetSpeak.Press);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(GetSpeak.A);

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(GetSpeak.IfYouWantToSelectAnotherAction);

            Console.ResetColor();
        }

        public void SelectYourBuildingRank(Player player, Card selectCard)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write(player.Name + GetSpeak.SelectYourBuildingRank);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(string.Format("{0}.",
                              string.Join(", ", player.Cards
                                    .Where(c => c.Name != selectCard.Name)
                                    .Select((c, count) => new { Index = count, c.Name }))));

            Console.ResetColor();
        }

        public void YouCannotThrowCardsWhenYouAreABuildingCardOwner()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(GetSpeak.YouCannotThrowCardsWhenYouAreABuildingCardOwner);

            Console.ResetColor();
        }

        public void IfYouDontHaveMoreMoveYouMustCaptureYourBuildingCard()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(GetSpeak.IfYouDontHaveMoreMoveYouMustCaptureYourBuildingCard);

            Console.ResetColor();
        }

        public void CountScore(Player player)
        {
            Console.WriteLine(GetSpeak.Player
                            + player.Name
                            + GetSpeak.Score
                            + player.Points.Sum(points => points.PointValue));
        }

        public void DeclareWinner(List<Player> players)
        {
            Console.WriteLine(GetSpeak.Winner + players.OrderByDescending(p => p.Points
                                                       .Sum(h => h.PointValue))
                                                       .Select(w => w.Name)
                                                       .First());
        }

        public void ShowPlayerPoints(Player player)
        {
            // TODO: avoid nested foreach
            foreach (var points in player.Points)
            {
                foreach (var property in GetSpeak.GetType()
                                                 .GetProperties()
                                                 .Select(p => p.Name)
                                                 .ToList())
                {
                    if (points.PointName.ToString().Equals(property))
                    {
                        Console.WriteLine(player.Name + GetSpeak.Points + GetSpeak.GetType()
                                                                                  .GetProperty(property)
                                                                                  .GetValue(GetSpeak));
                    }
                }
            }
        }
    }
}