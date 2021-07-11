using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BarraSuperiorController : MonoBehaviour
{
    
    public void btnRegresar_Click()
	{
		SceneManager.LoadScene("Diseñador");
	}

	public void btnCarrito_Click()
	{
		SceneManager.LoadScene("EscenaCarrito");
	}

	public void btnEstado_Click()
	{
		SceneManager.LoadScene("EscenaEstado");
	}

	public void btnLogIn_Click()
	{
		SceneManager.LoadScene("EscenaLogIn");
	}

}
