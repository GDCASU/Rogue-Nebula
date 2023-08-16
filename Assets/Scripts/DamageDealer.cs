using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] public int damage = 1;
    [SerializeField] bool destroyAfterHitFactor = false;      // Should really only be used for projectiles (NOT ENEMIES)
    [SerializeField] int hitFactor = 0; // Determins how many Entities this damage dealer can hit withoug 

    [Header("Effects")]
    public GameObject hitPS;

    public void Hit()    // Destroy gameObject after hit
    {
        if (destroyAfterHitFactor && hitFactor <= 0)
        {
            if (hitPS != null)      // Handle PS
            {
                GameObject instance = Instantiate(hitPS, transform.position, Quaternion.identity);
                Destroy(instance, 1f);
            }
            Destroy(gameObject);
        }
        hitFactor--;
    }
}
