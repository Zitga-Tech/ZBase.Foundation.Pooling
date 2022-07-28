using UnityEngine;

namespace Unity.Pooling.AddressableAssets
{
    public class AssetNameGameObjectPoolBehaviour<TPrefab, TInstantiator, TPool>
        : UnityPoolBehaviour<
            GameObject
            , TPrefab
            , TPool
            , UnityPrepooler<GameObject, TPrefab, TPool>
        >
        where TInstantiator : AssetNameInstantiator<GameObject>, new()
        where TPrefab : AssetNameGameObjectPrefab<TInstantiator>
        where TPool : AssetNameGameObjectPool<TPrefab, TInstantiator>
    {
    }
}
