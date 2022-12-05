using UnityEngine;

namespace ZBase.Foundation.Pooling.AddressableAssets
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