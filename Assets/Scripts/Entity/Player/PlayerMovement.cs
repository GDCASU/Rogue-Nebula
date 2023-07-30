using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    private const string MOVEMENT_ANIM_BOOL = "isMoving",
                         MOVEMENT_ANIM_FLOAT = "moveX";

    [SerializeField] public float moveSpeed;
    private Vector2 moveDirection;

    private bool canMove = true;
    // Components
    private Player player;
    private Rigidbody rb;
    private Animator anim;

    private void Awake()
    {
        player = GetComponent<Player>();
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
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
        Vector2 movementInput = PlayerInput.instance.movementInput;

        moveDirection.x = movementInput.x;      // Get movement inputs for PlayerInput script
        moveDirection.y = movementInput.y;      // Get movement inputs for PlayerInput script
        Vector3 velocity = moveDirection * moveSpeed;

        rb.velocity = velocity;

        if (movementInput != Vector2.zero)
            HandleAnimation(true, movementInput);
        else
            HandleAnimation(false, movementInput);
    }

    private void HandleAnimation(bool toggle, Vector2 movementInput)
    {
        if (anim == null)
            return;
        
        if (!player.playerFlipped)
            anim.SetFloat(MOVEMENT_ANIM_FLOAT, movementInput.x);    // If player is not flipped
        else 
            anim.SetFloat(MOVEMENT_ANIM_FLOAT, -movementInput.x);   // Otherwise

            anim.SetBool(MOVEMENT_ANIM_BOOL, toggle);
        
    }
}
