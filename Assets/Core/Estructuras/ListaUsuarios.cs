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
					throw new Exception("Contraseña Incorrecta");
				}
				aux = aux.Siguiente;
			}
			throw new Exception("Usuario no encontrado");
		}
	}
}
