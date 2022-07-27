using System;
using System.Pooling;
using System.Runtime.CompilerServices;

namespace Unity.Pooling
{
    [Serializable]
    public class ComponentPool<T, TSource, TPrefab>
        : UnityPool<T, TSource, TPrefab>
        where T : UnityEngine.Component
        where TPrefab : IPrefab<T, TSource>
    {
        public ComponentPool()
            : base(null, default)
        { }

        public ComponentPool(TPrefab prefab)
            : base(null, prefab)
        { }

        public ComponentPool(UniqueQueue<int, T> queue, TPrefab prefab)
            : base(queue, prefab)
        { }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override void ReturnPreprocess(T instance)
        {
            if (instance && instance.gameObject && instance.gameObject.activeSelf)
                instance.gameObject.SetActive(false);
        }
    }
}
