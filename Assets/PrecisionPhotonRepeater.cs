using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrecisionPhotonRepeater : Weapon
{
    public override void Fire()
    {
        base.Fire();
        if (!isFiring)
            StartCoroutine(FireCo());

    }

    private IEnumerator FireCo()
    {
        isFiring = true;
        GameObject projInstance = Instantiate(ProjectilePrefab, transform.position, transform.rotation); // Instantiate projectile @ player's pos
        Rigidbody rb = projInstance.GetComponent<Rigidbody>();
        if (rb != null && shooter != null)
            rb.velocity = transform.up * projectileSpeed;
        yield return new WaitForSeconds(baseFireRate);      // NEED TO CHANGE LATER FOR FIRE RATE POWERUPS
        isFiring = false;
    }
}
