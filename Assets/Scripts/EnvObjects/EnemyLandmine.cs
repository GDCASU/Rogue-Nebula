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
    public Material explodedMaterial;
    public MeshRenderer meshRenderer;

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
        // TO DO: Add checks for 0.1 second intervals every 1 second to flash (by changing material).
        else
        {
            fuseTimer += Time.deltaTime;
        }
    }

    private void explode()
    {
        exploded = true;
        meshRenderer.material = explodedMaterial;
        // TO DO: Create damage radius.
    }
}
