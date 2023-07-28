using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class Evade : Ability
{
    [Header("Evade")]
    [SerializeField] private float evadeSpeedDistance = 2f;
    [SerializeField] private float evadeTime = 0f;
    [SerializeField] private float forceMult = 0f;
    [SerializeField] private AnimationCurve velocityCurve;

    private float elapsedTime;

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

        Vector2 direction = PlayerInput.instance.movementInput;
        rbComponent.AddForce(direction * forceMult);

        yield return new WaitForSeconds(evadeTime);
        rbComponent.velocity = Vector2.zero;
        playerComponent.GetMovement().StartMovement();
        healthComponent.ToggleInvulnerable(false);
    }
}
