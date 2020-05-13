using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace Casino
{
    class ConsoleOutput
    {
        public void WelcomeToCasinoGame()
        {
            Console.WriteLine(English.WelcomeToCasinoGame);
        }

        public void PleaseWritePlayerNamesPressFWhenFinished()
        {
            Console.WriteLine(English.PleaseWritePlayerNamesPressFWhenFinished);
        }

        public void ThisNameIsNotAllowed()
        {
            Console.WriteLine(English.ThisNameIsNotAllowed);
        }

        public void WelcomePlayers(List<Player> players)
        {
            Console.WriteLine(string.Format(English.Welcome + ": {0}."
                , string.Join(", ", players.Select(j => j.Name))));
        }

        public void ShowTableCards(Table table)
        {
            Console.WriteLine(string.Format(English.OnTable + ": {0}."
                , string.Join(", ", table.Cards.Select(c => c.CardName))));
        }

        public void ShowPlayersCards(List<Player> players)
        {
            foreach (var player in players.Where(p => p.Name != English.Computer))
            {
                Console.WriteLine(string.Format(player.Name + ": {0}."
                    , string.Join(", ", player.Cards.Select(c => c.CardName))));
            }
        }

        public void ShowPlayerCards(Player player)
        {
            Console.WriteLine(string.Format(English.OnTable + ": {0}."
                , string.Join(", ", player.Cards.Select(c => c.CardName))));
        }

        public void SelectOneCardByIndexNumber(Player player)
        {
            Console.WriteLine(string.Format(player.Name + English.SelectOneCardByIndexNumber + "{0}.", string.Join(", ", player.Cards.Select((c, count) => new { Index = count, c.CardName }))));
        }

        public void YouSelected(List<Card> cards, string cardNumber)
        {
            Console.WriteLine(English.YouSelected + cards.ElementAt(Int32.Parse(cardNumber)).CardName);            
        }

        public void TypeValidCardNumber()
        {
            Console.WriteLine(English.TypeValidCardNumber);
        }

        public void ChooseOneAction()
        {
            Console.WriteLine(English.ChooseOneAction);
        }

        public void ChooseLanguage()
        {
            Console.WriteLine("Choose your language: 1- English, 2- Español");
        }
    }
}
