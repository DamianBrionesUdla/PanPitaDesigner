using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Assets.Core;

public class UsuarioController : MonoBehaviour
{
    public TextMeshProUGUI txtCodigo;
    public TextMeshProUGUI txtAdmin;

    private int indice;
    void Start()
    {
        indice = Convert.ToInt32(transform.GetChild(2).GetComponent<Text>().text);
        Usuario u = PanPitaDesigner.Usuarios.ValorIndice(indice);
        txtCodigo.text = u.CodigoUsuario;
        txtAdmin.text = u.Administrador ? "Si" : "No";
    }

    public void btnEditar_Click()
	{
        transform.parent.parent.parent.parent.GetComponent<EscenaAdministrarUsuariosController>().Cargar(indice);
	}

    public void btnBorrar_Click()
	{
        PanPitaDesigner.Usuarios.EliminarIndice(indice);
        PanPitaDesigner.RetrocederEscena();
        PanPitaDesigner.MostrarEscena("EscenaAdministrarUsuarios");
    }
}
