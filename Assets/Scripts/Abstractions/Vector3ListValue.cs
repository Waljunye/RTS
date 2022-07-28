using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(Vector3ListValue), menuName = "Strategy Game/" + nameof(Vector3ListValue), order = 4)]
public class Vector3ListValue : ScriptableObject
{
    public List<Vector3> _listOfVector3Values { get; private set; }
    public Action<List<Vector3>> OnNewValue;
    public Action OnNull;

    public void SetValue(List<Vector3> values)
    {
        _listOfVector3Values = new List<Vector3>();
        foreach(Vector3 value in values)
        {
            _listOfVector3Values.Add(value);
        }
        OnNewValue?.Invoke(values);
    }
    public void SetNull()
    { 
        _listOfVector3Values = null;
        OnNull?.Invoke();
    }
}
