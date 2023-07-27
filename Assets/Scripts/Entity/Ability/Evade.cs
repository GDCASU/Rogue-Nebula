using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class Evade : Ability
{
    [Header("Evade")]
    [SerializeField] private float evadeSpeedMultiplier = 2f;
    [SerializeField] private float evadeTime = 1f;
    [SerializeField] private float invulnerabilityTime = 1f;

    public override bool Execute()
    {
        bool onCooldown = base.Execute();

        if (!onCooldown)
        {
            if (rbComponent != null)
            {
                StartCoroutine(EvadeCo());
            }
            
        }
        return false;
    }

    private IEnumerator EvadeCo()
    {
        if (healthComponent != null)
            healthComponent.MakeInvulnerable(invulnerabilityTime);
        Vector2 force = PlayerInput.instance.movementInput * evadeSpeedMultiplier;
        rbComponent.AddForce(force, ForceMode.Impulse);
        yield return new WaitForSeconds(evadeTime);
        rbComponent.velocity = Vector2.zero;
    }
}
