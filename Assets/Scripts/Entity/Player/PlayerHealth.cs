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

    public UnityEvent<int> onPlayerHurt;
    public UnityEvent<int> onPlayerHeal;

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        onPlayerHurt?.Invoke(damage);
    }

    public override void Heal(int amount)
    {
        base.Heal(amount);
        onPlayerHeal?.Invoke(amount);
    }
}
