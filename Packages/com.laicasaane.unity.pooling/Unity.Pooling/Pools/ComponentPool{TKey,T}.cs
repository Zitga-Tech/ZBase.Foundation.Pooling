using System;
using System.Pooling;
using Collections.Pooled.Generic;
using UnityEngine;

namespace Unity.Pooling
{
    public class ComponentPool<TKey, T>
        : ComponentPoolBase<TKey, T, T, ComponentInstantiator<T>, ComponentPrefab<TKey, T, ComponentInstantiator<T>>>
        where T : UnityEngine.Component
    {
        public ComponentPool()
            : base(null, null, default, null)
        { }

        public ComponentPool(ComponentPrefab<TKey, T, ComponentInstantiator<T>> prefab, Transform defaultParent = null)
            : base(null, null, prefab, defaultParent)
        { }

        public ComponentPool(Dictionary<TKey, UniqueQueue<int, T>> queueMap
            , Func<UniqueQueue<int, T>> queueInstantiate
            , ComponentPrefab<TKey, T, ComponentInstantiator<T>> prefab
            , Transform defaultParent = null
        )
            : base(queueMap, queueInstantiate, prefab, defaultParent)
        { }
    }
}
