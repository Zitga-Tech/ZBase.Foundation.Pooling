using System;
using UnityEngine;
using ZBase.Foundation.Pooling;
using ZBase.Foundation.Pooling.UnityPools;

namespace ZBase.Foundation.Pooling.AddressableAssets
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

        public AddressGameObjectPool(UniqueQueue<int, GameObject> queue)
            : base(queue)
        { }

        public AddressGameObjectPool(UniqueQueue<int, GameObject> queue, TPrefab prefab)
            : base(queue, prefab)
        { }
    }
}
