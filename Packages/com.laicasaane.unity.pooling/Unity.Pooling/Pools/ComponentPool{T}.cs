using System.Pooling;
using UnityEngine;

namespace Unity.Pooling
{
    public class ComponentPool<T>
        : ComponentPoolBase<T, ComponentSource<T>, ComponentPrefab<T, ComponentSource<T>>>
        where T : UnityEngine.Component
    {
        public ComponentPool()
            : base(null, default, null)
        { }

        public ComponentPool(ComponentPrefab<T, ComponentSource<T>> prefab, Transform defaultParent = null)
            : base(null, prefab, defaultParent)
        { }

        public ComponentPool(UniqueQueue<int, T> queue, ComponentPrefab<T, ComponentSource<T>> prefab, Transform defaultParent = null)
            : base(queue, prefab, defaultParent)
        { }
    }
}
