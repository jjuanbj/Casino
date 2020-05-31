using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

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
            Console.WriteLine(GetSpeak.WelcomeToCasinoGame);
        }

        public void PleaseWritePlayerNamesPressFWhenFinished()
        {
            Console.WriteLine(GetSpeak.PleaseWritePlayerNamesPressFWhenFinished);
        }

        public void ThisNameIsNotAllowed()
        {
            Console.WriteLine(GetSpeak.ThisNameIsNotAllowed);
        }

        public void WelcomePlayers(List<Player> players)
        {
            Console.WriteLine(string.Format(GetSpeak.Welcome + ": {0}."
                , string.Join(", ", players.Select(j => j.Name))));
        }

        public void ShowTableCards(Table table)
        {
            Console.WriteLine(string.Format(GetSpeak.OnTable + ": {0}."
                , string.Join(", ", table.Cards.Select(c => c.CardName))));
        }

        public void ShowPlayersCards(List<Player> players)
        {
            foreach (var player in players.Where(p => p.Name != Constants.Computer))
            {
                Console.WriteLine(string.Format(player.Name + ": {0}."
                    , string.Join(", ", player.Cards.Select(c => c.CardName))));
            }
        }

        public void ShowPlayerCards(Player player)
        {
            Console.WriteLine(string.Format(GetSpeak.YourCards + ": {0}."
                , string.Join(", ", player.Cards.Select(c => c.CardName))));
        }

        public void SelectOneCardByIndexNumber(Player player)
        {
            Console.WriteLine(string.Format(player.Name + GetSpeak.SelectOneCardByIndexNumber + "{0}.", string.Join(", ", player.Cards.Select((c, count) => new { Index = count, c.CardName }))));
        }

        public void YouSelected(List<Card> cards, string cardNumber)
        {
            Console.WriteLine(GetSpeak.YouSelected + cards.ElementAt(Int32.Parse(cardNumber)).CardName);            
        }

        public void TypeValidCardNumber()
        {
            Console.WriteLine(GetSpeak.TypeValidCardNumber);
        }

        public void ChooseOneAction()
        {
            Console.WriteLine(GetSpeak.ChooseOneAction);
        }

        public void WhichCardWouldYouLikeToTakeFromTheTable(Table table)
        {
            Console.WriteLine(string.Format(GetSpeak.WhichCardWouldYouLikeToTakeFromTheTable 
                + "{0}.", string.Join(", ", table.Cards.Select((c, count) => new { Index = count, c.CardName }))));
        }

        public void ItsYourTurn(Player player)
        {
            Console.WriteLine(player.Name + GetSpeak.ItsYourTurn);
        }

        public void ShowCapturedCards(Player player)
        {
            Console.WriteLine(string.Format(GetSpeak.CapturedCards + ": {0}."
                , string.Join(", ", player.CapturedCards.Select(c => c.CardName))));
        }
    }
}
