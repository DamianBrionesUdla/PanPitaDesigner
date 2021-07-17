using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Assets.Core;

public class EscenaAdministrarUsuariosController : MonoBehaviour
{
    public Transform pnlDatos;

    public TMP_InputField txtUsuario;
    public TMP_InputField txtPassword;
    public Toggle chkEsAdmin;

    public int Posicion = 600;

    private int _indice = -1;
    void Start()
    {
        pnlDatos.position = new Vector3(15000, pnlDatos.position.y, pnlDatos.position.z);
    }


    public void Cargar(int indice)
	{
        pnlDatos.position = new Vector3(Posicion, pnlDatos.position.y, pnlDatos.position.z);
        _indice = indice;
        if (indice == -1)
		{
            txtUsuario.text = string.Empty;
            txtPassword.text = string.Empty;
            chkEsAdmin.isOn = false;
        }
		else
		{
            Usuario usuario = PanPitaDesigner.Usuarios.ValorIndice(indice);
            txtUsuario.text = usuario.CodigoUsuario;
            txtPassword.text = usuario.Password;
            chkEsAdmin.isOn = usuario.Administrador;
        }
	}

    public void btnNuevoClick()
	{
        Cargar(-1);
	}

    public void btnListo_Click()
	{
        if (Validar())
        {
            return;
        }

        if (_indice == -1)
		{
            PanPitaDesigner.Usuarios.Agregar(new Usuario
            {
                Administrador = chkEsAdmin.isOn,
                CodigoUsuario = txtUsuario.text,
                Password = txtPassword.text
            });
        }
		else
		{
            Usuario u = PanPitaDesigner.Usuarios.ValorIndice(_indice);
            u.Administrador = chkEsAdmin.isOn;
            u.CodigoUsuario = txtUsuario.text;
            u.Password = txtPassword.text;
        }
        PanPitaDesigner.RetrocederEscena();
        PanPitaDesigner.MostrarEscena("EscenaAdministrarUsuarios");
    }

    public bool Validar()
	{
        return txtUsuario.text == string.Empty || txtPassword.text == string.Empty;

    }
}
