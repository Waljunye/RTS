using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Abstractions;

public class Unit : MonoBehaviour, ISelectable
{
    public float Health => _health;

    public float MaxHealth => _maxHealth;

    public Sprite Icon => _icon;

    [SerializeField] private float _maxHealth = 1000;
    [SerializeField] private Sprite _icon;

    private float _health = 1000;

    public GameObject GetGameObject()
    {
        return gameObject;
    }
}
