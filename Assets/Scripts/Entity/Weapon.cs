using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] protected GameObject ProjectilePrefab;
    [SerializeField] protected float projectileSpeed;
    [SerializeField] protected float baseFireRate;

    protected bool isFiring;
    // Components
    protected Shooter shooter;

    private void Start()
    {
        shooter = GetComponentInParent<Shooter>();
    }

    public virtual void Fire()
    {

    }
}
