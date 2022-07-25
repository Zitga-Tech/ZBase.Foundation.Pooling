using UnityEngine;

namespace Unity.Pooling.AddressableAssets
{
    public class AssetNameComponentPrefab<T, TInstantiator>
        : AssetNamePrefab<T, TInstantiator>
        where T : Component
        where TInstantiator : IAssetNameInstantiator<T>, new()
    {
    }
}
