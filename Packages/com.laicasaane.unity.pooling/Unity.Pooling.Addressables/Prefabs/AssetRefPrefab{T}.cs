using UnityEngine.AddressableAssets;

namespace Unity.Pooling.AddressableAssets
{
    public abstract class AssetRefPrefab<T, TAssetRef>
        : UnityPrefab<T, TAssetRef>
        where T : UnityEngine.Object
        where TAssetRef : AssetReferenceT<T>
    {
    }
}
