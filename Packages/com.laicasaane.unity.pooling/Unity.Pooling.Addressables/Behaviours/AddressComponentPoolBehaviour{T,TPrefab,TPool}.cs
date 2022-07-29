using UnityEngine;

namespace Unity.Pooling.AddressableAssets
{
    public class AddressComponentPoolBehaviour<T, TPrefab, TPool>
        : UnityPoolBehaviour<T, TPrefab, TPool>
        where T : Component
        where TPrefab : AddressComponentPrefab<T>
        where TPool : AddressComponentPool<T, TPrefab>
    {
    }
}
