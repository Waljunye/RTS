using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Outlines;
using Abstractions;
using UserControlSystem;

public class OutlineSelectorPresenter : MonoBehaviour
{
    [SerializeField] private SelectableValue _selectable;

    private OutlineSelector[] _outlineSelectors;
    private ISelectable _currentSelectable;

    private void Start()
    {
        _selectable.OnSelected += OnSelected;
        OnSelected(_selectable.CurrentValue);
    }

    private void OnSelected(ISelectable selecatable)
    {
        if(_currentSelectable == selecatable)
        {
            return;
        }
        _currentSelectable = selecatable;
        SetSelected(_outlineSelectors, false);
        _outlineSelectors = null;
        if(selecatable != null)
        {
            _outlineSelectors = (selecatable as Component).GetComponentsInParent<OutlineSelector>();
            SetSelected(_outlineSelectors, true);
        }
        
    }
    public static void SetSelected(OutlineSelector[] selectors, bool value)
    {
        if (selectors != null)
        {
            for (int i = 0; i < selectors.Length; i++)
            {
                selectors[i].SetSelected(value);
            }
        }
    }
}
