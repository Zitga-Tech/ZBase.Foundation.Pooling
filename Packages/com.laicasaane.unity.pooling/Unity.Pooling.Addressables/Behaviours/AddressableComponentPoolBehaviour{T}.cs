using UnityEngine;

namespace Unity.Pooling.AddressableAssets
{
    public class AddressableComponentPoolBehaviour<T>
        : AssetNameComponentPoolBehaviour<T
            , AssetNameComponentPrefab<T, AddressableComponentInstantiator<T>>
            , AddressableComponentInstantiator<T>
            , AddressableComponentPool<T>
        >
        where T : Component
    {
    }
}