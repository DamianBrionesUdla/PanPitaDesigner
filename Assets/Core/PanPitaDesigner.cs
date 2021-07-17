using Assets.Core.Estructuras;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Core
{
	static class PanPitaDesigner
	{
		public const int HoraInicioJornada = 7;
		public const int HorasPorJornada = 9;

		
		private static PilaEscenas Escenas { get; set; }
		public static ListaUsuarios Usuarios { get; set; }
		public static ListaPedidos Pedidos { get; set; }
		public static ListaPedidos PedidosUrgentes { get; set; }
		public static ListaPostres PostresActuales { get; set; }

		public static Pedido PedidoActual { get; set; }
		public static Usuario UsuarioActual { get; set; }
		public static bool Urgentes { get; set; }
		public static Usuario UsuarioGuardado { get; set; }
		public static ListaPedidos PedidosFiltrados { get; set; }


		[RuntimeInitializeOnLoadMethod]
		public static void Inicializar()
		{
			Escenas = new PilaEscenas();
			Escenas.PushUnique("Diseñador");

			Usuarios = new ListaUsuarios();
			Usuarios.Agregar(new Usuario
			{
				Administrador = true,
				CodigoUsuario = "ADMIN",
				Password = "ADMIN"
			});
			Usuarios.Agregar(new Usuario
			{
				Administrador = false,
				CodigoUsuario = "Damian",
				Password = "123456"
			});


			Pedidos = new ListaPedidos();
			PedidosUrgentes = new ListaPedidos();

			PostresActuales = new ListaPostres();

			UsuarioGuardado = null;

			PedidosFiltrados = null;
		}

		public static void MostrarEscena(string nombre)
		{
			Escenas.PushUnique(nombre);
			CargarPantalla();
		}

		public static void RetrocederEscena()
		{
			if (Escenas.Contar() > 1)
			{
				Escenas.Pop();
				CargarPantalla();
			}
		}

		public static void RegresarInicio()
		{
			while (Escenas.Contar() > 1)
			{
				Escenas.Pop();
			}
			PostresActuales = new ListaPostres();
			PedidoActual = new Pedido();
			CargarPantalla();
		}

		private static void CargarPantalla()
		{
			PedidosFiltrados = null;
			SceneManager.LoadScene(Escenas.Top());
		}
	}
}
