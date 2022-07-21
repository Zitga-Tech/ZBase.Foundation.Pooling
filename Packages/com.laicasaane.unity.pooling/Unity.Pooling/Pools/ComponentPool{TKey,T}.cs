using System;
using System.Pooling;
using System.Runtime.CompilerServices;
using Collections.Pooled.Generic;
using UnityEngine;

namespace Unity.Pooling
{
    public abstract class ComponentPoolBase<TKey, T, TSource, TPrefab>
        : UnityPool<TKey, T, T, TSource, TPrefab>
        where T : UnityEngine.Component
        where TSource : IAsyncInstantiatableSource<T, T>
        where TPrefab : IPrefab<TKey, T, T, TSource>
    {
        public ComponentPoolBase()
            : base(null, null, default, null)
        { }

        public ComponentPoolBase(TPrefab prefab, Transform defaultParent = null)
            : base(null, null, prefab, defaultParent)
        { }

        public ComponentPoolBase(Dictionary<TKey, UniqueQueue<int, T>> queueMap
            , Func<UniqueQueue<int, T>> queueInstantiate
            , TPrefab prefab
            , Transform defaultParent = null
        )
            : base(queueMap, queueInstantiate, prefab, defaultParent)
        { }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected sealed override void ReturnPreprocess(T instance)
        {
            if (instance.gameObject.activeSelf)
                instance.gameObject.SetActive(false);
        }
    }
}
