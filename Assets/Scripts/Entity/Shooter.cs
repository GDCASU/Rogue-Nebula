using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private bool autoFire = false;             // Entity will auto fire their current gun
    [SerializeField] private Weapon currentWeapon = null;
    [SerializeField] private List<Weapon> weapons;              // Holds all the guns at a Entity's disposal
    [SerializeField] private Vector2 currDirection = Vector2.up;        // Will be used for flipping an entity later

    private bool isPlayer;

    private void Start()
    {
        currentWeapon = weapons[0];     // Set current weapon to default

        if (gameObject.tag == "Player")       // Check if entity is Player (can use hold-to-fire
            isPlayer = true;
    }

    private void Update()   // Fire weapon continuously 
    {
        if (currentWeapon != null)
        {
            if (autoFire)               // autoFire case
                currentWeapon.Fire();
            else if (isPlayer && PlayerInput.instance.shootInput == true) // hold-to-fire case
                currentWeapon.Fire();
        }
    }

    private void SwapWeapon(int idx)    // Weapon swap
    {
        // ADD COROUTINE FOR WEAPON SWAP DELAY LATER
        currentWeapon = weapons[idx];
    }
}
