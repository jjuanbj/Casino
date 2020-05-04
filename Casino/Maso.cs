using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Casino
{
    class Maso
    {
        private List<Carta> MasoCartas { get; set; }

        public void CrearCartas()
        {            
            var valoresCartas = Enum.GetValues(typeof(ValorCartas));
            var valoresTipoCartas = Enum.GetValues(typeof(TipoCartas));

            MasoCartas = new List<Carta>();

            foreach (TipoCartas tipoCartas in valoresTipoCartas)
            {
                foreach (ValorCartas valorCartas in valoresCartas)
                {
                    MasoCartas.Add(new Carta(tipoCartas, valorCartas));
                }
            }            
        }

        public void BarajarCartas()
        {
            var cartasBarajadas = new List<Carta>();
            
            for (int i = 0; i < (int)General.TotalCartas; i++)
            {
                Random random = new Random();
                int index = random.Next(MasoCartas.Count);
                cartasBarajadas.Add(MasoCartas[index]);
                MasoCartas.RemoveAt(index);
            }

            MasoCartas = cartasBarajadas;           
        }

        public void RepartirCartasJugadores(List<Jugador> Jugadores)
        {
            foreach (var jugador in Jugadores)
            {                
                jugador.Cartas = MasoCartas.Take((int)General.CantidadCartasARepartir).ToList();
                MasoCartas.RemoveRange((int)General.Cero, (int)General.CantidadCartasARepartir);
            }
        }

        public void RepartirCartasMesa(Mesa mesa)
        {
            mesa.Cartas = MasoCartas.Take((int)General.CantidadCartasARepartir).ToList();
            MasoCartas.RemoveRange((int)General.Cero, (int)General.CantidadCartasARepartir);
        }
    }
}
