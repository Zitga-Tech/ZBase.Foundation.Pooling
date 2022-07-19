using System;
using UnityEngine.AddressableAssets;

namespace Unity.Pooling.Components.Addressables
{
    [Serializable]
    public abstract class AssetRefPrefab<TKey, T, TAssetRef> : Prefab<TKey, TAssetRef>
        where T : UnityEngine.Object
        where TAssetRef : AssetReferenceT<T>
    {
    }
}
