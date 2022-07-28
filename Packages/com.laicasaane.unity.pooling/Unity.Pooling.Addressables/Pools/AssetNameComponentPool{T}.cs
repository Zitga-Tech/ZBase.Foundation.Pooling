using System;
using System.Pooling;
using UnityEngine;

namespace Unity.Pooling.AddressableAssets
{
    [Serializable]
    public class AssetNameComponentPool<T>
        : AssetNameComponentPool<T, AssetNameComponentPrefab<T>>
        where T : Component
    {
        public AssetNameComponentPool()
            : base()
        { }

        public AssetNameComponentPool(AssetNameComponentPrefab<T> prefab)
            : base(prefab)
        { }

        public AssetNameComponentPool(UniqueQueue<int, T> queue, AssetNameComponentPrefab<T> prefab)
            : base(queue, prefab)
        { }
    }
}
