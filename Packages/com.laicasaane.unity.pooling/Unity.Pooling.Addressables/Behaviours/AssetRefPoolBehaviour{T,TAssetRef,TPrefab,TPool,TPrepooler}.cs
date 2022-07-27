using UnityEngine.AddressableAssets;

namespace Unity.Pooling.AddressableAssets
{
    public class AssetRefPoolBehaviour<T, TAssetRef, TPrefab, TPool, TPrepooler>
        : UnityPoolBehaviour<T, TAssetRef, TPrefab, TPool, TPrepooler>
        where T : UnityEngine.Object
        where TAssetRef : AssetReference
        where TPrefab : AssetRefPrefab<T, TAssetRef>
        where TPool : AssetRefPool<T, TAssetRef, TPrefab>
        where TPrepooler : AssetRefPrepooler<T, TAssetRef, TPrefab, TPool>, new()
    {
    }
}
