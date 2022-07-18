using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class AttackCommandCreator : CommandCreatorBase<IAttackCommand>
{
    [Inject] private AssetsContext _context;
    protected override void SpecificCommandCreation(Action<IAttackCommand> callback)
    {
        callback?.Invoke(_context.inject(new AttackCommand()));
    }
}
