using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Core;

public class EscenaUsuariosController : MonoBehaviour
{
	public Transform btnAdministrarUsuarios;
	private void Start()
	{
		if (!PanPitaDesigner.UsuarioActual.Administrador)
		{
			btnAdministrarUsuarios.Translate(-1000, 0, 0);
		}
	}

	public void btnPedidos_Click()
	{
		MostrarPedidos(false);
	}

	public void btnUrgentes_Click()
	{
		MostrarPedidos(true);
	}
	public void btnUsuarios_Click()
	{
		PanPitaDesigner.MostrarEscena("EscenaAdministrarUsuarios");
	}

	private void MostrarPedidos(bool urgentes)
	{
		PanPitaDesigner.Urgentes = urgentes;
		PanPitaDesigner.MostrarEscena("EscenaPedidos");
	}

}
