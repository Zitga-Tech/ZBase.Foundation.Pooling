using System;
using UnityEngine;

namespace Unity.Pooling.AddressableAssets
{
    [Serializable]
    public class AssetNameComponentPrefab<T, TInstantiator>
        : AssetNamePrefab<T, TInstantiator>
        where T : Component
        where TInstantiator : IAssetNameInstantiator<T>, new()
    {
    }
}
