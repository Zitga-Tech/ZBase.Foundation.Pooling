using System;
using UnityEngine.AddressableAssets;

namespace Unity.Pooling.Components.AddressableAssets
{
    [Serializable]
    public abstract class AssetRefPrefab<T, TAssetRef> : AddressablePrefab<TAssetRef>
        where T : UnityEngine.Object
        where TAssetRef : AssetReferenceT<T>
    {
    }
}
