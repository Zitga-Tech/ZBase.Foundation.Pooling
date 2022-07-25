using System;
using System.Pooling;
using System.Runtime.CompilerServices;

namespace Unity.Pooling
{
    [Serializable]
    public abstract class ComponentPoolBase<T, TSource, TPrefab>
        : UnityPool<T, TSource, TPrefab>
        where T : UnityEngine.Component
        where TPrefab : IPrefab<T, TSource>
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
        protected override void ReturnPreprocess(T instance)
        {
            if (instance.gameObject.activeSelf)
                instance.gameObject.SetActive(false);
        }
    }
}
