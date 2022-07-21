using System;
using System.Pooling;
using System.Runtime.CompilerServices;
using Collections.Pooled.Generic;
using UnityEngine;

namespace Unity.Pooling
{
    public class GameObjectPool<TKey>
        : UnityPool<TKey, GameObject, GameObject, GameObjectSource, GameObjectPrefab<TKey>>
    {
        public GameObjectPool()
            : base(null, null, default, null)
        { }

        public GameObjectPool(GameObjectPrefab<TKey> prefab, Transform defaultParent = null)
            : base(null, null, prefab, defaultParent)
        { }

        public GameObjectPool(Dictionary<TKey, UniqueQueue<int, GameObject>> queueMap
            , Func<UniqueQueue<int, GameObject>> queueInstantiate
            , GameObjectPrefab<TKey> prefab
            , Transform defaultParent = null
        )
            : base(queueMap, queueInstantiate, prefab, defaultParent)
        { }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected sealed override void ReturnPreprocess(GameObject instance)
        {
            if (instance.activeSelf)
                instance.SetActive(false);
        }
    }
}
