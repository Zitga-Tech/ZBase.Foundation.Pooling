using UnityEngine;

namespace Unity.Pooling.AddressableAssets
{
    public class AddressComponentPoolBehaviour<T>
        : AddressComponentPoolBehaviour<T
            , AddressComponentPrefab<T>
            , AddressComponentPool<T>
        >
        where T : Component
    {
    }
}