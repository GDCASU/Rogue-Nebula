using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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
        healthComponent.ToggleInvulnerable(true);
        playerComponent.GetMovement().HaltMovementandInput();

        //Vector2 direction = PlayerInput.instance.movementInput;

        yield return new WaitForSeconds(evadeTime);
        //rbComponent.velocity = Vector2.zero;
        playerComponent.GetMovement().StartMovement();
        healthComponent.ToggleInvulnerable(false);
    }
}
