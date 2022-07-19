using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : CommandExecutorBase<IMoveCommand>
{
    public override void ExecuteSpecificCommand(IMoveCommand command)
    {
        Debug.Log($"{name}moved to {command.Target}");
    }
}
