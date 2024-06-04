using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float fireRate = 0.5f;
    private float nextFireTime = 0f;
    private int currentPattern = 0;
    private float patternChangeInterval = 10f;
    private float nextPatternChangeTime = 0f;
    private float spiralAngle = 0f;

    // Referencia al componente de movimiento de la nave enemiga
    private EnemyMovement enemyMovement;

    void Start()
    {
        nextPatternChangeTime = Time.time + patternChangeInterval;

        // Obtener la referencia al componente de movimiento de la nave enemiga
        enemyMovement = GetComponent<EnemyMovement>();
    }

    void Update()
    {
        if (Time.time > nextFireTime)
        {
            Shoot();
        }

        if (Time.time > nextPatternChangeTime)
        {
            ChangePattern();
        }
    }

    // Cambia el disparo de la bala acorde al patrón
    void Shoot()
    {
        nextFireTime = Time.time + fireRate;

        switch (currentPattern)
        {
            case 0:
                Pattern1();
                break;
            case 1:
                Pattern2();
                break;
            case 2:
                Pattern3();
                break;
        }
    }

    void ChangePattern()
    {
        currentPattern = (currentPattern + 1) % 3;
        nextPatternChangeTime = Time.time + patternChangeInterval;
    }

    void Pattern1()
    {
        // Disparar en patrón en forma de ovni
        int bulletCount = 7; 
        float spreadAngle = 45f; 

        float angleStep = spreadAngle / (bulletCount - 1);
        float startAngle = -spreadAngle / 2;

        for (int i = 0; i < bulletCount; i++)
        {
            float angle = startAngle + (i * angleStep);
            Vector2 direction = new Vector2(Mathf.Sin(angle * Mathf.Deg2Rad), -Mathf.Cos(angle * Mathf.Deg2Rad));
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bullet.GetComponent<EnemyBullet>().SetDirection(direction);
        }
    }

    void Pattern2()
    {
        // Disparar en un patrón de espiral
        float angleStep = 15f;
        float bulletDirX = transform.position.x + Mathf.Sin((spiralAngle * Mathf.PI) / 180f);
        float bulletDirY = transform.position.y + Mathf.Cos((spiralAngle * Mathf.PI) / 180f);

        Vector3 bulletMoveVector = new Vector3(bulletDirX, bulletDirY, 0f);
        Vector2 bulletDir = (bulletMoveVector - transform.position).normalized;

        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet.GetComponent<EnemyBullet>().SetDirection(bulletDir);

        spiralAngle += angleStep;
        if (spiralAngle >= 360f)
        {
            spiralAngle -= 360f;
        }
    }   

    void Pattern3()
    {
        // Disparar en forma de círculo
        int bulletCount = 10;
        float circleRadius = 1f;
        float angleStep = 360f / bulletCount;

        for (int i = 0; i < bulletCount; i++)
        {
            float angle = i * angleStep;
            float bulletDirX = transform.position.x + circleRadius * Mathf.Sin(angle * Mathf.Deg2Rad);
            float bulletDirY = transform.position.y + circleRadius * Mathf.Cos(angle * Mathf.Deg2Rad);
            Vector2 bulletSpawnPosition = new Vector2(bulletDirX, bulletDirY);
            
            Vector2 direction = (bulletSpawnPosition - (Vector2)transform.position).normalized;

            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPosition, Quaternion.identity);
            bullet.GetComponent<EnemyBullet>().SetDirection(direction);
        }
    }
}