using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class Evade : Ability
{
    private const string EVADE_TRIGGER = "evade";   // Trigger needed in animator to do evade animation

    [Header("Evade")]
    [SerializeField] private float evadeTime = 0f;
    [SerializeField] private float forceMult = 0f;
    [SerializeField] private AnimationCurve velocityCurve;

    private float elapsedTime;

    // Components
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

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
        healthComponent.ToggleInvulnerable(true);               // Handle before evade
        playerComponent.GetMovement().HaltMovementandInput();
        HandleAnimation();

        Vector2 direction = PlayerInput.instance.movementInput;     // Handle during evade
        rbComponent.AddForce(direction * forceMult);
        yield return new WaitForSeconds(evadeTime);

        rbComponent.velocity = Vector2.zero;                    // Handle after evade
        playerComponent.GetMovement().StartMovement();
        healthComponent.ToggleInvulnerable(false);
    }

    private void HandleAnimation()
    {
        anim.SetTrigger(EVADE_TRIGGER);
    }
}
