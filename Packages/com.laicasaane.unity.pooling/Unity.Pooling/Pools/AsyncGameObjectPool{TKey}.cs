using System;
using System.Pooling;
using System.Runtime.CompilerServices;
using Collections.Pooled.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Unity.Pooling
{
    public class AsyncGameObjectPool<TKey> : AsyncUnityPoolBase<TKey, GameObject>
    {
        public AsyncGameObjectPool()
            : base(null, null, null)
        { }

        public AsyncGameObjectPool(UniTaskFunc<GameObject> instantiate)
            : base(null, null, instantiate)
        { }

        public AsyncGameObjectPool(Dictionary<TKey, UniqueQueue<int, GameObject>> queueMap
            , Func<UniqueQueue<int, GameObject>> queueInstantiate
        )
            : base(queueMap, queueInstantiate, null)
        { }

        public AsyncGameObjectPool(Dictionary<TKey, UniqueQueue<int, GameObject>> queueMap
            , Func<UniqueQueue<int, GameObject>> queueInstantiate
            , UniTaskFunc<GameObject> instantiate
        )
            : base(queueMap, queueInstantiate, instantiate)
        { }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected sealed override void ReturnPreprocess(GameObject instance)
        {
            if (instance.activeSelf)
                instance.SetActive(false);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected sealed override UniTaskFunc<GameObject> GetDefaultInstantiator()
            => Instantiator;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static UniTask<GameObject> Instantiator()
        {
            var go = new GameObject();
            return UniTask.FromResult(go);
        }
    }
}
