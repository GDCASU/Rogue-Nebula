using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evade : Ability
{
    public override bool Execute()
    {
        bool onCooldown = base.Execute();

        if (!onCooldown)
        {
            Debug.Log("Evade!");
        }
        return false;
    }
}
