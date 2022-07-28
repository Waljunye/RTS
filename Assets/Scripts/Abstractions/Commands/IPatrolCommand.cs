using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPatrolCommand : ICommand
{
    public List<Vector3> Targets { get; }
}
