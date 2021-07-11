namespace Assets.Core
{
    /// <summary>
    /// Clase de un postre del sistema
    /// </summary>
	public class Postre
	{
        /// <summary>
        /// Tamaño del postre
        /// </summary>
        public Tamanio Tamanio { get; set; }

        /// <summary>
        /// Sabor de masa del postre
        /// </summary>
        public SaborMasa SaborMasa { get; set; }

        /// <summary>
        /// Sabor de glaceado del postre
        /// </summary>
        public SaborGlaceado SaborGlaceado { get; set; }

        /// <summary>
        /// Extra 1 del postre
        /// </summary>
        public Extra Extra1 { get; set; }

        /// <summary>
        /// Extra 2 del postre
        /// </summary>
        public Extra Extra2 { get; set; }

        /// <summary>
        /// Extra 3 del postre
        /// </summary>
        public Extra Extra3 { get; set; }

        /// <summary>
        /// Tipo de masa del postre
        /// </summary>
        public TipoMasa TipoMasa { get; set; }

        /// <summary>
        /// Imagen del postre
        /// </summary>
        public byte[] Imagen { get; set; } = null;

        /// <summary>
        /// texto personalizado del postre
        /// </summary>
        public string Texto { get; set; }

        /// <summary>
        /// Camtidad de este postre
        /// </summary>
        public int Cantidad { get; set; }

        /// <summary>
        /// Precio final del postre
        /// </summary>
        public float Precio => calcularPrecio();

        /// <summary>
        /// Calcula el precio final del postre
        /// </summary>
        /// <returns>precio final del postre</returns>
        private float calcularPrecio()
		{
            float precio = 0.0f;

            //Aumenta segun tamanio
            precio += Tamanio.GetPrecio();

            //Aumenta segun extras
            precio += Extra1.GetPrecio();
            precio += Extra2.GetPrecio();
            precio += Extra3.GetPrecio();

            //Aumenta segun tipo de masa
            precio += TipoMasa.GetPrecio();

            //Aumenta segun el sabor del glaceado
            precio += SaborGlaceado.GetPrecio();

            //Aumenta segun la imagen
            precio += Imagen.GetPrecio();

            //Multiplica segun cantidad
            precio *= Cantidad;

            //los que no se mencionan es porque no aumentan precio

            return precio;
        }

        /// <summary>
        /// Metodo heredado sobreescrito para transformar el objeto a texto
        /// </summary>
        /// <returns>objeto como texto</returns>
		public override string ToString()
		{
			return $"[Tamanio: '{Tamanio}'; SaborMasa: '{SaborMasa}'; SaborGlaceado: '{SaborGlaceado}';" +
                   $" Extras: '{Extra1}, {Extra2}, {Extra3}'; TipoMasa: {TipoMasa}]";
		}
	}
}
