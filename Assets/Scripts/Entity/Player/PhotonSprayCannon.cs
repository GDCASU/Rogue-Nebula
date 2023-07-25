using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotonSprayCannon : Weapon
{
    [Header("Weapon Spec. Properties")]
    [SerializeField] private float spreadAngle = 20;        // Angle of spread between each bullet

    public override void Fire()
    {
        base.Fire();
        if (!isFiring)
            StartCoroutine(FireCo());
    }

    private IEnumerator FireCo()    // Instantiate a projectile and destroy it after a lifetime
    {
        isFiring = true;

        Vector3 l_direction = Quaternion.Euler(0, 0, -spreadAngle/2) * transform.up;
        Vector3 m_direction = transform.up;
        Vector3 r_direction = Quaternion.Euler(0, 0, spreadAngle/2) * transform.up;

        Quaternion l_rotation = new Quaternion(l_direction.x, l_direction.y, l_direction.z, 1);
        Quaternion m_rotation = new Quaternion(m_direction.x, m_direction.y, m_direction.z, 1);
        Quaternion r_rotation = new Quaternion(r_direction.x, r_direction.y, r_direction.z, 1);

        GameObject projInstance_l = Instantiate(ProjectilePrefab, transform.position, l_rotation); // Instantiate projectile -45deg @ player's pos
        GameObject projInstance_m = Instantiate(ProjectilePrefab, transform.position, transform.rotation); // Instantiate projectile 0deg @ player's pos
        GameObject projInstance_r = Instantiate(ProjectilePrefab, transform.position, transform.rotation); // Instantiate projectile 45deg @ player's pos
        projInstance_l.transform.parent = transform;        // Parent to weapon obj
        projInstance_m.transform.parent = transform;        
        projInstance_r.transform.parent = transform;        

        Rigidbody rb_l = projInstance_l.GetComponent<Rigidbody>();
        Rigidbody rb_m = projInstance_m.GetComponent<Rigidbody>();
        Rigidbody rb_r = projInstance_r.GetComponent<Rigidbody>();

        if (rb_l != null && shooter != null)                // Just need to check one projectile cause they all use the same prefab
        {
            rb_l.velocity = l_direction * projectileSpeed;      // Handle Movement direction
            rb_m.velocity = m_direction * projectileSpeed;
            rb_r.velocity = r_direction * projectileSpeed;

            //projInstance_l.transform.rotation = Quaternion.LookRotation(l_direction, Vector3.up);     // Handle object rotational direction
            //projInstance_r.transform.rotation = Quaternion.LookRotation(r_direction, Vector3.up);
        }
        Destroy(projInstance_l, projectileLifetime);
        Destroy(projInstance_m, projectileLifetime);
        Destroy(projInstance_r, projectileLifetime);

        yield return new WaitForSeconds(baseFireRate);      // NEED TO CHANGE LATER FOR FIRE RATE POWERUPS
        isFiring = false;
    }
}
