using System.Linq;
using Abstractions;
using UnityEngine;
using UserControlSystem;
using UnityEngine.EventSystems;
using System;
using System.Collections.Generic;

public sealed class MouseInteractionPresenter : MonoBehaviour
{
    [SerializeField] private EventSystem _eventSystem;
    [SerializeField] private Camera _camera;
    [SerializeField] private SelectableValue _selectedObject;

    [SerializeField] private Vector3Value _groundClickRMB;
    [SerializeField] private Vector3ListValue _patrolPointsSO;

    [SerializeField] private GameObjectValue _clickOnUnitRMB;
    [SerializeField] private Transform _groundTransform;

    private Plane _groundPlane;
    private List<Vector3> _listOfPatrolPoints;
    private void Start()
    {
        _groundPlane = new Plane(_groundTransform.up, 0);
        _listOfPatrolPoints = new List<Vector3>();
    }

    private void Update()
    {
        if (!Input.GetMouseButtonUp(0) && !Input.GetMouseButton(1))
        {
            return;
        }
        if (_eventSystem.IsPointerOverGameObject())
        {
            return;
        }
        var ray = _camera.ScreenPointToRay(Input.mousePosition);
        if (Input.GetMouseButtonUp(0))
        {
            var hits = Physics.RaycastAll(ray);
            if(hits.Length == 0)
            {
                return;
            }
            var selectable = hits
                .Select(hit => hit.collider.GetComponentInParent<ISelectable>())
                .FirstOrDefault(c => c != null);
            _selectedObject.SetValue(selectable);
            DeletePatrolPoints();
        }
        else if(Input.GetAxis("MultiAction") == 0)
        {
            if(_groundPlane.Raycast(ray, out var enter))
            {
                _groundClickRMB.SetValue(ray.origin + ray.direction * enter);
                var hits = Physics.RaycastAll(ray);
                if(hits.Length == 0)
                {
                    return;
                }
                var selectable = hits
                    .Select(hit => hit.collider.GetComponentInParent<ISelectable>())
                    .FirstOrDefault(c => c != null);
                DeletePatrolPoints();
                try
                {
                    var hittableGameObject = selectable.GetGameObject();
                    _clickOnUnitRMB.SetValue(hittableGameObject);
                    
                }
                catch (NullReferenceException nrEx)
                {
                    Debug.Log("ISelectable Not Found");
                }
                
            }
        }
        
        
        if(Input.GetMouseButtonDown(1) && Input.GetAxis("MultiAction") != 0)
        {
            _groundPlane.Raycast(ray, out var enter);
            var hits = Physics.RaycastAll(ray);
            if (hits.Length == 0)
            {
                return;
            }
            _listOfPatrolPoints.Add(ray.origin + ray.direction * enter);
            if (!_listOfPatrolPoints.Equals(_patrolPointsSO._listOfVector3Values))
            {
                
                _patrolPointsSO.SetValue(_listOfPatrolPoints);
            }
        }
       
    }
    private void DeletePatrolPoints()
    {
        _listOfPatrolPoints = new List<Vector3>();
        _patrolPointsSO.SetNull();
    }
}