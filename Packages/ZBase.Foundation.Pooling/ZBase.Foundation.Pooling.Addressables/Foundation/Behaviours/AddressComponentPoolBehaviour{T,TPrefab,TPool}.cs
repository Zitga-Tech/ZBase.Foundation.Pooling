using UnityEngine;
using ZBase.Foundation.Pooling.UnityPools;

namespace ZBase.Foundation.Pooling.AddressableAssets
{
    public class AddressComponentPoolBehaviour<T, TPrefab, TPool>
        : UnityPoolBehaviour<T, TPrefab, TPool>
        where T : Component
        where TPrefab : AddressComponentPrefab<T>
        where TPool : AddressComponentPool<T, TPrefab>
    {
    }
}
