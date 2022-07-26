using UnityEngine;

namespace Unity.Pooling.AddressableAssets
{
    public class AddressableComponentPoolBehaviour<T>
        : AssetNameComponentPoolBehaviour<T
            , AddressableComponentInstantiator<T>
            , AddressableComponentPrefab<T>
            , AddressableComponentPool<T>
        >
        where T : Component
    {
    }
}
