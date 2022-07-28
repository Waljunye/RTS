using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCommand : IAttackCommand
{
    public GameObject Target { get; }
    public AttackCommand(GameObject target)
    {
        Target = target;
    }
}
