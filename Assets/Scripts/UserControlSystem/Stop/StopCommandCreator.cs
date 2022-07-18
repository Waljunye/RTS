using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class StopCommandCreator : CommandCreatorBase<IStopCommand>
{
    [Inject] private AssetsContext _context;
    protected override void SpecificCommandCreation(Action<IStopCommand> callback)
    {
        callback?.Invoke(_context.inject(new StopCommand()));
    }
}
