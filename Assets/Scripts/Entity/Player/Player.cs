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

    public void FlipPlayerOrientation()
    {
        Debug.Log("Player Flipped");
        gameObject.transform.Rotate(Vector3.forward, 180f);
    }
}
