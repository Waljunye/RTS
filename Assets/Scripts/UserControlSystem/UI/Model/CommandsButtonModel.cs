using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CommandsButtonModel
{
    public event Action<ICommandExecutor> OnCommandAccepted;
    public event Action OnCommandSent;
    public event Action OnCommandCancel;

    [Inject] private CommandCreatorBase<IProduceUnitCommand> _unitProducer;
    [Inject] private CommandCreatorBase<IAttackCommand> _attacker;
    [Inject] private CommandCreatorBase<IMoveCommand> _mover;
    [Inject] private CommandCreatorBase<IPatrolCommand> _patroler;
    [Inject] private CommandCreatorBase<IStopCommand> _stoper;

    private bool _isCommandPending;

    public void onCommandButtonClicked(ICommandExecutor commandExecutor)
    {
        if (_isCommandPending)
        {
            onProcessCancel();
        }
        _isCommandPending = true;
        OnCommandAccepted?.Invoke(commandExecutor);

        _unitProducer.ProcessCommandExecutor(commandExecutor, 
            command => executeCommandWrapper(commandExecutor, command));
        _attacker.ProcessCommandExecutor(commandExecutor, 
            command => executeCommandWrapper(commandExecutor, command));
        _mover.ProcessCommandExecutor(commandExecutor, 
            command => executeCommandWrapper(commandExecutor, command));
        _patroler.ProcessCommandExecutor(commandExecutor, 
            command => executeCommandWrapper(commandExecutor, command));
        _stoper.ProcessCommandExecutor(commandExecutor, 
            command => executeCommandWrapper(commandExecutor, command));
    }
    public void executeCommandWrapper(ICommandExecutor commandExecutor, object command)
    {
        Debug.Log($"Executed command Wrapper {commandExecutor.GetType()}");
        commandExecutor.ExecuteCommand(command);
        _isCommandPending = false;
        OnCommandSent?.Invoke();
    }
    public void OnSelectedChanged()
    {
        _isCommandPending = false;
        onProcessCancel();
    }
    public void onProcessCancel()
    {
        _unitProducer.CancelCommand();
        _attacker.CancelCommand();
        _mover.CancelCommand();
        _patroler.CancelCommand();
        _stoper.CancelCommand();

        OnCommandCancel?.Invoke();
    }
}
