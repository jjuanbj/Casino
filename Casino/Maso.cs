using System;
using System.Collections.Generic;
using System.Text;

namespace Casino
{
    class Maso
    {
        public List<Carta> Cartas { get; set; }

        public List<Carta> CrearCartas()
        {
            Carta carta = new Carta();

            var valoresCartas = Enum.GetValues(typeof(ValorCartas));
            foreach (ValorCartas item in valoresCartas)
            {
                carta.Valor = item;
            }
        }
    }
}
