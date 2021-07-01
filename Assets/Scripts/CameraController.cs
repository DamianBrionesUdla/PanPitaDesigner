using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private const int IZQUIERDA = 0;
    private const int DERECHA = 1;
    private Transform camaraTransform;

    public float camaraVel = 1;
    public Transform objetivoTransform;
    public float distanciaObjetivo = 10;

	void Start()
	{
        camaraTransform = GetComponent<Camera>().transform;
	}

	void Update()
    {
        if (Input.GetMouseButton(IZQUIERDA))
            mover(IZQUIERDA);
        if (Input.GetMouseButton(DERECHA))
            mover(DERECHA);
    }

    private void mover(int dir)
	{
        Vector3 vel = dir == DERECHA ? Vector3.right : Vector3.left;

        float rotacionSobreEjeY = vel.x * 180 * Time.deltaTime * camaraVel;

        camaraTransform.position = objetivoTransform.position;
        camaraTransform.Rotate(new Vector3(0, 1, 0), rotacionSobreEjeY, Space.World);

        camaraTransform.Translate(new Vector3(0, -1f, -distanciaObjetivo));

    }
}
