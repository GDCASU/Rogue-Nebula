using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public static PlayerInput instance;

    [Header("Player Movement Input")]
    [SerializeField] public Vector2 movementInput;

    [Header("Player Shooting Input")]
    [SerializeField] public bool shootInput;

    private PlayerControls playerControls;
    private Player player;

    private void Awake()    // Handle Singleton
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        player = FindObjectOfType<Player>();
    }

    private void Start()
    {
        DontDestroyOnLoad(gameObject);

        instance.enabled = true; 
    }

    public void ToggleControls(bool toggle)     // Toggle the player controls with this method
    {
        if (toggle)
            instance.enabled = true;
        else
            instance.enabled = false;
    }

    private void OnEnable()
    {
        if (playerControls == null) 
        {
            playerControls = new PlayerControls();

            // Subscribe to input events
            playerControls.ShipControls.Move.performed += i => HandleMovementInput(i);
            playerControls.ShipControls.Shoot.performed += i => HandleShootingInput(i);
            playerControls.ShipControls.Shoot.canceled += i => HandleShootingInput(i);
            playerControls.ShipControls.Swap_Weapon_1.performed += i => HandleWeaponSwap(i, 0);
            playerControls.ShipControls.Swap_Weapon_2.performed += i => HandleWeaponSwap(i, 1);
        }

        playerControls.Enable();

    }
    private void HandleMovementInput(InputAction.CallbackContext context)   
    {
        movementInput = context.ReadValue<Vector2>();
    }

    private void HandleShootingInput(InputAction.CallbackContext context) 
    {
        if (context.performed)
        {
            shootInput = true;
        }
        else
            shootInput = false;
    }

    private void HandleWeaponSwap(InputAction.CallbackContext context, int weaponIndex)
    {
        player.shooter.SwapWeapon(weaponIndex);
    }

    private void OnApplicationFocus(bool focus)
    {
        if (enabled)
        {
            if (focus)  // enable player controller if application has focus
                playerControls.Enable();
            else        // disable player controller if application loses focus
                playerControls.Disable();
        }
    }
}
