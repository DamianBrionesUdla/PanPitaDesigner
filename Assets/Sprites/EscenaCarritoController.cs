using Assets.Core;
using Assets.Core.Estructuras;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Events;
using System;

public class EscenaCarritoController : MonoBehaviour
{
    public Button btnContinuar;
    public Toggle chkUrgente;
    public Toggle chkDomicilio;
    public InputField txtFechaMinima;
    public InputField txtHoraMinima;
    public InputField txtTotalPedido;
    public Text txtTotalPostres;

    public UnityEvent RecargaEvento;

    private ListaPostres postres;
    void Start()
    {

        chkUrgente.isOn = false;
        chkDomicilio.isOn = false;

    }

    public void chkUrgente_ValueChanged(bool on)
	{
        Recargar();
	}

    public void chkDomicilo_ValueChanged(bool on)
    {
        Recargar();
    }

    public void Recargar()
    {
        RecargaEvento.Invoke();

        postres = PanPitaDesigner.PostresActuales;
        if (postres.Contar() == 0)
        {
            btnContinuar.enabled = false;
            return;
        }


        CargarPedido();

    }

    private void CargarPedido()
	{
        Pedido pedidoActual = new Pedido
        {
            ListaPostres = postres,
            FechaEntrega = CalcularFechaEntrega(),
            EsUrgente = chkUrgente.isOn,
            FormaDeEntrega = chkDomicilio.isOn ? FormaEntrega.DOMICILIO : FormaEntrega.EN_LOCAL
        };

        txtFechaMinima.text = pedidoActual.FechaEntrega.ToString("d");
        txtHoraMinima.text = pedidoActual.FechaEntrega.ToString("t");
        txtTotalPostres.text = postres.PrecioTotal.ToString("0.00");
        txtTotalPedido.text = pedidoActual.Precio.ToString("0.00");

        PanPitaDesigner.PedidoActual = pedidoActual;
    }

    private DateTime CalcularFechaEntrega()
	{
        int horas = Pedido.CalcularHorasMinimaEntrega(postres, chkUrgente.isOn,
            chkDomicilio.isOn ? FormaEntrega.DOMICILIO : FormaEntrega.EN_LOCAL);
        DateTime fecha = chkUrgente.isOn ? PanPitaDesigner.PedidosUrgentes.FechaUltimo.SumarHorasFechaEntrega(horas) : PanPitaDesigner.Pedidos.FechaUltimo.SumarHorasFechaEntrega(horas);
        return fecha;
	}

    public void btnContinuar_Click()
	{
        PanPitaDesigner.MostrarEscena("EscenaPago");
	}
}
