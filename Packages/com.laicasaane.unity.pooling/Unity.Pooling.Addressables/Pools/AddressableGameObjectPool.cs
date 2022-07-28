using System;
using System.Pooling;
using UnityEngine;

namespace Unity.Pooling.AddressableAssets
{
    [Serializable]
    public class AddressableGameObjectPool
        : AssetNameGameObjectPool<
            AssetNameGameObjectPrefab<AddressableGameObjectInstantiator>
            , AddressableGameObjectInstantiator
        >
    {
        public AddressableGameObjectPool()
            : base()
        { }

        public AddressableGameObjectPool(AssetNameGameObjectPrefab<AddressableGameObjectInstantiator> prefab)
            : base(prefab)
        { }

        public AddressableGameObjectPool(UniqueQueue<int, GameObject> queue, AssetNameGameObjectPrefab<AddressableGameObjectInstantiator> prefab)
            : base(queue, prefab)
        { }
    }
}