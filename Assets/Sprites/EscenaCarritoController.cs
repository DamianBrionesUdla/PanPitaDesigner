using Assets.Core;
using Assets.Core.Estructuras;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Events;

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

        Recargar();
    }

    private void Recargar()
    {
        postres = PanPitaDesigner.PostresActuales;
        if (postres.Contar() == 0)
        {
            btnContinuar.enabled = false;
            return;
        }

        CargarPedido();

        RecargaEvento.Invoke();
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

        txtFechaMinima.text = pedidoActual.FechaEntrega.ToString();
    }

    private System.DateTime CalcularFechaEntrega()
	{
        return PanPitaDesigner.Pedidos.FechaUltimo.SumarHorasFechaEntrega(
            Pedido.CalcularHorasMinimaEntrega(
                postres, chkUrgente.isOn, chkDomicilio.isOn ? FormaEntrega.DOMICILIO : FormaEntrega.EN_LOCAL
            )
        );
	}
}
