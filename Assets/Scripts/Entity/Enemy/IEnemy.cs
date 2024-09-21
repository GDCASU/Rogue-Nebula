using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IEnemy : MonoBehaviour
{
    protected Transform playerTransform;

    [Header("References")]
    [SerializeField] protected GameObject ammoPrefab;
    [SerializeField] protected Transform ammoSpawnPoint;

    [Header("Base Stats")]
    public int health = -1;
    public int damage = -1;
    public float fireDelay = 0;
    public int score = 1;

    [SerializeField] protected float enterSpeed = 5f;
    [SerializeField] protected float speed = 1f;

    // STATE CONTROL
    [SerializeField] float percentUpScreen = 0.9f;
    protected bool moveDown = true;

    protected virtual void Start()
    {
        playerTransform = GameObject.Find("Player").transform;

        GetComponent<EnemyHealth>().ToggleInvulnerable(true);

        // HEALTH
        if (health == -1) health = GetComponent<EnemyHealth>().health;    // Not set, making sure things don't go awry.
        else GetComponent<EnemyHealth>().health = health;              // Set, override original health

        // SCORE
        if (score == -1) score = GetComponent<EnemyHealth>().score;    // Not set, making sure things don't go awry.
        else GetComponent<EnemyHealth>().score = score;              // Set, override original health

        // DAMAGE (sub comments from health apply here, but im lazy)
        if (damage == -1) damage = ammoPrefab.GetComponent<DamageDealer>().damage;
        else ammoPrefab.GetComponent<DamageDealer>().damage = damage;
    }

    protected virtual void Fire()
    {
        if(ammoPrefab == null)
        {
            Debug.LogError("No ammo prefab set.");
            return;
        }else if(ammoSpawnPoint == null)
        {
            Debug.LogError("No ammo spawn point set.");
            return;
        }

        Instantiate(ammoPrefab, ammoSpawnPoint.position, ammoSpawnPoint.rotation, ProjectileContainer.instance?.transform);
    }

    #region Universal Movement

    protected virtual void FixedUpdate()
    {
        if (moveDown) EnterPlayfield();
    }

    // Places enemies into playfield
    protected virtual void EnterPlayfield()
    {
        transform.Translate(Vector3.down * Time.deltaTime * enterSpeed);                        // Move Down.
        moveDown = Camera.main.WorldToViewportPoint(transform.position).y > percentUpScreen;    // Check if should move down again.

        if(!moveDown) GetComponent<EnemyHealth>().ToggleInvulnerable(false);                    // toggle invulnerable off
    }

    #endregion

    #region Stats

    public void SetHealth(int newHealth)
    {
        health = newHealth;
        GetComponent<EnemyHealth>().health = newHealth;
    }

    public void SetScore(int newScore)
    {
        score = newScore;
        GetComponent<EnemyHealth>().score = newScore;
    }

    public void SetDamage(int newDmg)
    {
        damage = newDmg;
        ammoPrefab.GetComponent<DamageDealer>().damage = newDmg;
    }
    
    public void SetStats(int h, int s, int d)
    {
        SetHealth(h);
        SetScore(s);
        SetDamage(d);
    }

    #endregion

    #region Inherit Required

    protected abstract void Move();

    #endregion

    #region Variance Handling

    [Header("Varient Stats")]
    [SerializeField] int curType = 0;   // 0, 1, 2 :: easy, med, hard

    // From easy to medium difficulty
    [SerializeField] int medHealthInc = 1;
    [SerializeField] float medSpeedInc = 1;
    [SerializeField] float medFrInc = 1;
    [SerializeField] int medScoreInc = 1;

    // From medium to hard difficulty
    [SerializeField] int hardHealthInc = 1;
    [SerializeField] float hardSpeedInc = 1;
    [SerializeField] float hardFrInc = 1;
    [SerializeField] int hardScoreInc = 1;

    [Header("Varient Materials")]
    [SerializeField] Material easyMat;
    [SerializeField] Material medMat;
    [SerializeField] Material hardMat;
    [SerializeField] MeshRenderer shipRenderer;
    [SerializeField] int shipVarMatInd = -1;

    public void SetEasy()
    {
        // If stuff needed, make medium then move along
        switch (curType)
        {
            case 0: return; // Already ez, get outta here
            case 1: break;  // Already Medium, move along
            case 2:         // Now we cookin w/ gas, make it med
                SetMedium();
                break;

            default:        // what kinda place is this???
                Debug.LogError("curType set to something dumb. Why u do this?");
                return;
        }

        // From med to ez stat changes
        SetHealth(health - medHealthInc);
        SetScore(score - medScoreInc);
        speed -= medSpeedInc;
        fireDelay += medFrInc;
        

        // ez renderer changes
        List<Material> newMats = new List<Material>();
        foreach (Material mat in shipRenderer.materials) newMats.Add(mat);
        newMats[shipVarMatInd] = easyMat;
        shipRenderer.SetMaterials(newMats);

        curType = 0;
    }

    public void SetMedium()
    {
        switch (curType)
        {
            case 1: return; // Already med
            case 0:
                SetHealth(health + medHealthInc);
                SetScore(score + medScoreInc);
                speed += medSpeedInc;
                fireDelay -= medFrInc;
                break;

            case 2:
                SetHealth(health - hardHealthInc);
                SetScore(score - hardScoreInc);
                speed -= hardSpeedInc;
                fireDelay += hardFrInc;
                break;

            default:
                Debug.LogError("curType set to something dumb. Why u do this?");
                return;
        }

        // med renderer changes
        List<Material> newMats = new List<Material>();
        foreach (Material mat in shipRenderer.materials) newMats.Add(mat);
        newMats[shipVarMatInd] = medMat;
        shipRenderer.SetMaterials(newMats);

        curType = 1;
    }

    public void SetHard()
    {
        // ensure medium and move along
        switch (curType)
        {
            case 2: return; // Nothing needed
            case 1: break;  // Already med, move along
            case 0:         // Make med, move along
                SetMedium();
                break;
            default:
                Debug.LogError("curType set to something dumb. Why u do this?");
                return;
        }

        SetHealth(health + hardHealthInc);
        SetScore(score + hardScoreInc);
        speed += hardSpeedInc;
        fireDelay -= hardFrInc;

        // hard renderer changes
        List<Material> newMats = new List<Material>();
        foreach (Material mat in shipRenderer.materials) newMats.Add(mat);
        newMats[shipVarMatInd] = hardMat;
        shipRenderer.SetMaterials(newMats);

        curType = 2;
    }

    #endregion
}
