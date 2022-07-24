using System;
using System.Pooling;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Unity.Pooling
{
    [Serializable]
    public abstract class GameObjectPoolBase<TSource, TPrefab>
        : UnityPool<GameObject, TSource, TPrefab>
        where TPrefab : IPrefab<GameObject, TSource>
    {
        public GameObjectPoolBase()
            : base(null, default)
        { }

        public GameObjectPoolBase(TPrefab prefab)
            : base(null, prefab)
        { }

        public GameObjectPoolBase(UniqueQueue<int, GameObject> queue, TPrefab prefab)
            : base(queue, prefab)
        { }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected sealed override void ReturnPreprocess(GameObject instance)
        {
            if (instance.activeSelf)
                instance.SetActive(false);
        }
    }
}
