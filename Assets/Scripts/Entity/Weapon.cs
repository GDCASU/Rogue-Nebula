using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] protected GameObject ProjectilePrefab;
    [SerializeField] protected float projectileSpeed;
    [SerializeField] protected float baseFireRate;

    public virtual void Fire()
    {

    }


}
