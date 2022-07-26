using UnityEngine;

namespace Unity.Pooling.AddressableAssets
{
    public class AddressableComponentPrefab<T>
        : AssetNameComponentPrefab<T, AddressableComponentInstantiator<T>>
        where T : Component
    {
    }
}
