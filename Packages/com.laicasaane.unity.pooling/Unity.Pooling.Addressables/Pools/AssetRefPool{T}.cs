using System;
using System.Pooling;
using UnityEngine.AddressableAssets;

namespace Unity.Pooling.AddressableAssets
{
    [Serializable]
    public abstract class AssetRefPool<T, TAssetRef, TPrefab>
        : UnityPool<T, TAssetRef, TPrefab>
        where T : UnityEngine.Object
        where TAssetRef : AssetReference
        where TPrefab : AssetRefPrefab<T, TAssetRef>
    {
        public AssetRefPool()
            : base(null, default)
        { }

        public AssetRefPool(TPrefab prefab)
            : base(null, prefab)
        { }

        public AssetRefPool(UniqueQueue<int, T> queue, TPrefab prefab)
            : base(queue, prefab)
        { }
    }
}
