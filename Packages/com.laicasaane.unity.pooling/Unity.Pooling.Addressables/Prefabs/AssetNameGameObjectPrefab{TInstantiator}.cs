using System;
using UnityEngine;

namespace Unity.Pooling.AddressableAssets
{
    [Serializable]
    public class AssetNameGameObjectPrefab<TInstantiator>
        : AssetNamePrefab<GameObject, TInstantiator>
        where TInstantiator : IAssetNameInstantiator<GameObject>, new()
    {
    }
}
