using System;
using UnityEngine;

namespace ZBase.Foundation.Pooling.AddressableAssets
{
    [Serializable]
    public class AddressGameObjectPool
        : AddressGameObjectPool<AddressGameObjectPrefab>
    {
        public AddressGameObjectPool()
            : base()
        { }

        public AddressGameObjectPool(AddressGameObjectPrefab prefab)
            : base(prefab)
        { }

        public AddressGameObjectPool(UniqueQueue<int, GameObject> queue)
            : base(queue)
        { }

        public AddressGameObjectPool(UniqueQueue<int, GameObject> queue, AddressGameObjectPrefab prefab)
            : base(queue, prefab)
        { }
    }
}
