using UnityEngine;
using Assets.Core;
using Assets.Core.Ext;
using Assets.Core.Estructuras;
using UnityEngine.UI;
public class ListViewPostreController : MonoBehaviour
{

    public Transform Content;

    public GameObject pfPostre;


    public void Recargar()
	{

        Content.DeleteAllChildren();

        GameObject actualObject;
        for (int i = 0; i < PanPitaDesigner.PostresActuales.Contar(); i++)
        {
            actualObject = Instantiate(pfPostre, Content.transform);
            actualObject.transform.GetChild(3).GetComponent<Text>().text = i.ToString();
        }
    }

}
