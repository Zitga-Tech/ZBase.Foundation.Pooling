using System;
using System.Pooling;
using System.Runtime.CompilerServices;
using Collections.Pooled.Generic;
using UnityEngine;

namespace Unity.Pooling
{
    public class ComponentPool<TKey, T> : UnityPoolBase<TKey, T>
        where T : UnityEngine.Component
    {
        public static readonly ComponentPool<TKey, T> Shared  = new ComponentPool<TKey, T>();

        public ComponentPool()
            : base(null, null, null)
        { }

        public ComponentPool(Func<T> instantiate)
            : base(null, null, instantiate)
        { }

        public ComponentPool(Dictionary<TKey, UniqueQueue<int, T>> queueMap
            , Func<UniqueQueue<int, T>> queueInstantiate
        )
            : base(queueMap, queueInstantiate, null)
        { }

        public ComponentPool(Dictionary<TKey, UniqueQueue<int, T>> queueMap
            , Func<UniqueQueue<int, T>> queueInstantiate
            , Func<T> instantiate
        )
            : base(queueMap, queueInstantiate, instantiate)
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
