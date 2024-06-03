using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 5f;
    private Vector2 direction;
    private BulletManager bulletManager;

    void Start()
    {
        if (direction == Vector2.zero)
        {
            direction = Vector2.down;
        }

        // Contador de balas
        bulletManager = FindObjectOfType<BulletManager>();
        bulletManager.RegisterBullet(gameObject);
    }

    void Update()
    {
        Move();
    }

    public void SetDirection(Vector2 newDirection)
    {
        direction = newDirection.normalized;
    }

    // Método para actualizar la dirección de la bala para seguir a la nave enemiga
    public void UpdateDirection(Vector3 targetPosition)
    {
        // Calcular la dirección hacia el objetivo (en este caso, la posición de la nave enemiga)
        Vector3 directionToTarget = (targetPosition - transform.position).normalized;

        // Actualizar la dirección de la bala
        direction = directionToTarget;
    }

    void Move()
    {
        transform.position += (Vector3)direction * speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealth>().DestroyShip();
            Destroy(gameObject);
        }
    }

    void OnBecameInvisible()
    {
        DestroyBullet();
    }

    void OnDestroy()
    {
        DestroyBullet();
    }

    void DestroyBullet()
    {
        if (bulletManager != null)
        {
            bulletManager.UnregisterBullet(gameObject);
        }
        Destroy(gameObject);
    }
}
