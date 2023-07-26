using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IEnemy : MonoBehaviour
{
    protected Transform playerTransform;

    [SerializeField] protected Renderer enemyRenderer;

    [SerializeField] protected GameObject ammoPrefab;
    [SerializeField] protected Transform ammoSpawnPoint;

    [SerializeField] protected EnemyHealth health;
    [SerializeField] protected float speed = 1f;

    // STATE CONTROL
    protected bool moveDown = false;

    protected virtual void Start()
    {
        playerTransform = GameObject.Find("Player").transform;

        if (enemyRenderer == null) enemyRenderer = GetComponent<Renderer>();
        moveDown = !enemyRenderer.isVisible;
    }

    protected void FixedUpdate()
    {
        if (moveDown) EnterPlayfield();
    }

    // Places enemies into playfield
    protected virtual void EnterPlayfield()
    {
        transform.Translate(Vector3.down * Time.deltaTime * speed);                 // Move Down.
        moveDown = Camera.main.WorldToViewportPoint(transform.position).y > .9f;    // Check if should move down again.
    }

    protected abstract void Move();

    protected virtual void Fire()
    {
        if(ammoPrefab == null)
        {
            Debug.LogError("No ammo prefab set.");
            return;
        }

        Instantiate(ammoPrefab, ammoSpawnPoint.position, ammoSpawnPoint.rotation);
    }
}