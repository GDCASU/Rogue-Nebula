using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    private Vector2 moveDirection;

    // Components
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        HandleMovement();   // Handle player velocity
    }

    private void HandleMovement()
    {
        moveDirection.x = PlayerInput.instance.movementInput.x;      // Get movement inputs for PlayerInput script
        moveDirection.y = PlayerInput.instance.movementInput.y;      // Get movement inputs for PlayerInput script
        Vector3 velocity = moveDirection * moveSpeed;

        rb.velocity = velocity;
    }
}
