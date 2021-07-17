using System;

namespace Assets.Core.Estructuras
{
	class NodoUsuario
	{
		public Usuario Dato { get; set; }
		public NodoUsuario Anterior { get; set; }
		public NodoUsuario Siguiente { get; set; }

		public NodoUsuario(Usuario dato, NodoUsuario anterior, NodoUsuario siguiente)
		{
			Dato = dato;
			Anterior = anterior;
			Siguiente = siguiente;
		}
	}

	public class ListaUsuarios
	{
		private NodoUsuario Inicio;
		private NodoUsuario Fin;

		public ListaUsuarios()
		{
			Inicio = Fin = null;
		}

		public bool EsVacia()
		{
			return Inicio == null && Fin == null;
		}

		public void Agregar(Usuario usuario)
		{
			NodoUsuario nuevo = new NodoUsuario(usuario, Fin, null);
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

		public Usuario Valida(String codigo, String pass)
		{
			NodoUsuario aux = Inicio;
			while (aux != null)
			{
				if (aux.Dato.CodigoUsuario.Equals(codigo))
				{
					if (aux.Dato.Password.Equals(pass))
					{
						return aux.Dato;
					}
					return null;
				}
				aux = aux.Siguiente;
			}
			return null;
		}

		public int Contar()
		{
			NodoUsuario aux = Inicio;
			int cont = 0;
			while (aux != null)
			{
				cont++;
				aux = aux.Siguiente;
			}
			return cont;
		}

		public Usuario ValorIndice(int indice)
		{
			if (indice > Contar() - 1)
				throw new Exception("No existe el indice " + indice + ".");
			NodoUsuario aux = Inicio;
			for (int i = 0; i <= indice; i++)
			{
				if (i == indice)
					break;
				aux = aux.Siguiente;
			}
			return aux.Dato;
		}

		public Usuario EliminarIndice(int indice)
		{
			if (indice > Contar() - 1)
				throw new Exception("No existe el indice " + indice + ".");
			if (EsVacia())
				return null;

			NodoUsuario aux = Inicio;
			for (int i = 0; i <= indice; i++)
			{
				if (i == indice)
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
			return aux.Dato;
		}
	}
}
