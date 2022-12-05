using System;
using UnityEngine.AddressableAssets;
using ZBase.Foundation.Pooling.UnityPools;

namespace ZBase.Foundation.Pooling.AddressableAssets
{
    [Serializable]
    public abstract class AssetRefPrefab<T, TAssetRef>
        : UnityPrefab<T, TAssetRef>
        where T : UnityEngine.Object
        where TAssetRef : AssetReference
    {
    }
}
