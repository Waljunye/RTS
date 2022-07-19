using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CommandExecutorBase<T> : MonoBehaviour, ICommandExecutor where T : ICommand
{
    public void ExecuteCommand(object Command) => ExecuteSpecificCommand((T)Command);

    public abstract void ExecuteSpecificCommand(T command);
}
