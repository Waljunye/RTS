using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stop : CommandExecutorBase<IStopCommand>
{
    public override void ExecuteSpecificCommand(IStopCommand command)
    {
        Debug.Log("Stop");

    }
}
