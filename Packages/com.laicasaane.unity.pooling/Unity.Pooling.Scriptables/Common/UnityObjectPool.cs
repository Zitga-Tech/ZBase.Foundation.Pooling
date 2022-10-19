using System;
using UnityEngine;

namespace Unity.Pooling.Scriptables
{
    [Serializable]
    public class UnityObjectPool : UnityPool<UnityEngine.Object, UnityObjectPrefab>
    {
        [SerializeField]
        private bool _dontApplyPrefabParentOnReturn;

        public bool DontApplyPrefabParentOnReturn
        {
            get => _dontApplyPrefabParentOnReturn;
            set => _dontApplyPrefabParentOnReturn = value;
        }

        protected override void ReturnPreprocess(UnityEngine.Object instance)
        {
            if (instance is GameObject gameObject)
            {
                gameObject.SetActive(false);
                ApplyPrefabParent(gameObject.transform);
            }
            else if (instance is Component component && component.gameObject)
            {
                component.gameObject.SetActive(false);
                ApplyPrefabParent(component.transform);
            }
        }

        private void ApplyPrefabParent(Transform instance)
        {
            if (_dontApplyPrefabParentOnReturn == false && Prefab != null)
            {
                instance.SetParent(Prefab.Parent);
            }
        }
    }
}
