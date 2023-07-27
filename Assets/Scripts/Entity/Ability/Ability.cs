using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour
{
    [SerializeField] private float abilityCooldown = 0f;
    private bool abilityOnCooldown = false;
    // Components
    protected Rigidbody rbComponent;
    protected EntityHealth healthComponent;

    private void Start()
    {
        healthComponent = GetComponent<EntityHealth>();
        rbComponent = GetComponent<Rigidbody>();
    }

    public virtual bool Execute()       // overriden function to execute ability; return true if on cooldown, return false otherwise
    {
        if (abilityCooldown > 0 && abilityOnCooldown)
            return true;
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
