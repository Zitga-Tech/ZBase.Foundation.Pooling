using System;
using System.Pooling;
using UnityEngine;

namespace Unity.Pooling.AddressableAssets
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
