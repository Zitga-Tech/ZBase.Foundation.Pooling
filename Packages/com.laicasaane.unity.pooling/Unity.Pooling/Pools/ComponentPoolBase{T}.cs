using System;
using System.Pooling;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Unity.Pooling
{
    [Serializable]
    public abstract class ComponentPoolBase<T, TSource, TInstantiator, TPrefab>
        : UnityPool<T, TSource, TInstantiator, TPrefab>
        where T : UnityEngine.Component
        where TInstantiator : IAsyncInstantiable<TSource, T>
        where TPrefab : IPrefab<T, TSource, TInstantiator>
    {
        public ComponentPoolBase()
            : base(null, default, null)
        { }

        public ComponentPoolBase(TPrefab prefab, Transform defaultParent = null)
            : base(null, prefab, defaultParent)
        { }

        public ComponentPoolBase(UniqueQueue<int, T> queue, TPrefab prefab, Transform defaultParent = null)
            : base(queue, prefab, defaultParent)
        { }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected sealed override void ReturnPreprocess(T instance)
        {
            if (instance.gameObject.activeSelf)
                instance.gameObject.SetActive(false);
        }
    }
}
