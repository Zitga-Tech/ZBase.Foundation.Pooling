using System;
using UnityEngine.AddressableAssets;

namespace Unity.Pooling.AddressableAssets
{
    [Serializable]
    public class AssetRefPrepooler<T, TAssetRef, TPrefab, TPool>
        : UnityPrepooler<T, TAssetRef, TPrefab, TPool>
        where T : UnityEngine.Object
        where TAssetRef : AssetReference
        where TPrefab : UnityPrefab<T, TAssetRef>
        where TPool : UnityPool<T, TAssetRef, TPrefab>
    {
    }
}
