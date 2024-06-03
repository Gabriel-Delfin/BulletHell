using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BulletManager : MonoBehaviour
{
    public TextMeshProUGUI bulletCounterText;
    private List<GameObject> activeBullets = new List<GameObject>();

    void Update()
    {
        // Actualizar el texto del contador
        bulletCounterText.text = "Bullets: " + activeBullets.Count;
    }

    public void RegisterBullet(GameObject bullet)
    {
        activeBullets.Add(bullet);
    }

    public void UnregisterBullet(GameObject bullet)
    {
        activeBullets.Remove(bullet);
    }
}
