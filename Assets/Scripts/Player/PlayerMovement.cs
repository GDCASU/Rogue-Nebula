using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    private Vector2 moveDirection;
    public Vector2 currentVelocity;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        moveDirection.x = PlayerInput.instance.movementInput.x;      // Get movement inputs for PlayerInput script
        moveDirection.y = PlayerInput.instance.movementInput.y;
        Vector3 tagetVelocity = moveDirection * moveSpeed;

        rb.velocity = tagetVelocity;
    }
}
