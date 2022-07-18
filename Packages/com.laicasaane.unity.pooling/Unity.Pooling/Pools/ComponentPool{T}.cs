using System;
using System.Pooling;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Unity.Pooling
{
    public class ComponentPool<T> : UnityPoolBase<T>
        where T : UnityEngine.Component
    {
        public ComponentPool()
            : base(null, null)
        { }

        public ComponentPool(UniqueQueue<int, T> queue)
            : base(queue, null)
        { }

        public ComponentPool(Func<T> instantiate)
            : base(null, instantiate)
        { }

        public ComponentPool(UniqueQueue<int, T> queue, Func<T> instantiate)
            : base(queue, instantiate)
        { }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override void ReturnPreprocess(T instance)
        {
            if (instance.gameObject.activeSelf)
                instance.gameObject.SetActive(false);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override Func<T> GetDefaultInstantiator()
            => Instantiator;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static T Instantiator()
        {
            var go = new GameObject(NameOf<T>.Value);
            var instance = go.AddComponent<T>();
            return instance;
        }
    }
}
