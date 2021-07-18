using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Core;
using Assets.Core.Ext;
using Assets.Core.Estructuras;
using TMPro;
using System.Linq;
using System;

public class ListViewPedidoController : MonoBehaviour
{
    public Transform Content;
    public GameObject pfPedido;

    public TMP_InputField txtFiltroNombre;
    public TMP_InputField txtFiltroFecha;
    public TMP_InputField txtFiltroPrecio;
    public TMP_InputField txtFiltroCedula;

    void Start()
    {
        Recargar();
    }

    public void Recargar()
	{
        Content.DeleteAllChildren();

        GameObject actualObject;
        if (PanPitaDesigner.PedidosFiltrados == null)
            PanPitaDesigner.PedidosFiltrados = PanPitaDesigner.Urgentes ? PanPitaDesigner.PedidosUrgentes
                : PanPitaDesigner.Pedidos;
        int cantidad = PanPitaDesigner.PedidosFiltrados.Contar();
        for (int i = 0; i < cantidad; i++)
        {
            actualObject = Instantiate(pfPedido, Content.transform);
            actualObject.transform.GetChild(2).GetComponent<Text>().text = i.ToString();
        }
    }

    public void btnFiltroNombre_Click()
    {
        PanPitaDesigner.PedidosFiltrados = null;
        if (!txtFiltroNombre.text.Equals(string.Empty))
        {
            ListaPedidos filtro = PanPitaDesigner.Urgentes ? PanPitaDesigner.PedidosUrgentes.Donde(p => p.Cliente.Nombre.Equals(txtFiltroNombre.text))
                : PanPitaDesigner.Pedidos.Donde(p => p.Cliente.Nombre.Equals(txtFiltroNombre.text));
            Filtrar(filtro);
        }
        Recargar();
	}
    public void btnFiltroCedula_Click()
    {
        PanPitaDesigner.PedidosFiltrados = null;
        if (!txtFiltroCedula.text.Equals(string.Empty))
        {
            ListaPedidos filtro = PanPitaDesigner.Urgentes ? PanPitaDesigner.PedidosUrgentes.Donde(p => p.Cliente.Identificacion.Equals(txtFiltroCedula.text))
                : PanPitaDesigner.Pedidos.Donde(p => p.Cliente.Identificacion.Equals(txtFiltroCedula.text));
            Filtrar(filtro);
        }
        Recargar();
    }

    public void btnFiltroFecha_Click()
    {
        PanPitaDesigner.PedidosFiltrados = null;
        if (!txtFiltroFecha.text.Equals(string.Empty))
        {
            ListaPedidos filtro = PanPitaDesigner.Urgentes ? PanPitaDesigner.PedidosUrgentes.Donde(p => p.FechaEntrega.ToString().Contains(txtFiltroFecha.text))
                : PanPitaDesigner.Pedidos.Donde(p => p.FechaEntrega.ToString().Contains(txtFiltroFecha.text));
            Filtrar(filtro);
        }
        Recargar();
    }

    public void btnFiltroPrecio_Click()
    {
        PanPitaDesigner.PedidosFiltrados = null;
        if (!txtFiltroPrecio.text.Equals(string.Empty))
		{
            ListaPedidos filtro = PanPitaDesigner.Urgentes ? PanPitaDesigner.PedidosUrgentes.Donde(p => p.Precio <= Convert.ToDouble(txtFiltroPrecio.text) + 1 && p.Precio >= Convert.ToDouble(txtFiltroPrecio.text) - 1)
                : PanPitaDesigner.Pedidos.Donde(p => p.Precio <= Convert.ToDouble(txtFiltroPrecio.text) + 1 && p.Precio >= Convert.ToDouble(txtFiltroPrecio.text) - 1);
            Filtrar(filtro);
        }
        Recargar();
    }

    private void Filtrar(ListaPedidos lista)
	{
        PanPitaDesigner.PedidosFiltrados = lista;
    }

}
