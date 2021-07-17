namespace Assets.Core.Estructuras
{
	class NodoEscena
	{
		public string Nombre { get; set; }
		public NodoEscena Siguiente { get; set; }

		public NodoEscena(string nombre, NodoEscena siguiente)
		{
			Nombre = nombre;
			Siguiente = siguiente;
		}
	}
	public class PilaEscenas
	{
        private NodoEscena Cima;

        public PilaEscenas()
        {
            Cima = null;
        }

        public void PushUnique(string nuevo)
        {
            if (Existe(nuevo))
            {
                MoverACima(nuevo);
            }
            else
            {
                Agregar(nuevo);
            }
        }

        public string Top()
        {
            return Cima.Nombre;
        }

        public string Pop()
        {
            if (EsVacia())
                return null;

            NodoEscena aux = Cima;
            Cima = Cima.Siguiente;
            aux.Siguiente = null;
            return aux.Nombre;
        }

        public bool EsVacia()
        {
            return Cima == null;
        }

        public bool Existe(string dato)
        {
            return Buscar(dato) != -1;
        }

        public int Buscar(string nombre)
        {
            NodoEscena aux = Cima;
            int cont = 0;
            while (aux != null)
            {
                if (aux.Nombre.Equals(nombre))
                {
                    return cont;
                }
                cont++;
                aux = aux.Siguiente;
            }
            return -1;
        }

        public int Contar()
        {
            if (EsVacia())
                return 0;

            NodoEscena aux = Cima;
            int cont = 0;
            while (aux != null)
            {
                cont++;
                aux = aux.Siguiente;
            }
            return cont;
        }

        private void MoverACima(string nombre)
        {
            int indice = Buscar(nombre);
            if (indice == 0)
            {
                return;
            }

            NodoEscena aux = Cima;
            for (int i = 0; i < indice - 1; i++)
            {
                aux = aux.Siguiente;
            }
            NodoEscena tmp = aux.Siguiente;
            aux.Siguiente = tmp.Siguiente;
            tmp.Siguiente = Cima;
            Cima = tmp;
        }

        private void Agregar(string nuevo)
        {
            NodoEscena nodoNuevo = new NodoEscena(nuevo, Cima);
            Cima = nodoNuevo;
        }



    }
}
