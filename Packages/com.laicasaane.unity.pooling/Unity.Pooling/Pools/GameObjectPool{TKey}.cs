using System;
using System.Pooling;
using System.Runtime.CompilerServices;
using Collections.Pooled.Generic;
using UnityEngine;

namespace Unity.Pooling
{
    public class GameObjectPool<TKey> : UnityPoolBase<TKey, GameObject>
    {
        public GameObjectPool()
            : base(null, null, null)
        { }

        public GameObjectPool(Func<GameObject> instantiate)
            : base(null, null, instantiate)
        { }

        public GameObjectPool(Dictionary<TKey, UniqueQueue<int, GameObject>> queueMap
            , Func<UniqueQueue<int, GameObject>> queueInstantiate
        )
            : base(queueMap, queueInstantiate, null)
        { }

        public GameObjectPool(Dictionary<TKey, UniqueQueue<int, GameObject>> queueMap
            , Func<UniqueQueue<int, GameObject>> queueInstantiate
            , Func<GameObject> instantiate
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
        protected sealed override Func<GameObject> GetDefaultInstantiator()
            => Instantiator;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static GameObject Instantiator()
            => new GameObject();
    }
}
