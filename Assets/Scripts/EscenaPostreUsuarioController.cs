using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Assets.Core;

public class EscenaPostreUsuarioController : MonoBehaviour
{

    public TextMeshProUGUI txtTamanio;
    public TextMeshProUGUI txtMasa;
    public TextMeshProUGUI txtSaborMasa;
    public TextMeshProUGUI txtGlaceado;
    public TextMeshProUGUI txtExtras;
    public TextMeshProUGUI txtTexto;
    public TextMeshProUGUI txtNumeroOrden;

    public TMP_InputField txtRazonCancelar;

    void Start()
    {
       txtTamanio.text =
       txtMasa.text =
       txtSaborMasa.text =
       txtGlaceado.text =
       txtExtras.text =
       txtTexto.text =
       txtNumeroOrden.text = string.Empty;
       Cargar(0);
    }

    public void Cargar(int indice)
	{
        Postre act = PanPitaDesigner.PedidoActual.ListaPostres.ValorIndice(indice);
        txtTamanio.text = act.Tamanio.ToString();
        txtMasa.text = act.TipoMasa.ToString();
        txtSaborMasa.text = act.SaborMasa.ToString();
        txtGlaceado.text = act.SaborGlaceado.ToString();
        txtExtras.text = act.Extra1 + ", " + act.Extra2 + ", " + act.Extra3;
        txtTexto.text = act.Texto;
        txtNumeroOrden.text = Pedido.CalcularNumeroOrden(PanPitaDesigner.PedidoActual);
    }

    public void btnCancelar_Click()
	{
        if (txtRazonCancelar.text != string.Empty)
		{
            PanPitaDesigner.Pedidos.EliminarObjeto(PanPitaDesigner.PedidoActual);
            PanPitaDesigner.PedidoActual = null;
            PanPitaDesigner.RetrocederEscena();
		}
	}
}
