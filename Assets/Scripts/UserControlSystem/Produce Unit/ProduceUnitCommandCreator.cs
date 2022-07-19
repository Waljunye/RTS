using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ProduceUnitCommandCreator : CommandCreatorBase<IProduceUnitCommand>
{
    [Inject] private AssetsContext _context;

    protected override void SpecificCommandCreation(Action<IProduceUnitCommand> callback)
    {
        callback?.Invoke(_context.inject(new ProduceUnitCommandHeir()));
    }
}
