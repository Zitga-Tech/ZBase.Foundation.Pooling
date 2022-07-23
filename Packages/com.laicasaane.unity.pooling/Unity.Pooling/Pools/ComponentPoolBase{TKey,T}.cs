using System;
using System.Pooling;
using System.Runtime.CompilerServices;
using Collections.Pooled.Generic;
using UnityEngine;

namespace Unity.Pooling
{
    [Serializable]
    public abstract class ComponentPoolBase<TKey, T, TSource, TInstantiator, TPrefab>
        : UnityPool<TKey, T, TSource, TInstantiator, TPrefab>
        where T : UnityEngine.Component
        where TInstantiator : IAsyncInstantiator<TSource, T>
        where TPrefab : IPrefab<TKey, T, TSource, TInstantiator>
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
