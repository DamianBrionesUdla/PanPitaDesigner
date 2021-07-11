using System;

namespace Assets.Core.Estructuras
{
	class NodoPostre
	{
		public Postre Dato { get; set; }
		public NodoPostre Anterior { get; set; }
		public NodoPostre Siguiente { get; set; }

		public NodoPostre(Postre dato, NodoPostre anterior, NodoPostre siguiente)
		{
			Dato = dato;
			Anterior = anterior;
			Siguiente = siguiente;
		}
	}

	public class ListaPostres
	{
		public float PrecioTotal => GetprecioTotal();

		private NodoPostre Inicio;
		private NodoPostre Fin;

		public ListaPostres()
		{
			Inicio = Fin = null;
		}

		public bool EsVacia()
		{
			return Inicio == null && Fin == null;
		}

		public void Agregar(Postre postre)
		{
			NodoPostre nuevo = new NodoPostre(postre, Fin, null);
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

		public Postre EliminarIndice(int indice)
		{
			if (indice > Contar() - 1)
				throw new Exception("No existe el indice " + indice + ".");

			NodoPostre aux = Inicio;
			for (int i = 0; i <= indice; i++)
			{
				if (i == indice)
				{
					if (aux == Inicio)
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
			return aux.Dato;
		}

		public int Contar()
		{
			NodoPostre aux = Inicio;
			int cont = 0;
			while (aux != null)
			{
				cont++;
				aux = aux.Siguiente;
			}
			return cont;
		}

		public Postre ValorIndice(int indice)
		{
			if (indice > Contar() - 1)
				throw new Exception("No existe el indice " + indice + ".");
			NodoPostre aux = Inicio;
			for (int i = 0; i <= indice; i++)
			{
				if (i == indice)
					break;
				aux = aux.Siguiente;
			}
			return aux.Dato;
		}

		private float GetprecioTotal()
		{

			if (EsVacia())
				return 0.0f;

			float precio = 0;
			NodoPostre aux = Inicio;
			while (aux != null)
			{
				precio += aux.Dato.Precio;
				aux = aux.Siguiente;
			}
			return precio;
		}
	}
}
