using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class MoveCommandCreator : CommandCreatorBase<IMoveCommand>
{
    [Inject] public AssetsContext _context;
    protected override void SpecificCommandCreation(Action<IMoveCommand> callback)
    {
        callback?.Invoke(_context.inject(new MoveCommand()));
    }
}
