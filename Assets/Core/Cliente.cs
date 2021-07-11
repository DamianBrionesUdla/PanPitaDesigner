namespace Assets.Core
{
	/// <summary>
	/// Clase que representa a un cliente del sistema
	/// </summary>
	public class Cliente
	{
		/// <summary>
		/// Nombre del cliente
		/// </summary>
		public string Nombre { get; set; }

		/// <summary>
		/// Identificacion del cliente
		/// </summary>
		public string Identificacion { get; set; }

		/// <summary>
		/// Direccion del cliente
		/// </summary>
		public string Direccion { get; set; }

		/// <summary>
		/// Telefono del cliente
		/// </summary>
		public string Telefono { get; set; }

		#region Temp?
		/*
		/// <summary>
		/// Metodo para comparar clientes por su cedula
		/// </summary>
		/// <param name="otro">otro cliente a comparar</param>
		/// <returns>true si es la misma identificacion, sino false</returns>
		public bool EqualsIdentificacion(Cliente otro)
		{
			return this.Identificacion.Equals(otro.Identificacion);
		}

		/// <summary>
		/// Metodo para comparar clientes por su nombre
		/// </summary>
		/// <param name="otro">otro cliente a comparar</param>
		/// <returns> true si es el mismo nombre, sino false</returns>
		public bool EqualsNombre(Cliente otro)
		{
			return this.Nombre.Equals(otro.Nombre);
		}
		*/
		#endregion

		/// <summary>
		/// Metodo heredado sobreescrito para obtener la clase como texto
		/// </summary>
		/// <returns>texto</returns>
		public override string ToString()
		{
			return $"{Identificacion}[Nombre: '{Nombre}'; Direccion: '{Direccion}'; Teléfono: '{Telefono}']";
		}
	}
}
