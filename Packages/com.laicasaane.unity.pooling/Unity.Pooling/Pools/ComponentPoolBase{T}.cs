using System.Pooling;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Unity.Pooling
{
    public abstract class ComponentPoolBase<T, TSource, TPrefab>
        : UnityPool<T, T, TSource, TPrefab>
        where T : UnityEngine.Component
        where TSource : IAsyncInstantiatableSource<T, T>
        where TPrefab : IPrefab<T, T, TSource>
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
