using UnityEngine;

namespace Unity.Pooling.AddressableAssets
{
    public class AssetNameGameObjectPoolBehaviour<TInstantiator, TPrefab, TPool>
        : AssetNamePoolBehaviour<
            GameObject
            , TInstantiator
            , TPrefab
            , TPool
            , AssetNamePrepooler<GameObject, TInstantiator, TPrefab, TPool>
        >
        where TInstantiator : AssetNameInstantiator<GameObject>, new()
        where TPrefab : AssetNameGameObjectPrefab<TInstantiator>
        where TPool : AssetNameGameObjectPool<TInstantiator, TPrefab>
    {
    }
}
