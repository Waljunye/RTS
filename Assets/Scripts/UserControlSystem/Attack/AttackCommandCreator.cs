using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class AttackCommandCreator : CommandCreatorBase<IAttackCommand>
{
    [Inject] private AssetsContext _context;

    private Action<IAttackCommand> _creationCallback;

    [Inject]
    private void Init(GameObjectValue clicksOnUnit)
    {
        clicksOnUnit.OnNewValue += OnNewValue;
    }
    private void OnNewValue(GameObject clickOnUnit)
    {
        _creationCallback?.Invoke(_context.inject(new AttackCommand(clickOnUnit)));
        _creationCallback = null;
    }
    protected override void SpecificCommandCreation(Action<IAttackCommand> callback)
    {
        _creationCallback = callback;
    }
    public override void CancelCommand()
    {
        base.CancelCommand();

        _creationCallback = null;
    }
}
