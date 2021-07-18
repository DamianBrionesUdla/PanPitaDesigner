using System;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;

using Assets.Core;
public class PostreUsuarioController : MonoBehaviour
{
    public TextMeshProUGUI txtTexto;
    public TextMeshProUGUI txtSaborMasa;
    public TextMeshProUGUI txtGlaceado;
    public TextMeshProUGUI txtCantidad;


    void Start()
    {
        int index = Convert.ToInt32(transform.GetChild(3).GetComponent<Text>().text);
        Postre postre = PanPitaDesigner.PedidoActual.ListaPostres.ValorIndice(index);
        txtTexto.text = postre.Texto;
        txtSaborMasa.text = postre.SaborMasa.ToString();
        txtGlaceado.text = postre.SaborGlaceado.ToString();
        txtCantidad.text = postre.Cantidad.ToString();

        EventTrigger ev = GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerClick;
        entry.callback.AddListener((data) => Click((PointerEventData)data));
        ev.triggers.Add(entry);
    }

    public void Click(PointerEventData data)
	{
        int index = Convert.ToInt32(transform.GetChild(3).GetComponent<Text>().text);
        transform.parent.parent.parent.parent.parent.GetComponent<EscenaPostreUsuarioController>().Cargar(index);
    }
}
