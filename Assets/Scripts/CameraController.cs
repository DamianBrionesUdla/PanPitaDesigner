using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform camaraTransform;
    private bool moveLeft, moveRight;

    public float camaraVel = 1;
    public Transform objetivoTransform;
    public float distanciaObjetivo = 10;

	void Start()
	{
        camaraTransform = GetComponent<Camera>().transform;
        moveLeft = moveRight = false;
	}

	void Update()
    {
        if (moveLeft)
            mover(Vector3.left);
        if (moveRight)
            mover(Vector3.right);
    }

    private void mover(Vector3 hDir)
	{

        float rotacionSobreEjeY = -hDir.x * 180 * Time.deltaTime * camaraVel;

        camaraTransform.position = objetivoTransform.position;
        camaraTransform.Rotate(new Vector3(0, 1, 0), rotacionSobreEjeY, Space.World);

        camaraTransform.Translate(new Vector3(0, 0f, -distanciaObjetivo));

    }

    public void MoveLeft()
	{
        moveLeft = true;
	}

    public void StopMoveLeft()
	{
        moveLeft = false;
    }

    public void MoveRight()
    {
        moveRight = true;
    }

    public void StopMoveRight()
    {
        moveRight = false;
    }
}
