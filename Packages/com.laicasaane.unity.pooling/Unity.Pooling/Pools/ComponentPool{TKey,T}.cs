using System;
using System.Pooling;
using Collections.Pooled.Generic;
using UnityEngine;

namespace Unity.Pooling
{
    public class ComponentPool<TKey, T>
        : ComponentPoolBase<TKey, T, ComponentSource<T>, ComponentPrefab<TKey, T, ComponentSource<T>>>
        where T : UnityEngine.Component
    {
        public ComponentPool()
            : base(null, null, default, null)
        { }

        public ComponentPool(ComponentPrefab<TKey, T, ComponentSource<T>> prefab, Transform defaultParent = null)
            : base(null, null, prefab, defaultParent)
        { }

        public ComponentPool(Dictionary<TKey, UniqueQueue<int, T>> queueMap
            , Func<UniqueQueue<int, T>> queueInstantiate
            , ComponentPrefab<TKey, T, ComponentSource<T>> prefab
            , Transform defaultParent = null
        )
            : base(queueMap, queueInstantiate, prefab, defaultParent)
        { }
    }
}
