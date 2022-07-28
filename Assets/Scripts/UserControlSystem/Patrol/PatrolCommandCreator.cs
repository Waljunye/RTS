using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PatrolCommandCreator : CommandCreatorBase<IPatrolCommand>
{
    [Inject] private AssetsContext _context;

    private Action<IPatrolCommand> _creationCallback;

    [Inject]
    private void Init(Vector3ListValue patrolPosts)
    {
        patrolPosts.OnNewValue += OnNewValue;
    }

    private void OnNewValue(List<Vector3> patrolPoints)
    {
        _creationCallback?.Invoke(_context.inject(new PatrolCommand(patrolPoints)));
        _creationCallback = null;
    }
    protected override void SpecificCommandCreation(Action<IPatrolCommand> callback)
    {
        _creationCallback = callback;
    }
    public override void CancelCommand()
    {
        base.CancelCommand();

        _creationCallback = null;
    }
}
