using System;
using UnityEngine;
using ZBase.Foundation.Pooling.UnityPools;

namespace ZBase.Foundation.Pooling.AddressableAssets
{
    [Serializable]
    public class AssetRefComponentPool<T>
        : ComponentPool<T, AssetRefComponentPrefab<T>>
        where T : Component
    {
        public AssetRefComponentPool()
            : base()
        { }

        public AssetRefComponentPool(AssetRefComponentPrefab<T> prefab)
            : base(prefab)
        { }

        public AssetRefComponentPool(UniqueQueue<int, T> queue)
            : base(queue)
        { }

        public AssetRefComponentPool(UniqueQueue<int, T> queue, AssetRefComponentPrefab<T> prefab)
            : base(queue, prefab)
        { }
    }
}
