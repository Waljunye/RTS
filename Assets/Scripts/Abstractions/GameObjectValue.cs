using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameObjectValue", menuName = "Strategy Game / " + nameof(GameObjectValue), order = 4)]
public class GameObjectValue : ScriptableObject
{
    public GameObject CurrentValue { get; private set; }
    public Action<GameObject> OnNewValue;

    public void SetValue(GameObject newValue)
    {
        CurrentValue = newValue;
        OnNewValue?.Invoke(newValue);
    }
}
