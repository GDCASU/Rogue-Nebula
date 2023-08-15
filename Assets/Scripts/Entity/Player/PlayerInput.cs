using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using System;

public class PlayerInput : MonoBehaviour
{
    public static PlayerInput instance;

    [Header("Player Movement Input")]
    [SerializeField] public Vector2 movementInput;

    [Header("Player Shooting Input")]
    [SerializeField] public bool shootInput;

    // Events
    [SerializeField] public static event Action onPause;

    private PlayerControls playerControls;
    private Player player;

    private void Awake()    // Handle Singleton
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    public void ToggleControls(bool toggle)     // Toggle the player controls with this method
    {
        if (toggle)
        {
            playerControls.Enable();
            player = FindObjectOfType<Player>();
        }
        else
            playerControls.Disable();
    }

    private void Start()
    {
        if (playerControls == null)
        {
            playerControls = new PlayerControls();

            // Subscribe to input events
            playerControls.ShipControls.Move.performed += i => HandleMovementInput(i);
            playerControls.ShipControls.Shoot.performed += i => HandleShootingInput(i);
            playerControls.ShipControls.Shoot.canceled += i => HandleShootingInput(i);
            playerControls.ShipControls.Swap_Weapon_1.performed += i => HandleWeaponSwapInput(i, 0);
            playerControls.ShipControls.Swap_Weapon_2.performed += i => HandleWeaponSwapInput(i, 1);
            playerControls.ShipControls.FireMode.performed += i => HandleFireModeInput(i);
            playerControls.ShipControls.FlipPlayer.performed += i => HandleOrientationFlipInput();
            playerControls.ShipControls.Evade.performed += i => HandleEvadeInput();
            playerControls.ShipControls.BubbleShield.performed += i => HandleBubbleShieldInput();
            playerControls.ShipControls.Pause.performed += i => HandlePauseInput();
        }

        playerControls.Enable();

    }
    private void HandleMovementInput(InputAction.CallbackContext context)   
    {
        movementInput = context.ReadValue<Vector2>();
        movementInput.Normalize();
    }

    private void HandleShootingInput(InputAction.CallbackContext context) 
    {
        if (context.performed)
            shootInput = true;
        else
            shootInput = false;
    }

    private void HandleWeaponSwapInput(InputAction.CallbackContext context, int weaponIndex)
    {
        player.shooter.SwapWeapon(weaponIndex);
    }

    private void HandleFireModeInput(InputAction.CallbackContext context)
    {
        if (player.shooter.autoFire)
            player.shooter.autoFire = false;
        else
            player.shooter.autoFire = true;
    }

    private void HandleOrientationFlipInput()
    {
        player.FlipPlayerOrientation();
    }

    private void HandleEvadeInput()
    {
        player.evade.Execute();
    }

    private void HandleBubbleShieldInput()
    {
        player.shieldBubble.Execute();
    }

    private void HandlePauseInput()
    {
        onPause?.Invoke();      // STOP GAME | OPEN PAUSE MENU
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
