using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Core.Estructuras;
using Assets.Core.Ext;
using Assets.Core;

public class ListaPostreUsuarioController : MonoBehaviour
{
    public Transform Content;
    public GameObject pfPostre;

    void Start()
    {
        Content.DeleteAllChildren();

		for (int i = 0; i < PanPitaDesigner.PedidoActual.ListaPostres.Contar(); i++)
		{
            GameObject act = Instantiate(pfPostre, Content.transform);
            act.transform.GetChild(3).GetComponent<Text>().text = i.ToString();
        }
    }



}
