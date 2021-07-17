using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Core;
using System;
using TMPro;

public class PastelController : MonoBehaviour
{
    public GameObject pastelPiso1;
    public GameObject pastelPiso2;
    public GameObject glaceadoPiso1;
    public GameObject glaceadoPiso2;
    public int scale = 4;

    [Space]
    public Color Vainilla;
    public Color Chocolate;
    public Color Fresa;
    public Color Naranja;

    [Space]
    public GameObject Fresas;
    public GameObject ChocolateDerretido;
    public GameObject Durasnos;
    public GameObject Miel;
    public GameObject Crema;

    [Space]
    public Color GlaceadoVainilla;
    public Color GlaceadoFresa;
    public Color GlaceadoChocolate;
    public Color GlaceadoNaranja;
    public Color GlaceadoNinguno;


    [Space]
    public TMP_Dropdown cmbTamanio;
    public TMP_Dropdown cmbGlaceado;
    public TMP_Dropdown cmbSaborMasa;
    public TMP_Dropdown cmbExtra1;
    public TMP_Dropdown cmbExtra2;
    public TMP_Dropdown cmbExtra3;

    public void Recargar(int unused)
	{

        foreach (Transform child in Fresas.transform)
		{
            child.GetComponent<Renderer>().material.color = Color.red;
		}

        foreach (Transform child in Durasnos.transform)
        {
            child.GetComponent<Renderer>().material.color = Color.yellow;
        }

        ChocolateDerretido.transform.GetChild(0).GetComponent<Renderer>().material.color = GlaceadoChocolate;
        Miel.transform.GetChild(0).GetComponent<Renderer>().material.color = GlaceadoNaranja;

        Tamanio tamanio = (Tamanio)Enum.Parse(typeof(Tamanio), cmbTamanio.captionText.text);
        SaborGlaceado glaceado = (SaborGlaceado)Enum.Parse(typeof(SaborGlaceado), cmbGlaceado.captionText.text);
        SaborMasa saborMasa = (SaborMasa)Enum.Parse(typeof(SaborMasa), cmbSaborMasa.captionText.text);
        Extra extra1 = (Extra)Enum.Parse(typeof(Extra), cmbExtra1.captionText.text);
        Extra extra2 = (Extra)Enum.Parse(typeof(Extra), cmbExtra2.captionText.text);
        Extra extra3 = (Extra)Enum.Parse(typeof(Extra), cmbExtra3.captionText.text);

        CambiarGlaceado(glaceado);
        CambiarTamanio(tamanio, glaceado);
        CambiarSaborMasa(saborMasa);
        CambiarExtra(extra1, extra2, extra3);
    }

	private void CambiarExtra(Extra extra1, Extra extra2, Extra extra3)
	{
        Fresas.SetActive(extra1 == Extra.FRESAS || extra2 == Extra.FRESAS || extra3 == Extra.FRESAS);
        Durasnos.SetActive(extra1 == Extra.DURAZNOS || extra2 == Extra.DURAZNOS || extra3 == Extra.DURAZNOS);
        ChocolateDerretido.SetActive(extra1 == Extra.CHOCOLATE_DERRETIDO || extra2 == Extra.CHOCOLATE_DERRETIDO || extra3 == Extra.CHOCOLATE_DERRETIDO);
        Miel.SetActive(extra1 == Extra.MIEL || extra2 == Extra.MIEL || extra3 == Extra.MIEL);
    }

	private void CambiarSaborMasa(SaborMasa saborMasa)
	{
		switch (saborMasa)
		{
            case SaborMasa.CHOCOLATE:
                pastelPiso1.GetComponent<Renderer>().material.color = Chocolate;
                pastelPiso2.GetComponent<Renderer>().material.color = Chocolate;
                break;

            case SaborMasa.FRESA:
                pastelPiso1.GetComponent<Renderer>().material.color = Fresa;
                pastelPiso2.GetComponent<Renderer>().material.color = Fresa;
                break;

            case SaborMasa.NARANJA:
                pastelPiso1.GetComponent<Renderer>().material.color = Naranja;
                pastelPiso2.GetComponent<Renderer>().material.color = Naranja;
                break;

            case SaborMasa.VAINILLA:
                pastelPiso1.GetComponent<Renderer>().material.color = Vainilla;
                pastelPiso2.GetComponent<Renderer>().material.color = Vainilla;
                break;
        }
	}

	private void CambiarGlaceado(SaborGlaceado glaceado)
	{
        glaceadoPiso2.SetActive(glaceado != SaborGlaceado.NINGUNO);
        glaceadoPiso1.SetActive(glaceado != SaborGlaceado.NINGUNO);
        switch (glaceado)
		{
            case SaborGlaceado.CHOCOLATE:
                glaceadoPiso1.GetComponent<Renderer>().material.color = GlaceadoChocolate;
                glaceadoPiso2.GetComponent<Renderer>().material.color = GlaceadoChocolate;
                break;

            case SaborGlaceado.FRESA:
                glaceadoPiso1.GetComponent<Renderer>().material.color = GlaceadoFresa;
                glaceadoPiso2.GetComponent<Renderer>().material.color = GlaceadoFresa;
                break;

            case SaborGlaceado.VAINILLA:
                glaceadoPiso1.GetComponent<Renderer>().material.color = GlaceadoVainilla;
                glaceadoPiso2.GetComponent<Renderer>().material.color = GlaceadoVainilla;
                break;

            case SaborGlaceado.NARANJA:
                glaceadoPiso1.GetComponent<Renderer>().material.color = GlaceadoNaranja;
                glaceadoPiso2.GetComponent<Renderer>().material.color = GlaceadoNaranja;
                break;
        }
	}


	private void CambiarTamanio(Tamanio tamanio, SaborGlaceado glaceado)
	{
		switch (tamanio)
		{
            case Tamanio.DOS_PISOS:
                pastelPiso2.SetActive(true);
                glaceadoPiso2.SetActive(glaceado != SaborGlaceado.NINGUNO);
                pastelPiso1.transform.localScale = new Vector3(scale, 1, scale);
                glaceadoPiso1.transform.localScale = new Vector3(scale, 0.1f, scale);
                break;

            case Tamanio.GRANDE:
                pastelPiso2.SetActive(false);
                glaceadoPiso2.SetActive(false);
                pastelPiso1.transform.localScale = new Vector3(scale, 1, scale);
                glaceadoPiso1.transform.localScale = new Vector3(scale, 0.1f, scale);
                break;

            case Tamanio.PEQUENIO:
                pastelPiso2.SetActive(false);
                glaceadoPiso2.SetActive(false);
                pastelPiso1.transform.localScale = new Vector3(scale-1, 1, scale-1);
                glaceadoPiso1.transform.localScale = new Vector3(scale-1, 0.1f, scale-1);
                break;
		}
    }
}
