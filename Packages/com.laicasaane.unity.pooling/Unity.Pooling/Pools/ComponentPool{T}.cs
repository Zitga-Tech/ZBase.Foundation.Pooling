using System;
using System.Pooling;
using UnityEngine;

namespace Unity.Pooling
{
    [Serializable]
    public class ComponentPool<T>
        : ComponentPoolBase<T, T, ComponentInstantiator<T>, ComponentPrefab<T, ComponentInstantiator<T>>>
        where T : UnityEngine.Component
    {
        public ComponentPool()
            : base(null, default, null)
        { }

        public ComponentPool(ComponentPrefab<T, ComponentInstantiator<T>> prefab, Transform defaultParent = null)
            : base(null, prefab, defaultParent)
        { }

        public ComponentPool(UniqueQueue<int, T> queue, ComponentPrefab<T, ComponentInstantiator<T>> prefab, Transform defaultParent = null)
            : base(queue, prefab, defaultParent)
        { }
    }
}
