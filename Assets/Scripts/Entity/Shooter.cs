using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    const string PROJECTILE_CONTAINER = "Projectile Container";
    [HideInInspector] public GameObject projectileContainer = null;

    [Header("Shooter Properties")]
    [SerializeField] public bool autoFire = false;             // Entity will auto fire their current gun
    [SerializeField] private Weapon currentWeapon = null;
    [SerializeField] private List<Weapon> weapons;              // Holds all the guns at a Entity's disposal

    [Header("Cooldowns")]
    [SerializeField] private float swapCooldown = 0;
    
    private Vector2 currDirection = Vector2.up;        // Will be used for flipping an entity later
    private bool isPlayer = false;
    private bool isSwapping = false;

    private void Start()
    {
        CreateProjectileParent();

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

    public void CreateProjectileParent()
    {
        projectileContainer = GameObject.Find(PROJECTILE_CONTAINER);
        if (!projectileContainer)
        {
            projectileContainer = new GameObject(PROJECTILE_CONTAINER);
        }
    }

    public void SwapWeapon(int idx)    // Weapon swap
    {
        if (isPlayer)                           // If swap cooldown is required
        {
            if (!isSwapping)                            // If not already swapping weapon
            {
                StartCoroutine(SwapCo());
                currentWeapon = weapons[idx];
            }
        }
        else                                           // If no swap cooldown is required
            currentWeapon = weapons[idx];
    }

    private IEnumerator SwapCo()
    {
        isSwapping = true;
        yield return new WaitForSeconds(swapCooldown);
        isSwapping = false;
    }
}
