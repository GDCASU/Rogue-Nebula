using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityHealth : MonoBehaviour
{
    [Header("Values")]
    [SerializeField] public int health = 5;
    [SerializeField] private float hitInvulnerabilityTime = 0f;

    [Header("Effects")]
    [SerializeField] public GameObject deathPS;

    [Header("Sounds")]
    [SerializeField] protected AudioClip takeDamageSound;
    [SerializeField] protected AudioClip deathSound;

    [Header("HurtShader")]
    [SerializeField] MeshRenderer meshRenderer;
    [SerializeField] Shader hurtShader;
    [SerializeField] Shader normalShader;

    [Header("Debug")]
    [SerializeField] bool debug;
    [SerializeField] bool makeInvincible;

    private bool invulnerable = false;      // Used anytime the Entity is invunerable to attacks (hits, shield, evade, etc.)

    private void OnTriggerEnter(Collider hitCollider)
    {
        DamageDealer damageDealer = hitCollider.GetComponent<DamageDealer>();

        if (!invulnerable)
        {
            if (damageDealer != null)       // If a damage dealer hit the Entity
            {
                if (damageDealer.tag != gameObject.tag)     // If projectiles are of same faction of Entity
                {
                    TakeDamage(damageDealer.damage);
                    damageDealer.Hit();
                }
            }
        }
    }

    public virtual void TakeDamage(int damage)         // Change health value with damage passed in; wait for invTime
    {
        if (makeInvincible)     // For debugging purposes only
            return;

        MakeInvulnerable(hitInvulnerabilityTime);
        health -= damage;
        
        AudioManager.instance?.PlaySFX(takeDamageSound);
        
        if (health <= 0)
        {
            Death();
        }
    }

    public virtual void Heal(int amount)
    {
        health += amount;
    }

    public virtual void MakeInvulnerable(float invTime)         // Called ANY time the Entity becomes invulnerable
    {
        if (invTime > 0 && !invulnerable) {
            StartCoroutine(InvulnerableCo(invTime));
        }
    }

    public virtual void ToggleInvulnerable(bool toggle)         // Called ANY time the Entity becomes invulnerable
    {
        invulnerable = toggle;
    }

    private IEnumerator InvulnerableCo(float invTime)
    {
        invulnerable = true;
        ToggleShader(true);
        yield return new WaitForSeconds(invTime);
        ToggleShader(false);
        invulnerable = false;
    }

    private void ToggleShader(bool toggle)
    {
        if (meshRenderer == null || hurtShader == null || normalShader == null)
            return;

        if (toggle)
        {
            foreach (Material material in meshRenderer.materials)
            {
                material.shader = hurtShader;
            }
        }
        else
        {
            foreach (Material material in meshRenderer.materials)
            {
                material.shader = normalShader;
            }
        }
    }

    protected virtual void Death()
    {
        if (deathPS != null)        // Handle PS
        {
            GameObject instance = Instantiate(deathPS, gameObject.transform.position, Quaternion.identity, ParticleContainer.instance.transform);
            Destroy(instance, 2f);
        }
        AudioManager.instance?.PlaySFX(deathSound);
        Destroy(gameObject);
    }
}
