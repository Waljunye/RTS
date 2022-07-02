using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Abstractions;
using UserControlSystem;
using System;

public class CommandButtonsPresenter : MonoBehaviour
{
    [SerializeField] private SelectableValue _selectable;
    [SerializeField] private CommandButtonsView _view;
    [SerializeField] private AssetsContext _context;

    private ISelectable _currentSelectable;

    private void Start()
    {
        _selectable.OnSelected += OnSelected;
        OnSelected(_selectable.CurrentValue);
        _view.OnClick += OnButtonClick;
    }

    private void OnSelected(ISelectable selectable)
    {
        if(_currentSelectable == selectable)
        {
            return;
        }
        _currentSelectable = selectable;

        _view.Clear();
        if(selectable != null)
        {
            var commandExecutors = new List<ICommandExecutor>();
            commandExecutors.AddRange((selectable as Component).GetComponentsInParent<ICommandExecutor>());
            _view.MakeLayout(commandExecutors);
        }
    }
    private void OnButtonClick(ICommandExecutor executor)
    {
        var unitProducer = executor as CommandExecutorBase<IProduceUnitCommand>;
        var unitAttacker = executor as CommandExecutorBase<IAttackCommand>;
        var unitMove = executor as CommandExecutorBase<IMoveCommand>;
        var unitStoper = executor as CommandExecutorBase<IStopCommand>;
        var unitPatroler = executor as CommandExecutorBase<IPatrolCommand>;
        var executed = false;
        if(unitProducer != null)
        {
            unitProducer.ExecuteSpecificCommand(_context.inject(new ProduceUnitCommandHeir()));
            executed = true;
        }
        if(unitAttacker != null)
        {
            unitAttacker.ExecuteSpecificCommand(new AttackCommand());
            executed = true;
        }
        if (unitMove != null)
        {
            unitMove.ExecuteSpecificCommand(new MoveCommand());
            executed = true;
        }
        if(unitStoper != null)
        {
            unitStoper.ExecuteSpecificCommand(new StopCommand());
            executed = true;
        }
        if(unitPatroler != null)
        {
            unitPatroler.ExecuteSpecificCommand(new PatrolCommand());
            executed = true;
        }
        if (executed) return;
        throw new ApplicationException($"{nameof(CommandButtonsPresenter)}.{nameof(OnButtonClick)}Unknown type of commands executor: { executor.GetType().FullName }!");
    }

}
