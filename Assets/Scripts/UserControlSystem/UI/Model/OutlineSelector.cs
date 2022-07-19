using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Outlines;
using System.Linq;

namespace Outlines
{
    public class OutlineSelector : MonoBehaviour
    {
        [SerializeField] private Renderer[] _renderers;
        [SerializeField] private Material[] _materials;

        private bool _isSelectedCache;

        public void SetSelected(bool isSelected)
        {
            if (isSelected == _isSelectedCache)
            {
                return;
            }
            for (int i = 0; i < _renderers.Length; i++)
            {
                var renderer = _renderers[i];
                var materialList = renderer.materials.ToList();
                if (isSelected)
                {
                    foreach(Material material in _materials)
                    {
                        materialList.Add(material);
                    }
                }
                else
                {
                    materialList.RemoveAt(materialList.Count - 1);
                    materialList.RemoveAt(materialList.Count - 1);
                }
                renderer.materials = materialList.ToArray();

            }
            _isSelectedCache = isSelected;
        }
    }

}