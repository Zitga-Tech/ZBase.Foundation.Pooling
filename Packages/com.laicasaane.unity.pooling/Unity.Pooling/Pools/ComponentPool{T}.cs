using System;
using System.Pooling;

namespace Unity.Pooling
{
    [Serializable]
    public class ComponentPool<T>
        : ComponentPool<T, ComponentPrefab<T>>
        where T : UnityEngine.Component
    {
        public ComponentPool()
            : base(null, default)
        { }

        public ComponentPool(ComponentPrefab<T> prefab)
            : base(null, prefab)
        { }

        public ComponentPool(UniqueQueue<int, T> queue, ComponentPrefab<T> prefab)
            : base(queue, prefab)
        { }
    }
}
