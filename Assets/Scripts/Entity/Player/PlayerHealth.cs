using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using UnityEngine.Events;


public class PlayerHealth : EntityHealth
{
    // USE THE LINES BELOW IF USING A HARD CODED EVENT SYSTEM
    //public static event Action<int> onPlayerHurt;
    //public static event Action<int> onPlayerHeal;

    [Header("Unity Events")]
    [SerializeField] public UnityEvent<int> onPlayerHurt;        // Unity event for the Player Health UI
    [SerializeField] public UnityEvent<int> onPlayerHeal;        // Unity event for the Player Health UI
    [SerializeField] public UnityEvent onPlayerDeath;

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        onPlayerHurt?.Invoke(damage);       // Update UI
    }

    public override void Heal(int amount)
    {
        base.Heal(amount);
        onPlayerHeal?.Invoke(amount);       // Update UI
    }

    protected override void Death()
    {
        base.Death();
        onPlayerDeath?.Invoke();
    }
}
