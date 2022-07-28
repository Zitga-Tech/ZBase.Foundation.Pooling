using System;
using UnityEngine;

namespace Unity.Pooling.AddressableAssets
{
    [Serializable]
    public class AssetNameComponentPool<T, TPrefab, TInstantiator>
        : ComponentPool<T, TPrefab>
        where T : Component
        where TPrefab : AssetNameComponentPrefab<T, TInstantiator>
        where TInstantiator : IAssetNameInstantiator<T>, new()
    {
    }
}
