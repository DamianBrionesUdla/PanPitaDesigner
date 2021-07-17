using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Assets.Core;
using Assets.Core.Ext;
using Assets.Core.Estructuras;

public class ListViewUsuariosController : MonoBehaviour
{

    public Transform Content;

    public GameObject pfUsuario;

    void Start()
    {
        Recargar();
    }

    public void Recargar()
    {

        Content.DeleteAllChildren();

        GameObject actualObject;
        for (int i = 0; i < PanPitaDesigner.Usuarios.Contar(); i++)
        {
            actualObject = Instantiate(pfUsuario, Content.transform);
            actualObject.transform.GetChild(2).GetComponent<Text>().text = i.ToString();
        }
    }

}
