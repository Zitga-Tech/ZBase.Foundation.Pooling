using System;
using System.Pooling;
using UnityEngine;

namespace Unity.Pooling.AddressableAssets
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

        public AddressGameObjectPool(UniqueQueue<int, GameObject> queue, AddressGameObjectPrefab prefab)
            : base(queue, prefab)
        { }
    }
}
