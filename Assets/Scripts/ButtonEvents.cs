using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEvents : MonoBehaviour
{
	public Material materialActual;
	public Texture texturaNueva;

	public void cambiarMasa()
	{
		materialActual.SetTexture(materialActual.GetTexturePropertyNames()[0], texturaNueva);
	}
}
