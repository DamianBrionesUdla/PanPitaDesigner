using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Assets.Core;

public class LigInController : MonoBehaviour
{
    public TMP_InputField txtUsuario;
    public TMP_InputField txtPassword;
    public Toggle chkGuardar;
    public GameObject pnlError;
    void Start()
    {
        pnlError.transform.position = new Vector3(-1000, pnlError.transform.position.y, pnlError.transform.position.z);
        if (PanPitaDesigner.UsuarioGuardado != null)
		{
            txtUsuario.text = PanPitaDesigner.UsuarioGuardado.CodigoUsuario;
            txtPassword.text = PanPitaDesigner.UsuarioGuardado.Password;
            chkGuardar.isOn = true;
        }
    }

    public void btnIniciarSesion_Click()
	{
        PanPitaDesigner.UsuarioActual = null;
        Usuario act = PanPitaDesigner.Usuarios.Valida(txtUsuario.text, txtPassword.text);
        if (act != null)
        {
            PanPitaDesigner.UsuarioActual = act;
            PanPitaDesigner.UsuarioGuardado = act;
            PanPitaDesigner.MostrarEscena("EscenaUsuario");
        }
		else
		{
            pnlError.transform.position = new Vector3(100, pnlError.transform.position.y, pnlError.transform.position.z);
        }

    }
}
