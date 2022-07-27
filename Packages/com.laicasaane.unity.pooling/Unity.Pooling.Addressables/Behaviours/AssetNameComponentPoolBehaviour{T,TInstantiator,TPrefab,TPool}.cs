using UnityEngine;

namespace Unity.Pooling.AddressableAssets
{
    public class AssetNameComponentPoolBehaviour<T, TInstantiator, TPrefab, TPool>
        : AssetNamePoolBehaviour<T, TInstantiator, TPrefab, TPool
            , AssetNamePrepooler<T, TInstantiator, TPrefab, TPool>
        >
        where T : Component
        where TInstantiator : AssetNameInstantiator<T>, new()
        where TPrefab : AssetNameComponentPrefab<T, TInstantiator>
        where TPool : AssetNameComponentPool<T, TInstantiator, TPrefab>
    {
    }
}
