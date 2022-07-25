using UnityEngine;

namespace Unity.Pooling.AddressableAssets
{
    public class AssetNameGameObjectPrefab<TInstantiator>
        : AssetNamePrefab<GameObject, TInstantiator>
        where TInstantiator : IAssetNameInstantiator<GameObject>, new()
    {
    }
}
