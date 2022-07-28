using UnityEngine;

namespace Unity.Pooling.AddressableAssets
{
    public class AssetNameComponentPoolBehaviour<T, TPrefab, TPool>
        : UnityPoolBehaviour<T, TPrefab, TPool>
        where T : Component
        where TPrefab : AssetNameComponentPrefab<T>
        where TPool : AssetNameComponentPool<T, TPrefab>
    {
    }
}
