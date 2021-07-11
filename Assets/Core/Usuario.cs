namespace Assets.Core
{
	/// <summary>
	/// Clase que representa al usuario del sistema
	/// </summary>
	public class Usuario
	{
		/// <summary>
		/// Codigo del usuario
		/// </summary>
		public string CodigoUsuario {get; set; }

		/// <summary>
		/// Contraseña del usuario
		/// </summary>
		public string Password { get; set; }

		/// <summary>
		/// Si el usuario es Administrador entonces true sino false
		/// </summary>
		public bool Administrador { get; set; }

	}
}
