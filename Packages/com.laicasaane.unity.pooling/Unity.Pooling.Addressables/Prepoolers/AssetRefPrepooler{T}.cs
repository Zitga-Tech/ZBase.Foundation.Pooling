using System;

namespace Unity.Pooling.AddressableAssets
{
    [Serializable]
    public class AssetRefPrepooler<T, TAssetRef, TPrefab, TPool>
        : UnityPrepooler<T, TAssetRef, TPrefab, TPool>
        where T : UnityEngine.Object
        where TPrefab : UnityPrefab<T, TAssetRef>
        where TPool : UnityPool<T, TAssetRef, TPrefab>
    {
    }
}
