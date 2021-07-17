using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

using Assets.Core;

public class PostreLayoutController : MonoBehaviour
{

	private void Start()
	{
		int index = Convert.ToInt32(transform.GetChild(3).GetComponent<Text>().text);
		Postre postre = PanPitaDesigner.PostresActuales.ValorIndice(index);
		transform.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>().text = postre.Cantidad.ToString();
		transform.GetChild(1).GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>().text = postre.Texto?.ToString() ?? string.Empty;
		transform.GetChild(1).GetChild(1).GetChild(1).GetComponent<TextMeshProUGUI>().text = postre.SaborMasa.ToString();
		transform.GetChild(1).GetChild(2).GetChild(1).GetComponent<TextMeshProUGUI>().text = postre.SaborGlaceado.ToString();

	}

	public void btnMas_Click()
	{
		int index = Convert.ToInt32(transform.GetChild(3).GetComponent<Text>().text);
		PanPitaDesigner.PostresActuales.AgregarCantidad(index, 1);
		transform.parent.parent.parent.parent.GetComponent<EscenaCarritoController>().Recargar();
	}

	public void btnMenos_Click()
	{
		int index = Convert.ToInt32(transform.GetChild(3).GetComponent<Text>().text);
		if (PanPitaDesigner.PostresActuales.ValorIndice(index).Cantidad > 0)
			PanPitaDesigner.PostresActuales.AgregarCantidad(index, -1);
		transform.parent.parent.parent.parent.GetComponent<EscenaCarritoController>().Recargar();
	}

	public void btnBorrar_Click()
	{
		int index = Convert.ToInt32(transform.GetChild(3).GetComponent<Text>().text);
		PanPitaDesigner.PostresActuales.EliminarIndice(index);
		transform.parent.parent.parent.parent.GetComponent<EscenaCarritoController>().Recargar();
	}
}
