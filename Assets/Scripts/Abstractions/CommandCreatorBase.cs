using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CommandCreatorBase<T> where T : ICommand
{
    public ICommandExecutor ProcessCommandExecutor(ICommandExecutor commandExecutor, Action<T> callback)
    {
        var specificCommandExecutor = commandExecutor as CommandExecutorBase<T>;
        if (specificCommandExecutor != null)
        {
            SpecificCommandCreation(callback);
        }
        return commandExecutor;
    }
    protected abstract void SpecificCommandCreation(Action<T> callback);
    public virtual void CancelCommand() { }
}
