﻿using UnityEngine;

namespace Abstractions
{
    public interface ISelectable
    {
        float Health { get; }
        float MaxHealth { get; }
        Sprite Icon { get; }

        void OnSelect();
        void UnSelect();
    }
}