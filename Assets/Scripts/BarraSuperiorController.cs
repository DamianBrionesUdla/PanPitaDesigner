using UnityEngine;
using Assets.Core;

public class BarraSuperiorController : MonoBehaviour
{
    
    public void btnRegresar_Click()
	{
		PanPitaDesigner.RetrocederEscena();
	}

	public void btnCarrito_Click()
	{
		PanPitaDesigner.MostrarEscena("EscenaCarrito");
	}

	public void btnEstado_Click()
	{
		PanPitaDesigner.MostrarEscena("EscenaEstado");
	}

	public void btnLogIn_Click()
	{
		PanPitaDesigner.MostrarEscena("EscenaLogIn");
	}

}
