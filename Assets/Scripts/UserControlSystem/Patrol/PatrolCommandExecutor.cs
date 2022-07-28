using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PatrolCommandExecutor : CommandExecutorBase<IPatrolCommand>
{
    [Inject] private Vector3Value _SinglePatroolPoint;
    private MoveCommandExecutor _mover;

    public override void ExecuteSpecificCommand(IPatrolCommand command)
    {
        Debug.Log("Patrol Points");
        _mover = gameObject.GetComponent<MoveCommandExecutor>();
        
        foreach (Vector3 Target in command.Targets)
        {
            _mover.ExecuteSpecificCommand(new MoveCommand(Target));
        }
        Debug.Log("Patrol Ended");
    }
}
