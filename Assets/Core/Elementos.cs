using System;

namespace Assets.Core
{
	/// <summary>
	/// Tipo Masa.
	/// </summary>
	public enum TipoMasa
	{
		/// <summary>
		/// Masa normal.
		/// </summary>
		NORMAL,

		/// <summary>
		/// Masa Integral.
		/// </summary>
		INTEGRAL,

		/// <summary>
		/// Masa sin gluten.
		/// </summary>
		SIN_GLUTEN
	}

	/// <summary>
	/// Sabor de Masa
	/// </summary>
	public enum SaborMasa
	{
		/// <summary>
		/// Sabor de Naranja
		/// </summary>
		NARANJA,
		
		/// <summary>
		/// Sabor de Vainilla
		/// </summary>
		VAINILLA,

		/// <summary>
		/// Sabor de Chocolate
		/// </summary>
		CHOCOLATE,

		/// <summary>
		/// Sabor de Fresa
		/// </summary>
		FRESA,

		/// <summary>
		/// Sabor Triple (Chocolate, Fresa, Vainilla)
		/// </summary>
		TRIPLE
	}

	/// <summary>
	/// Sabor del Glaceado
	/// </summary>
	public enum SaborGlaceado
	{
		/// <summary>
		/// Sabor Naranja
		/// </summary>
		NARANJA, 

		/// <summary>
		/// Sabor Vainilla
		/// </summary>
		VAINILLA, 

		/// <summary>
		/// Sabor chocolate
		/// </summary>
		CHOCOLATE,
		
		/// <summary>
		/// Sabor Fresa
		/// </summary>
		FRESA, 

		/// <summary>
		/// Sin Glaceado
		/// </summary>
		NINGUNO
	}

	/// <summary>
	/// Tamanio de un pastel
	/// </summary>
	public enum Tamanio
	{
		/// <summary>
		/// Tamaño Pequenio
		/// </summary>
		PEQUENIO,

		/// <summary>
		/// Tamaño Grande
		/// </summary>
		GRANDE,

		/// <summary>
		/// Dos pisos.
		/// Primer piso grande y el segundo pequeño.
		/// </summary>
		DOS_PISOS
	}

	/// <summary>
	/// Extras
	/// </summary>
	public enum Extra
	{
		NINGUNO,

		/// <summary>
		/// Miel
		/// </summary>
		MIEL,

		/// <summary>
		/// Chocolate Derretido
		/// </summary>
		CHOCOLATE_DERRETIDO,

		/// <summary>
		/// Duraznos
		/// </summary>
		DURAZNOS,

		/// <summary>
		/// Fresas
		/// </summary>
		FRESAS,

		/// <summary>
		/// Crema
		/// </summary>
		CREMA
	}

	/// <summary>
	/// Forma de pago
	/// </summary>
	public enum FormaPago
	{
		/// <summary>
		/// Pago en efectivo
		/// </summary>
		EFECTIVO,

		/// <summary>
		/// Pago en tarjeta
		/// </summary>
		TARJETA,

		/// <summary>
		/// Pago a través de Paypal
		/// </summary>
		PAYPAL
	}

	/// <summary>
	/// Forma de Entrega
	/// </summary>
	public enum FormaEntrega
	{
		/// <summary>
		/// El cliente recibirá el pastel a domicilio
		/// </summary>
		DOMICILIO,

		/// <summary>
		/// El cliente recogerá el pastel en el local
		/// </summary>
		EN_LOCAL
	}

	/// <summary>
	/// Esta clase permite que los enumeradores tengan metodos.
	/// </summary>
	public static class ElementosExtension
	{
		
		#region Tamanio
		/// <summary>
		/// Precio de Tamaño Pequeño
		/// </summary>
		public const float PrecioTamanioPequenio = 8.0f;

		/// <summary>
		/// Precio de Tamaño Grande
		/// </summary>
		public const float PrecioTamanioGrande = 12.0f;


		/// <summary>
		/// Precio de Dos Pisos
		/// </summary>
		public const float PrecioTamanioDosPisos = PrecioTamanioPequenio + PrecioTamanioGrande - 2.0f;

		/// <summary>
		/// Obtiene el precio de un Tamanio
		/// </summary>
		/// <param name="tamanio">tamanio</param>
		/// <returns> precio </returns>
		public static float GetPrecio(this Tamanio tamanio)
		{
			switch (tamanio)
			{
				case Tamanio.PEQUENIO: return PrecioTamanioPequenio;
				case Tamanio.GRANDE: return PrecioTamanioGrande;
				case Tamanio.DOS_PISOS: return PrecioTamanioDosPisos;
			}
			return 0.0f;
		}

		/// <summary>
		/// Hora minima agregada segun tamanio de dos pisos
		/// </summary>
		public const int HoraTamanioDosPisos = 3;

		/// <summary>
		/// Obtiene la hora minima agregada segun tamanio
		/// </summary>
		/// <param name="tamanio">tamanio</param>
		/// <returns>hora minima</returns>
		public static int GetHora(this Tamanio tamanio)
		{
			switch (tamanio)
			{
				case Tamanio.DOS_PISOS: return HoraTamanioDosPisos;
			}
			return 0;
		}

		#endregion

		#region Extra
		/// <summary>
		/// Precio de cualquier extra excepto NINGUNO
		/// </summary>
		public const float PrecioExtra = 0.6f;

		/// <summary>
		/// Obtiene el precio de un Extra
		/// </summary>
		/// <param name="extra">extra</param>
		/// <returns>precio</returns>
		public static float GetPrecio(this Extra extra)
		{
			switch (extra)
			{
				case Extra.NINGUNO: return 0.0f;
			}
			return PrecioExtra;
		}
		#endregion

		#region TipoMasa

		/// <summary>
		/// Precio masa normal
		/// </summary>
		public const float PrecioMasaNormal = 0.0f;

		/// <summary>
		/// Precio masa integral
		/// </summary>
		public const float PrecioMasaIntegral = 1.5f;

		/// <summary>
		/// Precio masa sin gluten
		/// </summary>
		public const float PrecioMasaSinGluten = 3.0f;


		/// <summary>
		/// Obtiene el precio de un Tipo de Masa
		/// </summary>
		/// <param name="tipoMasa">Tipo de Masa</param>
		/// <returns>precio</returns>
		public static float GetPrecio(this TipoMasa tipoMasa)
		{
			switch (tipoMasa)
			{
				case TipoMasa.NORMAL: return PrecioMasaNormal;
				case TipoMasa.INTEGRAL: return PrecioMasaIntegral;
				case TipoMasa.SIN_GLUTEN: return PrecioMasaSinGluten;
			}
			return 0.0f;
		}

		#endregion

		#region Glaceado
		
		/// <summary>
		/// Precio de cualquier sabor de glacedo exepto NINGUNO
		/// </summary>
		public const float PrecioSaborGlaceado = 0.45f;

		/// <summary>
		/// Obtiene el precio de un Extra
		/// </summary>
		/// <param name="extra">extra</param>
		/// <returns>precio</returns>
		public static float GetPrecio(this SaborGlaceado saborGlaceado)
		{
			switch (saborGlaceado)
			{
				case SaborGlaceado.NINGUNO: return 0.0f;
			}
			return PrecioSaborGlaceado;
		}

		#endregion

		#region Imagen
		/// <summary>
		/// Precio de imagen
		/// </summary>
		public const float PrecioImagen = 1.5f;

		/// <summary>
		/// Obtiene el precio de la Imagen
		/// </summary>
		/// <param name="imagen">imagen</param>
		/// <returns>precio</returns>
		public static float GetPrecio(this byte[] imagen)
		{
			return imagen != null ? PrecioImagen : 0.0f;
		}

		#endregion

		#region FormaEntrega

		/// <summary>
		/// Precio de entrega a domicilio
		/// </summary>
		public const float PrecioDomicilio = 5.0f;

		public const int HoraDomicilio = 1;

		/// <summary>
		/// Obtiene el precio de la forma de entrega
		/// </summary>
		/// <param name="formaEntrega">forma de entrega</param>
		/// <returns>Precio</returns>
		public static float GetPrecio(this FormaEntrega formaEntrega)
		{
			return formaEntrega == FormaEntrega.DOMICILIO ? PrecioDomicilio : 0.0f;
		}

		/// <summary>
		/// Obtener la hora de la forma de entrega
		/// </summary>
		/// <param name="formaEntrega">forma de enrega</param>
		/// <returns>Hora Minima</returns>
		public static int GetHora(this FormaEntrega formaEntrega)
		{
			return formaEntrega == FormaEntrega.DOMICILIO ? HoraDomicilio : 0;
		}

		#endregion

		#region Urgente

		public const int HoraUrgente = 8;
		public const int HoraNoUrgente = 6;

		public static int GetHoraUrgente(this bool urgente)
		{
			return urgente ? HoraUrgente : HoraNoUrgente;
		}

		#endregion

		#region Hora

		/// <summary>
		/// Suma las horas a una fecha segun los parametros de postre
		/// </summary>
		/// <param name="fecha"> fecha a sumar</param>
		/// <param name="horas"> horas que se suman a la fecha</param>
		/// <returns> nueva fecha con horas sumadas </returns>
		public static DateTime SumarHorasFechaEntrega(this DateTime fecha, int horas)
		{
			DateTime fechaResultado = fecha.Date;

			int horaInicio = PanPitaDesigner.HoraInicioJornada;
			int maximo = PanPitaDesigner.HorasPorJornada;

			if (fechaResultado.Hour > (horaInicio + maximo))
			{
				int sobra = fecha.Hour - (horaInicio + maximo);
				fechaResultado.AddDays(1);
				fechaResultado = new DateTime(fechaResultado.Year, fechaResultado.Month, fechaResultado.Day, 
					horaInicio + sobra, 0, 0);
			}

			if (fechaResultado.Hour + horas > (horaInicio + maximo))
			{
				int sobra = (fechaResultado.Hour + horas) % (maximo);
				fechaResultado.AddDays((fechaResultado.Hour + horas) / (horaInicio + maximo));
				fechaResultado = new DateTime(fechaResultado.Year, fechaResultado.Month, fechaResultado.Day, 
					horaInicio + sobra, 0, 0);
			}
			else
			{
				fechaResultado.AddHours(horas);
			}

			if (fechaResultado.Day > MaximoMes(fechaResultado.Month))
			{
				int sobra = fechaResultado.Day - MaximoMes(fechaResultado.Month);
				fechaResultado.AddMonths(1);
				fechaResultado = new DateTime(fechaResultado.Year, fechaResultado.Month, sobra, 
					fechaResultado.Hour, 0, 0);
			}

			return fechaResultado;
		}

		/// <summary>
		/// Retorna el maximo de dias en un mes
		/// </summary>
		/// <param name="mes">el mes</param>
		/// <returns>maximo de dias</returns>
		private static int MaximoMes(int mes)
		{
			switch (mes)
			{
				case 1:
				case 3:
				case 5:
				case 7:
				case 8:
				case 10:
				case 12:
					return 31;

				case 4:
				case 6:
				case 9:
				case 11:
					return 30;


				case 2:
					return 28;

				default: return 0;
			}
		}

		#endregion
	}

}
