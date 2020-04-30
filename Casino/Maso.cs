using System;
using System.Collections.Generic;
using System.Text;

namespace Casino
{
    class Maso
    {
        public List<Carta> Cartas { get; set; }

        public void CrearCartas()
        {
            Carta carta = new Carta();

            var valoresCartas = Enum.GetValues(typeof(ValorCartas));
            var valoresTipoCartas = Enum.GetValues(typeof(TipoCartas));

            Cartas = new List<Carta>();

            foreach (TipoCartas tipoCartas in valoresTipoCartas)
            {
                carta.Tipo = tipoCartas;

                foreach (ValorCartas valorCartas in valoresCartas)
                {
                    carta.Valor = valorCartas;

                    Cartas.Add(carta);
                }
            }            
        }
    }
}
