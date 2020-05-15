using System;
using System.Collections.Generic;
using System.Text;

namespace Casino
{
    class Spanish
    {
        /*public const string WelcomeToCasinoGame = "¡Bienvenido al juego de casino!";

        public const string PleaseWritePlayerNamesPressFWhenFinished = "Por favor, escribe el nombre de los jugadores, presiona F cuando termines";

        public const string Welcome = "Bienvenido";

        public const string Computer = "Computer";

        public const string ThisNameIsNotAllowed = "Este nombre no está permitido.";

        public const string OnTable = "En la mesa";

        public const string ItsYourTurn = " es tu turno!";

        public const string SelectOneCardByIndexNumber = " selecciona una carta por su número de orden: ";

        public const string YouSelected = "Has seleccionado: ";

        public const string TypeValidCardNumber = "Escribe un número de carta válido.";

        public const string ChooseOneAction = "Elige una acción: 1- Lanza la carta sobre la mesa, 2-Toma una carta de la mesa";*/

        public string WelcomeToCasinoGame { get; set; }

        public string PleaseWritePlayerNamesPressFWhenFinished { get; set; }

        public string Welcome { get; set; }
        
        public Spanish()
        {
            WelcomeToCasinoGame = "Welcome to casino game!";
            PleaseWritePlayerNamesPressFWhenFinished = "Please write player names, press F when finished";
            Welcome = "Welcome";
        }
    }
}
