using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrecisionPhotonRepeater : Weapon
{
    public override void Fire()     // Fires the weapon based on the fire rate
    {
        base.Fire();
        if (!isFiring)
            StartCoroutine(FireCo());
    }

    private IEnumerator FireCo()    // Instantiate a projectile and destroy it after a lifetime
    {
        isFiring = true;
        GameObject projInstance = Instantiate(ProjectilePrefab, transform.position, transform.rotation); // Instantiate projectile @ player's pos
        projInstance.transform.parent = transform;
        Rigidbody rb = projInstance.GetComponent<Rigidbody>();
        if (rb != null && shooter != null)
            rb.velocity = transform.up * projectileSpeed;
        Destroy(projInstance, projectileLifetime);
        yield return new WaitForSeconds(baseFireRate);      // NEED TO CHANGE LATER FOR FIRE RATE POWERUPS
        isFiring = false;
    }
}
