using System;
using UnityEngine;

namespace Unity.Pooling.AddressableAssets
{
    [Serializable]
    public class AssetNameGameObjectPool<TPrefab, TInstantiator>
        : GameObjectPool<TPrefab>
        where TPrefab : AssetNameGameObjectPrefab<TInstantiator>
        where TInstantiator : IAssetNameInstantiator<GameObject>, new()
    {
    }
}
