using System;
using System.Pooling;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Unity.Pooling
{
    [Serializable]
    public class ComponentPool<T, TPrefab>
        : UnityPool<T, TPrefab>
        where T : UnityEngine.Component
        where TPrefab : IPrefab<T>
    {
        [SerializeField]
        private bool _dontApplyPrefabParentOnReturn;

        public ComponentPool()
            : base()
        { }

        public ComponentPool(TPrefab prefab)
            : base(prefab)
        { }

        public ComponentPool(UniqueQueue<int, T> queue)
            : base(queue)
        { }

        public ComponentPool(UniqueQueue<int, T> queue, TPrefab prefab)
            : base(queue, prefab)
        { }

        public bool DontApplyPrefabParentOnReturn
        {
            get => _dontApplyPrefabParentOnReturn;
            set => _dontApplyPrefabParentOnReturn = value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override void ReturnPreprocess(T instance)
        {
            if (instance == false || instance.gameObject == false)
            {
                return;
            }

            instance.gameObject.SetActive(false);

            if (_dontApplyPrefabParentOnReturn == false && Prefab != null)
            {
                instance.transform.SetParent(Prefab.Parent);
            }
        }
    }
}
