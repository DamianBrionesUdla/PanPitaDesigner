using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Assets.Core;

public class EscenaEstadoController : MonoBehaviour
{
    public TMP_InputField txtNumeroOrden;
    public TMP_Text txtEstado;

    void Start()
    {
        txtNumeroOrden.text = string.Empty;
    }

    public void btnBuscar_Click()
	{
		for (int i = 0; i < PanPitaDesigner.Pedidos.Contar(); i++)
		{
            Pedido actual = PanPitaDesigner.Pedidos.ValorIndice(i);
            string orden = txtNumeroOrden.text;
            string ordenReal = Pedido.CalcularNumeroOrden(actual);
            if (orden.Equals(ordenReal))
			{
                txtEstado.text = actual.Estado.ToString();
                return;
			}
		}
        for (int i = 0; i < PanPitaDesigner.PedidosUrgentes.Contar(); i++)
        {
            Pedido actual = PanPitaDesigner.PedidosUrgentes.ValorIndice(i);
            string orden = txtNumeroOrden.text;
            string ordenReal = Pedido.CalcularNumeroOrden(actual);
            if (orden.Equals(ordenReal))
            {
                txtEstado.text = actual.Estado.ToString();
                return;
            }
        }
    }
}
