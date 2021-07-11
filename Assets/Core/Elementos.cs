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
	public static class ExtensionElemento
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
	}

}
