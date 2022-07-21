using System;
using System.Pooling;
using System.Runtime.CompilerServices;
using Collections.Pooled.Generic;
using UnityEngine;

namespace Unity.Pooling
{
    public abstract class GameObjectPoolBase<TKey, S, TSource, TPrefab>
        : UnityPool<TKey, GameObject, S, TSource, TPrefab>
        where TSource : IAsyncInstantiatableSource<S, GameObject>
        where TPrefab : IPrefab<TKey, GameObject, S, TSource>
    {
        public GameObjectPoolBase()
            : base(null, null, default, null)
        { }

        public GameObjectPoolBase(TPrefab prefab, Transform defaultParent = null)
            : base(null, null, prefab, defaultParent)
        { }

        public GameObjectPoolBase(Dictionary<TKey, UniqueQueue<int, GameObject>> queueMap
            , Func<UniqueQueue<int, GameObject>> queueInstantiate
            , TPrefab prefab
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
