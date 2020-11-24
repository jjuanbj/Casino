using System;
using System.Collections.Generic;
using System.Linq;

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

        public void ShowTableCards(Table table)
        {
            
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write(GetSpeak.OnTable);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(string.Format(": {0}.", 
                              string.Join(", ", table.Cards
                                    .Select(c => c.CardName))));
            
            if (table.BuildedCards != null)
            {
                #region DRY Alert!!
                if(table.BuildedCards.Any(b => b.IsMultiple == false))
                {                    
                    foreach (var buildedCard in table.BuildedCards.Where(b => b.IsMultiple == false))
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write(GetSpeak.SingleBuild);

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(string.Format(": {0}->", 
                                          string.Join(", ", table.BuildedCards                                                
                                                .Select(r => buildedCard.BuildedCardsRank)
                                                .FirstOrDefault())) +
                                          string.Format(" {0}.", 
                                          string.Join(", ", table.BuildedCards
                                                .Where(b => b.BuildedCardsRank == buildedCard.BuildedCardsRank)
                                                .SelectMany(a => buildedCard.BuildedCards, (a, b) => b.CardName))));   
                    }                    
                }
                
                if(table.BuildedCards.Any(b => b.IsMultiple == true)) 
                {
                    foreach (var buildedCard in table.BuildedCards.Where(b => b.IsMultiple == true))
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write(GetSpeak.MultipleBuild);

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(string.Format(": {0}->", 
                                          string.Join(", ", table.BuildedCards
                                                .Where(b => buildedCard.IsMultiple == true)
                                                .Select(r => buildedCard.BuildedCardsRank)
                                                .FirstOrDefault())) +
                                          string.Format(" {0}.", 
                                          string.Join(", ", table.BuildedCards
                                                .Where(b => b.BuildedCardsRank == buildedCard.BuildedCardsRank)
                                                .SelectMany(a => buildedCard.BuildedCards, (a, b) => b.CardName))));   
                    }
                }              
                #endregion  
            }
            Console.ResetColor();
        }

        public void ShowPlayersCards(List<Player> players)
        {            
            foreach (var player in players.Where(p => p.Name != Constants.Computer))
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write(player.Name);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(string.Format(": {0}.", 
                                  string.Join(", ", player.Cards
                                        .Select(c => c.CardName))));
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
                                    .Select(c => c.CardName))));
            
            Console.ResetColor();
        }

        public void SelectOneCardByIndexNumber(Player player)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write(player.Name + GetSpeak.SelectOneCardByIndexNumber);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(string.Format("{0}.", 
                              string.Join(", ", player.Cards
                                    .Select((c, count) => new { Index = count, c.CardName }))));
            
            Console.ResetColor();
        }

        public void YouSelected(List<Card> cards, string cardNumber)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write(GetSpeak.YouSelected);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(cards.ElementAt(Int32.Parse(cardNumber)).CardName);
            
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
                Console.WriteLine(table.Cards.ElementAt(Int32.Parse(cardRank)).CardName);    
            } else {
                isBuildedCard = true;

                int buildedCardsSelected = Int32.Parse(cardRank) - table.Cards.Count;
                
                var buildedCardsRank = table.BuildedCards.ElementAt(buildedCardsSelected).BuildedCardsRank;
                
                Console.Write(buildedCardsRank + "-> ");
                Console.WriteLine(string.Format(" {0}.", 
                                  string.Join(", ", table.BuildedCards
                                        .Where(b => b.BuildedCardsRank == buildedCardsRank)
                                        .SelectMany(a => a.BuildedCards, (a, b) => b.CardName))));
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
                                    .Select((c) => new { Index = cardsOnTheTable++, c.CardName }))));

            if (table.BuildedCards != null)
            {
                #region DRY Alert!!
                if(table.BuildedCards.Any(b => b.IsMultiple == false))
                {                    
                    foreach (var buildedCard in table.BuildedCards.Where(b => b.IsMultiple == false))
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write(GetSpeak.SingleBuild);

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(string.Format(": {0}->", 
                                          string.Join(", ", table.BuildedCards                                                
                                                .Select((r) => new { Index = cardsOnTheTable++, buildedCard.BuildedCardsRank})
                                                .FirstOrDefault())) +
                                          string.Format(" {0}.", 
                                          string.Join(", ", table.BuildedCards
                                                .Where(b => b.BuildedCardsRank == buildedCard.BuildedCardsRank)
                                                .SelectMany(a => buildedCard.BuildedCards, (a, b) => b.CardName))));   
                    }                    
                }
                
                if(table.BuildedCards.Any(b => b.IsMultiple == true)) 
                {
                    foreach (var buildedCard in table.BuildedCards.Where(b => b.IsMultiple == true))
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write(GetSpeak.MultipleBuild);

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(string.Format(": {0}->", 
                                          string.Join(", ", table.BuildedCards
                                                .Where(b => buildedCard.IsMultiple == true)
                                                .Select((r) => new { Index = cardsOnTheTable++, buildedCard.BuildedCardsRank})
                                                .FirstOrDefault())) +
                                          string.Format(" {0}.", 
                                          string.Join(", ", table.BuildedCards
                                                .Where(b => b.BuildedCardsRank == buildedCard.BuildedCardsRank)
                                                .SelectMany(a => buildedCard.BuildedCards, (a, b) => b.CardName))));   
                    }
                }              
                #endregion  
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
            Console.WriteLine(string.Format(": {0}.", 
                              string.Join(", ", player.CapturedCards
                                    .Select(c => c.CardName))));
            
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
                                    .Where(c => c.CardName != selectCard.CardName)
                                    .Select((c, count) => new { Index = count, c.CardName }))));
            
            Console.ResetColor();
        }
    }
}
