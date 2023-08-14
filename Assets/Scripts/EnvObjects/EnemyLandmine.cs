using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLandmine : MonoBehaviour
{

    [Header("Landmine Enemy Stats")]
    public int damage;
    public float damageRadius;
    public float fuseTime;
    public float explosionTime;

    [Header("References")] 
    public Material normalMaterial;
    public Material flashMaterial;
    public Material explodedMaterial;
    public MeshRenderer meshRenderer;
    public SphereCollider sphereCollider;

    private float fuseTimer = 0;
    private float explosionTimer = 0;
    private bool exploded = false;

    private void FixedUpdate()
    {
        if (exploded)
        {
            // Check if explosion timer is done and delete object if so.
            if (explosionTimer >= explosionTime)
            {
                Destroy(gameObject);
                // TO DO: Destroy damage radius.
            }
            else
            {
                explosionTimer += Time.deltaTime;
            }
        }
        // Check if fuse timer is done and explode if so.
        else if (fuseTimer >= fuseTime)
        {
            explode();
        }
        else
        {
            checkFlash();
            fuseTimer += Time.deltaTime;
        }
    }

    private void checkFlash()
    {
        if ((fuseTimer - Mathf.FloorToInt(fuseTimer)) < 0.1)
            meshRenderer.material = flashMaterial;
        else 
            meshRenderer.material = normalMaterial;
    }

    private void explode()
    {
        exploded = true;
        meshRenderer.material = explodedMaterial;
        transform.localScale = new Vector3(damageRadius, damageRadius, damageRadius);
        //sphereCollider.radius = damageRadius;

        // TO DO: Create damage radius.
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            explode();
        }
    }
}
