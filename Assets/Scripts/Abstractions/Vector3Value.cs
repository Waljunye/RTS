using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName =  nameof(Vector3Value), menuName = "Strategy Game/" + nameof(Vector3Value), order = 3)]
public class Vector3Value : ScriptableObject
{
    public Vector3 CurrentValue { get; private set; }
    public Action<Vector3> OnNewValue;

    public void SetValue(Vector3 value)
    {
        CurrentValue = value;
        OnNewValue?.Invoke(value);
    }
}
