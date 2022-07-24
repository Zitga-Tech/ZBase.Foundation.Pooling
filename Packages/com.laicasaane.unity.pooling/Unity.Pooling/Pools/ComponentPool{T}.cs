using System;
using System.Pooling;

namespace Unity.Pooling
{
    [Serializable]
    public class ComponentPool<T>
        : ComponentPoolBase<T, T, ComponentInstantiator<T>, ComponentPrefab<T, ComponentInstantiator<T>>>
        where T : UnityEngine.Component
    {
        public ComponentPool()
            : base(null, default)
        { }

        public ComponentPool(ComponentPrefab<T, ComponentInstantiator<T>> prefab)
            : base(null, prefab)
        { }

        public ComponentPool(UniqueQueue<int, T> queue, ComponentPrefab<T, ComponentInstantiator<T>> prefab)
            : base(queue, prefab)
        { }
    }
}
