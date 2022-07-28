using System;
using System.Pooling;
using UnityEngine;

namespace Unity.Pooling.AddressableAssets
{
    [Serializable]
    public class AssetNameGameObjectPool
        : AssetNameGameObjectPool<AssetNameGameObjectPrefab>
    {
        public AssetNameGameObjectPool()
            : base()
        { }

        public AssetNameGameObjectPool(AssetNameGameObjectPrefab prefab)
            : base(prefab)
        { }

        public AssetNameGameObjectPool(UniqueQueue<int, GameObject> queue, AssetNameGameObjectPrefab prefab)
            : base(queue, prefab)
        { }
    }
}
