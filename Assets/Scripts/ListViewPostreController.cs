using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListViewPostreController : MonoBehaviour
{

    public Transform Content;

    void Start()
    {
        GameObject templateObject = Content.transform.GetChild(0).gameObject; //Objeto plantilla de la lista
        GameObject actualObject;
		for (int i = 0; i < 5; i++)
		{
            actualObject = Instantiate(templateObject, Content.transform);
		}
        Destroy(templateObject);
    }

}
