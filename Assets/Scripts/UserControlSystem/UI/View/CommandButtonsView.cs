using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CommandButtonsView : MonoBehaviour
{
    public Action<ICommandExecutor> OnClick;

    [SerializeField] private GameObject _attackButton;
    [SerializeField] private GameObject _moveButton;
    [SerializeField] private GameObject _patrolButton;
    [SerializeField] private GameObject _stopButton;
    [SerializeField] private GameObject _produceUnitButton;

    private Dictionary<Type, GameObject> _buttonsByExecutorType;

    private void Start()
    {
        _buttonsByExecutorType = new Dictionary<Type, GameObject>();

        _buttonsByExecutorType
            .Add(typeof(CommandExecutorBase<IAttackCommand>), _attackButton);
        _buttonsByExecutorType
            .Add(typeof(CommandExecutorBase<IMoveCommand>), _moveButton);
        _buttonsByExecutorType
            .Add(typeof(CommandExecutorBase<IPatrolCommand>), _patrolButton);
        _buttonsByExecutorType
            .Add(typeof(CommandExecutorBase<IStopCommand>), _stopButton);
        _buttonsByExecutorType
            .Add(typeof(CommandExecutorBase<IProduceUnitCommand>),
        _produceUnitButton);
    }
    public void BlockInteractions(ICommandExecutor commandExecutor)
    {
        UnblockAllInteractions();
        getButtonGameObjectByType(commandExecutor.GetType())
            .GetComponent<Selectable>()
            .interactable = false;
    }
    public void UnblockAllInteractions() => SetInteractible(true);
    private void SetInteractible(bool value)
    {
        _attackButton.GetComponent<Selectable>().interactable = value;
        _moveButton.GetComponent<Selectable>().interactable = value;
        _stopButton.GetComponent<Selectable>().interactable = value;
        _patrolButton.GetComponent<Selectable>().interactable = value;
        _produceUnitButton.GetComponent<Selectable>().interactable = value;
    }
    private GameObject getButtonGameObjectByType(Type buttonExecutorType)
    {
        return  _buttonsByExecutorType
                .First(type => type.Key.IsAssignableFrom(buttonExecutorType))
                .Value;
    }
    public void MakeLayout(List <ICommandExecutor> commandExecutors)
    {
        foreach(var commandExecutor in commandExecutors)
        {
            var buttonGameObject = getButtonGameObjectByType(commandExecutor.GetType());
            buttonGameObject.SetActive(true);
            var button = buttonGameObject.GetComponent<Button>();
            button.onClick.AddListener(() => OnClick?.Invoke(commandExecutor));
        }
    }
    public void Clear()
    {
        foreach(var kvp in _buttonsByExecutorType)
        {
            kvp.Value.GetComponent<Button>().onClick.RemoveAllListeners();
            kvp.Value.SetActive(false);
        }
    }
}
