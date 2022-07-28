using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolCommand : IPatrolCommand
{
    public List<Vector3> Targets { get; private set;  }

    public PatrolCommand(List<Vector3> patroolPoints)
    {
        Targets = patroolPoints;
    }
}
