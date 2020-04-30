using System;
using System.Collections.Generic;
using System.Text;

namespace Casino
{
    class Jugador
    {
        public string Nombre { get; set; }
        public List<Carta> Cartas { get; set; }

        public Jugador(string nombre) {
            Nombre = nombre;
        }
    }
}
