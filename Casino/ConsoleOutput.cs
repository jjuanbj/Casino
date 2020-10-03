using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
//using Console = Colorful.Console;

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
            Console.WriteLine(string.Format(": {0}."
                , string.Join(", ", players.Select(j => j.Name))));
            
            Console.ResetColor();
        }

        public void ShowTableCards(Table table)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write(GetSpeak.OnTable);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(string.Format(": {0}."
                , string.Join(", ", table.Cards.Select(c => c.CardName))));

            if (table.BuildedCards != null)
            {
                Console.WriteLine(table.BuildedCards.FirstOrDefault().BuildedCardsRank);
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
                Console.WriteLine(string.Format(": {0}."
                    , string.Join(", ", player.Cards.Select(c => c.CardName))));
            }

            Console.ResetColor();
        }

        public void ShowPlayerCards(Player player)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write(GetSpeak.YourCards);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(string.Format(": {0}."
                , string.Join(", ", player.Cards.Select(c => c.CardName))));
            
            Console.ResetColor();
        }

        public void SelectOneCardByIndexNumber(Player player)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write(player.Name + GetSpeak.SelectOneCardByIndexNumber);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(string.Format("{0}."
            , string.Join(", ", player.Cards.Select((c, count) => new { Index = count, c.CardName }))));
            
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

        public void ChooseOneAction()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(GetSpeak.ChooseOneAction);
            
            Console.ResetColor();
        }

        public void WhichCardWouldYouLikeToTakeFromTheTable(Table table)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write(GetSpeak.WhichCardWouldYouLikeToTakeFromTheTable);
            
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(string.Format("{0}."
            , string.Join(", ", table.Cards.Select((c, count) => new { Index = count, c.CardName }))));
            
            Console.ResetColor();
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
            Console.WriteLine(string.Format(": {0}."
                , string.Join(", ", player.CapturedCards.Select(c => c.CardName))));
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
            Console.WriteLine(string.Format("{0}."
            , string.Join(", ", player.Cards.Where(c => c.CardName != selectCard.CardName)
                                    .Select((c, count) => new { Index = count, c.CardName }))));
            
            Console.ResetColor();
        }
    }
}
