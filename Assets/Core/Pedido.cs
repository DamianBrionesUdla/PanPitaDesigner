using System;
using Assets.Core.Estructuras;

namespace Assets.Core
{
	public class Pedido
	{
        public Cliente Cliente { get; set; }
        public ListaPostres ListaPostres { get; set; }
        public DateTime FechaEntrega { get; set; }
        public bool Urgente { get; set; }
        public FormaPago MetodoPago { get; set; }
        public FormaEntrega entrega { get; set; }
    }
}
