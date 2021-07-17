using System;
using UnityEngine;

namespace Assets.Core.Estructuras
{
    /// <summary>
    /// Nodo de la Lista de pedidos
    /// </summary>
    class NodoPedido
    {
        /// <summary>
        /// Pedido en el nodo
        /// </summary>
        public Pedido Dato { get; set; }

        /// <summary>
        /// Nodo anterior en la lista
        /// </summary>
        public NodoPedido Anterior { get; set; }

        /// <summary>
        /// Nosod Siquiente en la lista
        /// </summary>
        public NodoPedido Siguiente { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dato">Pedido del nodo</param>
        /// <param name="anterior">nodo anterior en la lista</param>
        /// <param name="siguiente">nodo siguiente en la lista</param>
        public NodoPedido(Pedido dato, NodoPedido anterior, NodoPedido siguiente)
        {
            Dato = dato;
            Anterior = anterior;
            Siguiente = siguiente;
        }
    }

    /// <summary>
    /// Lista de Pedidos
    /// </summary>
    class ListaPedidos
    {
        /// <summary>
        /// Retorna la fecha ultima en los pedidos
        /// </summary>
        public DateTime FechaUltimo => GetFechaUltimo();

        /// <summary>
        /// Nodo inicio
        /// </summary>
        private NodoPedido Inicio;

        /// <summary>
        /// Nodo fin
        /// </summary>
        private NodoPedido Fin;

        /// <summary>
        /// Constructor sin parametros
        /// </summary>
        public ListaPedidos()
        {
            Inicio = Fin = null;
        }

        /// <summary>
        /// Determina si la Lista esta vacia
        /// </summary>
        /// <returns>verdadero si esta vacia sino falso</returns>
        public bool EsVacia()
        {
            return Inicio == null && Fin == null;
        }

        /// <summary>
        /// Agrega un pedido al final de la lista
        /// </summary>
        /// <param name="pedido">pedido a agregar</param>
        public void Agregar(Pedido pedido)
        {
            NodoPedido nuevo = new NodoPedido(pedido, Fin, null);
            if (EsVacia())
            {
                Fin = Inicio = nuevo;
            }
            else
            {
                nuevo.Anterior.Siguiente = nuevo;
                Fin = nuevo;
            }
        }

        /// <summary>
        /// Retorna la fecha de entrega del ultimo pedido en la lista
        /// </summary>
        /// <returns>fecha de entrega</returns>
        private DateTime GetFechaUltimo()
        {
            if (EsVacia())
            {
                return DateTime.Now;
            }

            return Fin.Dato.FechaEntrega;

        }

        /// <summary>
        /// Cuenta la cantidad de pedidos
        /// </summary>
        /// <returns>numero de pedidos</returns>
        public int Contar()
        {
            NodoPedido aux = Inicio;
            int cont = 0;
            while (aux != null)
            {
                cont++;
                aux = aux.Siguiente;
            }
            return cont;
        }

        /// <summary>
        /// Retorna el pedido segun indice
        /// </summary>
        /// <param name="indice">indice</param>
        /// <returns>pedido</returns>
        public Pedido ValorIndice(int indice)
        {
            if (indice > Contar()-1)
                throw new Exception("No existe el indice " + indice + ".");
		    NodoPedido aux = Inicio;
            for (int i = 0; i <= indice; i++)
            {
                if (i == indice)
                    break;
                aux = aux.Siguiente;
            }
            return aux.Dato;
        }

        public ListaPedidos Donde(System.Func<Pedido, bool> expresion)
		{
            ListaPedidos retorno = new ListaPedidos();

            NodoPedido aux = Inicio;
            while (aux != null)
			{
                if (expresion(aux.Dato))
                    retorno.Agregar(aux.Dato);
                aux = aux.Siguiente;
			}

            return retorno;
		}

        public Pedido EliminarObjeto(Pedido objeto)
        {
            NodoPedido aux = Inicio;
            while (aux != null)
            {
                if (objeto.Equals(aux.Dato))
                {
                    if (aux == Inicio && aux == Fin)
                    {
                        Inicio = null;
                        Fin = null;
                    }
                    else if (aux == Inicio)
                    {
                        Inicio = aux.Siguiente;
                        aux.Siguiente.Anterior = null;
                        aux.Siguiente = null;
                    }
                    else if (aux == Fin)
                    {
                        Fin = aux.Anterior;
                        aux.Anterior.Siguiente = null;
                        aux.Anterior = null;
                    }
                    else
                    {
                        aux.Anterior.Siguiente = aux.Siguiente;
                        aux.Siguiente.Anterior = aux.Anterior;
                        aux.Siguiente = null;
                        aux.Anterior = null;
                    }
                    break;
                }
                aux = aux.Siguiente;
            }
            return aux?.Dato;
        }
    }
}

