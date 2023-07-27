using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BubbleShield : Ability
{
    private const string SHIELD_BUBBLE = "Bubble Shield";

    [Header("Shield Bubble")]
    [SerializeField] private GameObject bubbleShield;
    [SerializeField] private float bubbleLifetime = 0f;

    private void Start()
    {
        if (!bubbleShield)      // If shieldBubble is null -> try to find
        {
            bubbleShield = GameObject.Find(SHIELD_BUBBLE);
        }
        bubbleShield.SetActive(false);      // shield bubble should not be active till used
    }

    public override bool Execute()
    {
        bool onCooldown = base.Execute();

        if (!onCooldown)
        {
            if (bubbleShield)
            {
                StartCoroutine(ShieldCo());
            }
        }
        return false;
    }

    private IEnumerator ShieldCo()
    {
        healthComponent.ToggleInvulnerable(true);
        bubbleShield.SetActive(true);
        yield return new WaitForSeconds(bubbleLifetime);
        bubbleShield.SetActive(false);
        healthComponent.ToggleInvulnerable(false);
    }
}
