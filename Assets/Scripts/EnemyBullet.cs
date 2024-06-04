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

    // Nos permite establecer la dirección de la bala
    public void SetDirection(Vector2 newDirection)
    {
        direction = newDirection.normalized;
    }

    void Move()
    {
        transform.position += (Vector3)direction * speed * Time.deltaTime;
    }

    // Nos permite destruir GameObjects (jugador y bala)
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealth>().DestroyShip();
            Destroy(gameObject);
        }
    }

    // Destruimos la bala cuando salga de escena
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
