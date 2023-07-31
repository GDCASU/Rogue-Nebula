using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class IntVariable : ScriptableObject
{
    public int initialValue;

    [NonSerialized]
    public float runTimeValue;

    public void OnAfterDeserialize()
    {
        runTimeValue = initialValue;
    }

    public void OnBeforeSerialize() { }
}
