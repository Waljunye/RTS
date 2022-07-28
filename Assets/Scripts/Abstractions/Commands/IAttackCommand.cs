using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttackCommand : ICommand
{
    GameObject Target { get; }
}
