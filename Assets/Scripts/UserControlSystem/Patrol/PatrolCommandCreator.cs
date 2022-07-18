using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PatrolCommandCreator : CommandCreatorBase<IPatrolCommand>
{
    [Inject] private AssetsContext _context;
    protected override void SpecificCommandCreation(Action<IPatrolCommand> callback)
    {
        callback?.Invoke(_context.inject(new PatrolCommand()));
    }
}
