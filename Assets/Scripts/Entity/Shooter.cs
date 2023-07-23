using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private bool autoFire = false;
    [SerializeField] private Weapon currentWeapon = null;
    [SerializeField] private List<Weapon> weapons;
    [SerializeField] private Vector2 currDirection = Vector2.up;

    private void Start()
    {
        currentWeapon = weapons[0];
    }

    private void Update()
    {
        if (currentWeapon != null) 
        {
            if (autoFire)
                currentWeapon.Fire();
            else if (PlayerInput.instance.shootInput == true) // else use hold to fire
                currentWeapon.Fire();

        }
    }

    private void SwapWeapon(int idx)
    {
        currentWeapon = weapons[idx];
    }
}
