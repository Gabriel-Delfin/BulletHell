using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float sideToSideSpeed = 2f;
    public float sideToSideDistance = 5f;

    private bool isMovingRight = true;
    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        if (isMovingRight)
        {
            transform.Translate(Vector3.right * sideToSideSpeed * Time.deltaTime);
            if (transform.position.x >= initialPosition.x + sideToSideDistance)
            {
                isMovingRight = false;
            }
        }
        else
        {
            transform.Translate(Vector3.left * sideToSideSpeed * Time.deltaTime);
            if (transform.position.x <= initialPosition.x - sideToSideDistance)
            {
                isMovingRight = true;
            }
        }
    }

    // Método para habilitar el movimiento lateral
    public void EnableSideToSideMovement()
    {
        enabled = true;
    }

    // Método para deshabilitar el movimiento lateral
    public void DisableSideToSideMovement()
    {
        enabled = false;
    }
}
