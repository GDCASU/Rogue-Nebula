using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBubble : Ability
{
    public override bool Execute()
    {
        bool onCooldown = base.Execute();

        if (!onCooldown)
        {
            Debug.Log("Shield!");
        }
        return false;
    }
}
