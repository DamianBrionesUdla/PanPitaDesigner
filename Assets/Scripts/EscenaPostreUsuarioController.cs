using System.Collections;
using System;
using System.Linq;
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

    [Space]
    public TMP_Dropdown cmbEstado;

    public TMP_InputField txtRazonCancelar;

    [Space]
    public TMP_Text txtNombre;
    public TMP_Text txtCedula;
    public TMP_Text txtDireccion;
    public TMP_Text txtTelefono;

    void Start()
    {
       txtTamanio.text =
       txtMasa.text =
       txtSaborMasa.text =
       txtGlaceado.text =
       txtExtras.text =
       txtTexto.text =
       txtNumeroOrden.text = string.Empty;

        cmbEstado.AddOptions(Enum.GetNames(typeof(Estado)).ToList());

       Cargar(0);
    }

    public void Cargar(int indice)
	{
        Postre act = PanPitaDesigner.PedidoActual.ListaPostres.ValorIndice(indice);
        cmbEstado.value = (int)PanPitaDesigner.PedidoActual.Estado;
        txtTamanio.text = act.Tamanio.ToString();
        txtMasa.text = act.TipoMasa.ToString();
        txtSaborMasa.text = act.SaborMasa.ToString();
        txtGlaceado.text = act.SaborGlaceado.ToString();
        txtExtras.text = act.Extra1 + ", " + act.Extra2 + ", " + act.Extra3;
        txtTexto.text = act.Texto;
        txtNumeroOrden.text = Pedido.CalcularNumeroOrden(PanPitaDesigner.PedidoActual);

        txtNombre.text = PanPitaDesigner.PedidoActual.Cliente.Nombre;
        txtCedula.text = PanPitaDesigner.PedidoActual.Cliente.Identificacion;
        txtDireccion.text = PanPitaDesigner.PedidoActual.Cliente.Direccion;
        txtTelefono.text = PanPitaDesigner.PedidoActual.Cliente.Telefono;
    }

    public void btnCancelar_Click()
	{
        if (txtRazonCancelar.text != string.Empty)
		{
            if(PanPitaDesigner.Urgentes)
                PanPitaDesigner.PedidosUrgentes.EliminarObjeto(PanPitaDesigner.PedidoActual);
            else
                PanPitaDesigner.Pedidos.EliminarObjeto(PanPitaDesigner.PedidoActual);
            PanPitaDesigner.PedidoActual = null;
            PanPitaDesigner.RetrocederEscena();
		}
	}

    public void cmbEstado_ValueChanged(int value)
	{
        Estado estadoNuevo = (Estado)Enum.Parse(typeof(Estado), cmbEstado.captionText.text);
        PanPitaDesigner.PedidoActual.Estado = estadoNuevo;
    }
}
