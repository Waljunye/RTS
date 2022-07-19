using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class MoveCommandCreator : CommandCreatorBase<IMoveCommand>
{
    [Inject] public AssetsContext _context;

    private Action<IMoveCommand> _creationCallback;

    [Inject] 
    private void Init(Vector3Value groundClicks)
    {
        groundClicks.OnNewValue += OnNewValue;
    }
    private void OnNewValue(Vector3 groundClick)
    {
        Debug.Log("NewValue");
        _creationCallback?.Invoke(_context.inject(new MoveCommand(groundClick)));
        _creationCallback = null;
    }
    protected override void SpecificCommandCreation(Action<IMoveCommand> callback)
    {
        _creationCallback = callback;
    }
    public override void CancelCommand()
    {
        base.CancelCommand();

        _creationCallback = null;
    }
}
