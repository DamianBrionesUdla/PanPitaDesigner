using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Assets.Core;

public class NumeroOrdenController : MonoBehaviour
{
    public TMP_InputField txtNumeroOrden;
    void Start()
    {
        txtNumeroOrden.text = Pedido.CalcularNumeroOrden(PanPitaDesigner.PedidoActual);
    }

    public void Ok_Clic()
	{
        PanPitaDesigner.RegresarInicio();
	}
}
