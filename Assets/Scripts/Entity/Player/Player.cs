using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public enum PlayerState
{
    normal,     // Can preform all actions
    idle,       // Cannot move
    busy,       // Cannot do anything at all
    stunned     // Velocity is 0 and cannot do anything
}

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

    public Shooter GetShooter()
    {
        if (shooter != null)
            return shooter;
        return null;
    }

    public PlayerHealth GetHealth()
    {
        if (health != null)
            return health;
        return null;
    }

    public PlayerMovement GetMovement()
    {
        if (playerMovement != null)
            return playerMovement;
        return null;
    }

    public void FlipPlayerOrientation()
    {
        gameObject.transform.Rotate(Vector3.forward, 180f);
    }
}
