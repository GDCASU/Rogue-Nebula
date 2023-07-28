using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float moveSpeed;
    private Vector2 moveDirection;

    private bool canMove = true;
    // Components
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        canMove = true;
    }

    private void FixedUpdate()
    {
        if (canMove)
            HandleMovement();   // Handle player velocity
    }

    public void StartMovement()
    {
        canMove = true;
    }

    public void HaltMovement()
    {
        rb.velocity = Vector2.zero;
    }

    public void HaltMovementInput()
    {
        canMove = false;
    }

    public void HaltMovementandInput()
    {
        canMove = false;
        rb.velocity = Vector2.zero;
    }
    private void HandleMovement()
    {
        moveDirection.x = PlayerInput.instance.movementInput.x;      // Get movement inputs for PlayerInput script
        moveDirection.y = PlayerInput.instance.movementInput.y;      // Get movement inputs for PlayerInput script
        Vector3 velocity = moveDirection * moveSpeed;

        rb.velocity = velocity;
    }
}
