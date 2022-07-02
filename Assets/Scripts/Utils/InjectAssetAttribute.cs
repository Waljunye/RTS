using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AttributeUsage(AttributeTargets.Field, Inherited = true, AllowMultiple = true)]
public class InjectAssetAttribute : Attribute
{
    public readonly string AssetName;
    public InjectAssetAttribute(string assetName)
    {
        AssetName = assetName;
    }
}
