using UnityEngine;

namespace Unity.Pooling.AddressableAssets
{
    public class AssetNameComponentPoolBehaviour<T, TPrefab, TInstantiator, TPool>
        : UnityPoolBehaviour<
            T
            , TPrefab
            , TPool
            , UnityPrepooler<T, TPrefab, TPool>
        >
        where T : Component
        where TInstantiator : AssetNameInstantiator<T>, new()
        where TPrefab : AssetNameComponentPrefab<T, TInstantiator>
        where TPool : AssetNameComponentPool<T, TPrefab, TInstantiator>
    {
    }
}
