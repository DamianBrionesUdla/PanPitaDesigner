using System;
using Assets.Core.Estructuras;
using UnityEngine;

namespace Assets.Core
{
    /// <summary>
    /// Calse que representa a un pedido en el sistema
    /// </summary>
	public class Pedido
	{
        /// <summary>
        /// Cliente del pedido
        /// </summary>
        public Cliente Cliente { get; set; }

        /// <summary>
        /// Postres del pedido
        /// </summary>
        public ListaPostres ListaPostres { get; set; }

        /// <summary>
        /// Fecha de entrega del pedido
        /// </summary>
        public DateTime FechaEntrega { get; set; }

        /// <summary>
        /// Muestra si el pedido es o no urgente
        /// </summary>
        public bool EsUrgente { get; set; }

        /// <summary>
        /// Forma de Pago del pedido
        /// </summary>
        public FormaPago FormaDePago { get; set; }

        /// <summary>
        /// Forma de entrega del pedido
        /// </summary>
        public FormaEntrega FormaDeEntrega { get; set; }

        public Estado Estado { get; set; }

        public float Precio => (ListaPostres.PrecioTotal + EsUrgente.GetPrecio() + FormaDeEntrega.GetPrecio());

        public static string CalcularNumeroOrden(Pedido pedido)
        {
            string set1 = pedido.Cliente.Nombre[0]
                    + (pedido.FechaEntrega.Day + pedido.FechaEntrega.Month + pedido.FechaEntrega.Hour).ToString("X")
                    + pedido.FechaEntrega.Year.ToString("X");
            string set2 = pedido.Cliente.Identificacion[0]
                    + (pedido.EsUrgente ? "S" : "N")
                    + pedido.ListaPostres.Contar().ToString("X");
            return set1 + "-" + set2;
        }

        public static int CalcularHorasMinimaEntrega(ListaPostres postres, bool urgente, FormaEntrega formaEntrega)
        {
            int horaEntrega = formaEntrega.GetHora();
            int horasPorPastel = 0;
            int horasSegundoPiso = 0;
            for (int i = 0; i < postres.Contar(); i++)
            {

                Postre actual = postres.ValorIndice(i);

                horasPorPastel += actual.Cantidad * urgente.GetHoraUrgente();

                horasSegundoPiso += actual.Cantidad * actual.Tamanio.GetHora();
            }

            return horasPorPastel + horasSegundoPiso + horaEntrega;
        }
    }
}
