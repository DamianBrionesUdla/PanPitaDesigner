using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Assets.Core;

public class PedidoController : MonoBehaviour
{
    public TextMeshProUGUI txtNombreCliente;
    public TextMeshProUGUI txtFechaEntrega;
    public TextMeshProUGUI txtPrecio;

    void Start()
    {
        int index = Convert.ToInt32(transform.GetChild(2).GetComponent<Text>().text);
        Pedido pedido = PanPitaDesigner.PedidosFiltrados.ValorIndice(index);
        txtNombreCliente.text = pedido.Cliente.Nombre;
        txtFechaEntrega.text = pedido.FechaEntrega.ToString();
        txtPrecio.text = pedido.Precio.ToString();
    }

    public void btnVer_Click()
	{
        int index = Convert.ToInt32(transform.GetChild(2).GetComponent<Text>().text);
        PanPitaDesigner.PedidoActual = PanPitaDesigner.PedidosFiltrados.ValorIndice(index);
        PanPitaDesigner.MostrarEscena("EscenaPostreUsuario");
    }

}
