using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IEnemy : MonoBehaviour
{
    protected Transform playerTransform;

    [SerializeField] protected Renderer enemyRenderer;

    [SerializeField] protected GameObject ammoPrefab;
    [SerializeField] protected Transform ammoSpawnPoint;

    public int health = -1;
    public int damage = -1;
    [SerializeField] protected float enterSpeed = 5f;
    [SerializeField] protected float speed = 1f;

    // STATE CONTROL
    [SerializeField] float percentUpScreen = 0.9f;
    protected bool moveDown = false;

    protected virtual void Start()
    {
        playerTransform = GameObject.Find("Player").transform;

        if (enemyRenderer == null) enemyRenderer = GetComponent<Renderer>();
        moveDown = !enemyRenderer.isVisible;

        GetComponent<EnemyHealth>().ToggleInvulnerable(true);

        // HEALTH
        if (health == -1) health = GetComponent<EnemyHealth>().health;    // Not set, making sure things don't go awry.
        else GetComponent<EnemyHealth>().health = (int)health;              // Set, override original health

        // DAMAGE (sub comments from health apply here, but im lazy)
        if (damage == -1) damage = ammoPrefab.GetComponent<DamageDealer>().damage;
        else ammoPrefab.GetComponent<DamageDealer>().damage = (int)damage;
    }

    protected virtual void FixedUpdate()
    {
        if (moveDown) EnterPlayfield();
        else GetComponent<EnemyHealth>().ToggleInvulnerable(false);
    }

    // Places enemies into playfield
    protected virtual void EnterPlayfield()
    {
        transform.Translate(Vector3.down * Time.deltaTime * enterSpeed);                 // Move Down.
        moveDown = Camera.main.WorldToViewportPoint(transform.position).y > percentUpScreen;    // Check if should move down again.
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

    public void SetHealth(int newHealth)
    {
        health = newHealth;
        GetComponent<EnemyHealth>().health = newHealth;
    }

    public void SetDamage(int newDmg)
    {
        damage = newDmg;
        ammoPrefab.GetComponent<DamageDealer>().damage = newDmg;
    }
    
    public void SetStats(int h, int d)
    {
        SetHealth(h);
        SetDamage(d);
    }
}
