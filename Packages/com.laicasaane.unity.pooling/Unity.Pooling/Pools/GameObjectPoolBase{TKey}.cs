using System;
using System.Pooling;
using System.Runtime.CompilerServices;
using Collections.Pooled.Generic;
using UnityEngine;

namespace Unity.Pooling
{
    [Serializable]
    public abstract class GameObjectPoolBase<TKey, TSource, TInstantiator, TPrefab>
        : UnityPool<TKey, GameObject, TSource, TInstantiator, TPrefab>
        where TInstantiator : IAsyncInstantiator<TSource, GameObject>
        where TPrefab : IPrefab<TKey, GameObject, TSource, TInstantiator>
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
