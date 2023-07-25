using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Components
    [HideInInspector] public Shooter shooter;
    [HideInInspector] public PlayerHealth health;
    [HideInInspector] public PlayerMovement playerMovement;

    private void Awake()
    {
        shooter = GetComponent<Shooter>();
        health = GetComponent<PlayerHealth>();
        playerMovement = GetComponent<PlayerMovement>();
    }
}
