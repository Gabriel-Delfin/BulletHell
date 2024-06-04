using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BulletManager : MonoBehaviour
{

    // Variables para mostrar en la interfaz de usuario
    public TextMeshProUGUI bulletCounterText;
    private List<GameObject> activeBullets = new List<GameObject>();

    void Update()
    {
        // Actualizar el texto del contador
        bulletCounterText.text = "Bullets: " + activeBullets.Count;
    }

    public void RegisterBullet(GameObject bullet)
    {
        // Registra las balas activas
        activeBullets.Add(bullet);
    }

    public void UnregisterBullet(GameObject bullet)
    {
        // Elimina las balas de la lista
        activeBullets.Remove(bullet);
    }
}
