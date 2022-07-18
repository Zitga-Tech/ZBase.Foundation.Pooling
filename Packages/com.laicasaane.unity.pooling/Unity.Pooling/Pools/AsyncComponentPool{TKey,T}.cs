using System;
using System.Pooling;
using System.Runtime.CompilerServices;
using Collections.Pooled.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Unity.Pooling
{
    public class AsyncComponentPool<TKey, T> : AsyncUnityPoolBase<TKey, T>
        where T : UnityEngine.Component
    {
        public static readonly AsyncComponentPool<TKey, T> Shared  = new AsyncComponentPool<TKey, T>();

        public AsyncComponentPool()
            : base(null, null, null)
        { }

        public AsyncComponentPool(UniTaskFunc<T> instantiate)
            : base(null, null, instantiate)
        { }

        public AsyncComponentPool(Dictionary<TKey, UniqueQueue<int, T>> queueMap
            , Func<UniqueQueue<int, T>> queueInstantiate
        )
            : base(queueMap, queueInstantiate, null)
        { }

        public AsyncComponentPool(Dictionary<TKey, UniqueQueue<int, T>> queueMap
            , Func<UniqueQueue<int, T>> queueInstantiate
            , UniTaskFunc<T> instantiate
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
        protected override UniTaskFunc<T> GetDefaultInstantiator()
            => Instantiator;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static UniTask<T> Instantiator()
        {
            var go = new GameObject(NameOf<T>.Value);
            var instance = go.AddComponent<T>();
            return UniTask.FromResult(instance);
        }
    }
}
