using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Assets.Core;
using System;
using System.Linq;

public class DiseñadorController : MonoBehaviour
{
    public TMP_Dropdown cmbTamanio;
    public TMP_Dropdown cmbMasa;
    public TMP_Dropdown cmbSaborMasa;
    public TMP_Dropdown cmbGlaceado;
    public TMP_InputField txtTexto;

    public TMP_Dropdown cmbExtra1;
    public TMP_Dropdown cmbExtra2;
    public TMP_Dropdown cmbExtra3;

    [Space]
    public GameObject Pastel;

    void Start()
    {
        cmbTamanio.AddOptions(Enum.GetNames(typeof(Tamanio)).ToList());
        cmbMasa.AddOptions(Enum.GetNames(typeof(TipoMasa)).ToList());
        cmbSaborMasa.AddOptions(Enum.GetNames(typeof(SaborMasa)).ToList());
        cmbGlaceado.AddOptions(Enum.GetNames(typeof(SaborGlaceado)).ToList());
        cmbExtra1.AddOptions(Enum.GetNames(typeof(Extra)).ToList());
        cmbExtra2.AddOptions(Enum.GetNames(typeof(Extra)).ToList());
        cmbExtra3.AddOptions(Enum.GetNames(typeof(Extra)).ToList());

        Pastel.GetComponent<PastelController>().Recargar(0);
    }

    public void btnAniadir_Click()
	{
        Tamanio tamanio = (Tamanio)Enum.Parse(typeof(Tamanio), cmbTamanio.captionText.text);
        TipoMasa masa = (TipoMasa)Enum.Parse(typeof(TipoMasa), cmbMasa.captionText.text);
        SaborMasa saborMasa = (SaborMasa)Enum.Parse(typeof(SaborMasa), cmbSaborMasa.captionText.text);
        SaborGlaceado Glaceado = (SaborGlaceado)Enum.Parse(typeof(SaborGlaceado), cmbGlaceado.captionText.text);
        Extra extra1 = (Extra)Enum.Parse(typeof(Extra), cmbExtra1.captionText.text);
        Extra extra2 = (Extra)Enum.Parse(typeof(Extra), cmbExtra2.captionText.text);
        Extra extra3 = (Extra)Enum.Parse(typeof(Extra), cmbExtra3.captionText.text);
        string texto = txtTexto.text ?? string.Empty;

        Postre p = new Postre
        {
            Tamanio = tamanio,
            Cantidad = 1,
            Extra1 = extra1,
            Extra2 = extra2,
            Extra3 = extra3,
            Imagen = null,
            SaborGlaceado = Glaceado,
            SaborMasa = saborMasa,
            Texto = texto,
            TipoMasa = masa
        };

        PanPitaDesigner.PostresActuales.Agregar(p);
    }
}
