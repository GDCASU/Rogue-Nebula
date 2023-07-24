using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    public int damage;
    public void Hit()    // Destroy gameObject after hit
    {
        Destroy(gameObject);
    }
}
