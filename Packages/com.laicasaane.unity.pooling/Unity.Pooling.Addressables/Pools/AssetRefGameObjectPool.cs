using System;
using System.Pooling;
using UnityEngine;

namespace Unity.Pooling.AddressableAssets
{
    [Serializable]
    public class AssetRefGameObjectPool
        : GameObjectPool<AssetRefGameObjectPrefab>
    {
        public AssetRefGameObjectPool()
            : base()
        { }

        public AssetRefGameObjectPool(AssetRefGameObjectPrefab prefab)
            : base(prefab)
        { }

        public AssetRefGameObjectPool(UniqueQueue<int, GameObject> queue)
            : base(queue)
        { }

        public AssetRefGameObjectPool(UniqueQueue<int, GameObject> queue, AssetRefGameObjectPrefab prefab)
            : base(queue, prefab)
        { }
    }
}
