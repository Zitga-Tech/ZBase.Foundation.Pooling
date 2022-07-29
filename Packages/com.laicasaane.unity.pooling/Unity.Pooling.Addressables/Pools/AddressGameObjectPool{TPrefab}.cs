using System;
using System.Pooling;
using UnityEngine;

namespace Unity.Pooling.AddressableAssets
{
    [Serializable]
    public class AddressGameObjectPool<TPrefab>
        : GameObjectPool<TPrefab>
        where TPrefab : AddressGameObjectPrefab
    {
        public AddressGameObjectPool()
            : base()
        { }

        public AddressGameObjectPool(TPrefab prefab)
            : base(prefab)
        { }

        public AddressGameObjectPool(UniqueQueue<int, GameObject> queue, TPrefab prefab)
            : base(queue, prefab)
        { }
    }
}
