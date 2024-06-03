using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 1f;
    
    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(moveX, moveY, 0);
        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        // Limitar la posición del jugador dentro de los límites de la cámara
        float halfPlayerWidth = transform.localScale.x / 2f;
        float halfPlayerHeight = transform.localScale.y / 2f;
        float cameraDistance = transform.position.z - Camera.main.transform.position.z;

        float minX = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, cameraDistance)).x + halfPlayerWidth;
        float maxX = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, cameraDistance)).x - halfPlayerWidth;
        float minY = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, cameraDistance)).y + halfPlayerHeight;
        float maxY = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, cameraDistance)).y - halfPlayerHeight;

        float clampedX = Mathf.Clamp(transform.position.x, minX, maxX);
        float clampedY = Mathf.Clamp(transform.position.y, minY, maxY);

        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }
}
