using UnityEngine;

namespace Unity.Pooling.AddressableAssets
{
    public class AssetNameGameObjectPoolBehaviour<TPrefab, TPool>
        : UnityPoolBehaviour<GameObject, TPrefab, TPool>
        where TPrefab : AssetNameGameObjectPrefab
        where TPool : AssetNameGameObjectPool<TPrefab>
    {
    }
}
