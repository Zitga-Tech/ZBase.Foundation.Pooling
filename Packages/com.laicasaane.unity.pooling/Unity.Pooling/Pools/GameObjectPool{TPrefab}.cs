using System;
using System.Pooling;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Unity.Pooling
{
    [Serializable]
    public class GameObjectPool<TPrefab>
        : UnityPool<GameObject, TPrefab>
        where TPrefab : IPrefab<GameObject>
    {
        public GameObjectPool()
            : base(null, default)
        { }

        public GameObjectPool(TPrefab prefab)
            : base(null, prefab)
        { }

        public GameObjectPool(UniqueQueue<int, GameObject> queue, TPrefab prefab)
            : base(queue, prefab)
        { }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override void ReturnPreprocess(GameObject instance)
        {
            if (instance && instance.activeSelf)
                instance.SetActive(false);
        }
    }
}
