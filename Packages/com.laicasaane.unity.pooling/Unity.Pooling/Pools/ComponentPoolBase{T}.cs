using System;
using System.Pooling;
using System.Runtime.CompilerServices;

namespace Unity.Pooling
{
    [Serializable]
    public abstract class ComponentPoolBase<T, TSource, TInstantiator, TPrefab>
        : UnityPool<T, TSource, TInstantiator, TPrefab>
        where T : UnityEngine.Component
        where TInstantiator : IAsyncInstantiator<TSource, T>
        where TPrefab : IPrefab<T, TSource, TInstantiator>
    {
        public ComponentPoolBase()
            : base(null, default)
        { }

        public ComponentPoolBase(TPrefab prefab)
            : base(null, prefab)
        { }

        public ComponentPoolBase(UniqueQueue<int, T> queue, TPrefab prefab)
            : base(queue, prefab)
        { }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected sealed override void ReturnPreprocess(T instance)
        {
            if (instance.gameObject.activeSelf)
                instance.gameObject.SetActive(false);
        }
    }
}
