using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Ability : MonoBehaviour
{
    [Header("Unity Events")]
    [SerializeField] public UnityEvent<float> onAbilityCooldown;

    [Header("Ability Cooldown")]
    [SerializeField] private float abilityCooldown = 0f;
    private bool abilityOnCooldown = false;

    // Components
    protected Player playerComponent;
    protected Rigidbody rbComponent;
    protected EntityHealth healthComponent;

    private void Awake()
    {
        playerComponent = GetComponent<Player>();
        healthComponent = GetComponent<EntityHealth>();
        rbComponent = GetComponent<Rigidbody>();
    }

    public virtual bool Execute()       // overriden function to execute ability; return true if on cooldown, return false otherwise
    {
        if (abilityCooldown > 0 && abilityOnCooldown)
            return true;
        onAbilityCooldown?.Invoke(abilityCooldown);
        StartCoroutine(CooldownCo());
        return false;
    }

    private IEnumerator CooldownCo()
    {
        abilityOnCooldown = true;
        yield return new WaitForSeconds(abilityCooldown);
        abilityOnCooldown = false;
    }
}
