using System;
using UnityEngine.AddressableAssets;

namespace Unity.Pooling.AddressableAssets
{
    [Serializable]
    public abstract class AssetRefPrefab<T, TAssetRef>
        : UnityPrefab<T, TAssetRef>
        where T : UnityEngine.Object
        where TAssetRef : AssetReferenceT<T>
    {
    }
}
