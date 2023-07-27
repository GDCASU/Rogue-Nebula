using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Components
    [HideInInspector] public Shooter shooter;
    [HideInInspector] public PlayerHealth health;
    [HideInInspector] public PlayerMovement playerMovement;
    [HideInInspector] public Evade evade;
    [HideInInspector] public BubbleShield shieldBubble;

    private void Awake()
    {
        shooter = GetComponent<Shooter>();
        health = GetComponent<PlayerHealth>();
        playerMovement = GetComponent<PlayerMovement>();
        evade = GetComponent<Evade>();
        shieldBubble = GetComponent<BubbleShield>();

    }

    public void FlipPlayerOrientation()
    {
        gameObject.transform.Rotate(Vector3.forward, 180f);
    }
}
