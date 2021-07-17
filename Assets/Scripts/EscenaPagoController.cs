using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Assets.Core;
using UnityEngine.Events;

public class EscenaPagoController : MonoBehaviour
{
    public TMP_Dropdown cmbFormaPago;
    public GameObject pnlPaypal;
    public GameObject pnlTarjeta;

    public TMP_InputField txtNombre;
    public TMP_InputField txtIdentificacion;
    public TMP_InputField txtDireccion;
    public TMP_InputField txtTelefono;

    void Start()
    {
        cmbFormaPago.AddOptions(Enum.GetNames(typeof(FormaPago)).ToList());
        cmbFormaPago.onValueChanged.AddListener(new UnityAction<int>(cmbFormaPago_OnValueChanged));
        cmbFormaPago_OnValueChanged(0);
    }

    void cmbFormaPago_OnValueChanged(int value)
	{
        pnlPaypal.transform.position = new Vector3(600, pnlPaypal.transform.position.y, pnlPaypal.transform.position.z);
        pnlTarjeta.transform.position = new Vector3(600, pnlTarjeta.transform.position.y, pnlTarjeta.transform.position.z);
        FormaPago fp = (FormaPago)Enum.Parse(typeof(FormaPago), cmbFormaPago.captionText.text);
		switch (fp)
		{
            case FormaPago.EFECTIVO:
                pnlPaypal.transform.position = new Vector3(1500, pnlPaypal.transform.position.y, pnlPaypal.transform.position.z);
                pnlTarjeta.transform.position = new Vector3(1500, pnlTarjeta.transform.position.y, pnlTarjeta.transform.position.z);
                break;

            case FormaPago.PAYPAL:
                pnlTarjeta.transform.position = new Vector3(1500, pnlTarjeta.transform.position.y, pnlTarjeta.transform.position.z);
                break;

            case FormaPago.TARJETA:
                pnlPaypal.transform.position = new Vector3(1500, pnlPaypal.transform.position.y, pnlPaypal.transform.position.z);
                break;
		}
	}

    public void btnPagar_OnClick()
	{
        if (Validar())
		{
            PanPitaDesigner.PedidoActual.Cliente = new Cliente
            {
                Direccion = txtDireccion.text,
                Identificacion = txtIdentificacion.text,
                Nombre = txtNombre.text,
                Telefono = txtTelefono.text
            };
            PanPitaDesigner.PedidoActual.FormaDePago = (FormaPago)Enum.Parse(typeof(FormaPago), cmbFormaPago.captionText.text);
            if (PanPitaDesigner.PedidoActual.EsUrgente)
                PanPitaDesigner.PedidosUrgentes.Agregar(PanPitaDesigner.PedidoActual);
            else
                PanPitaDesigner.Pedidos.Agregar(PanPitaDesigner.PedidoActual);
            PanPitaDesigner.RegresarInicio();
        }

	}

    private bool Validar()
	{
        string direccion = txtDireccion.text ?? string.Empty;
        string nombre = txtDireccion.text ?? string.Empty;
        string telefono = txtDireccion.text ?? string.Empty;
        string identificacion = txtDireccion.text ?? string.Empty;

        if (nombre.Equals(string.Empty) || identificacion.Equals(string.Empty) || telefono.Equals(string.Empty) || direccion.Equals(string.Empty))
		{
            return false;
		}
        return true;

    }

}
