using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileContainer : MonoBehaviour
{
    public static ProjectileContainer instance { get; private set; }

    private void Awake()
    {
        if (instance == null)   // Handle Singleton
            instance = this;
        else
            Destroy(gameObject);
    }
}
