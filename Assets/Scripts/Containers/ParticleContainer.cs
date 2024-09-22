using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleContainer : MonoBehaviour
{
    public static ParticleContainer instance { get; private set; }

    private void Awake()
    {
        if (instance == null)   // Handle Singleton
            instance = this;
        else
            Destroy(gameObject);
    }
}
