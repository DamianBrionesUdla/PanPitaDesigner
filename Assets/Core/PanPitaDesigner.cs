using Assets.Core.Estructuras;
using UnityEngine;

namespace Assets.Core
{
	static class PanPitaDesigner
	{
		public const int HoraInicioJornada = 7;
		public const int HorasPorJornada = 9;

		public static ListaUsuarios Usuarios { get; set; }
		public static ListaPedidos Pedidos { get; set; }
		public static ListaPostres PostresActuales { get; set; }
		public static Usuario UsuarioGuardado { get; set; }

		[RuntimeInitializeOnLoadMethod]
		public static void Inicializar()
		{
			Usuarios = new ListaUsuarios();
			Usuarios.Agregar(new Usuario
			{
				Administrador = true,
				CodigoUsuario = "ADMIN",
				Password = "1234"
			});

			Pedidos = new ListaPedidos();

			PostresActuales = new ListaPostres();

			//TODO: esto es temporal
			PostresActuales.Agregar(new Postre
			{
				Cantidad = 1,
				Extra1 = Extra.NINGUNO,
				Extra2 = Extra.NINGUNO,
				Extra3 = Extra.NINGUNO,
				Imagen = null,
				SaborGlaceado = SaborGlaceado.NINGUNO,
				SaborMasa = SaborMasa.FRESA,
				Tamanio = Tamanio.DOS_PISOS,
				Texto = "Hola",
				TipoMasa = TipoMasa.INTEGRAL
			});

			UsuarioGuardado = null;
		}



	}
}
