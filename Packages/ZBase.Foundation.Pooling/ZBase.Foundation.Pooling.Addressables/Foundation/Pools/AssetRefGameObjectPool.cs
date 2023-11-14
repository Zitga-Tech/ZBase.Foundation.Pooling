using System;
using UnityEngine;
using ZBase.Foundation.Pooling.UnityPools;

namespace ZBase.Foundation.Pooling.AddressableAssets
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
