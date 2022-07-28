using System;

namespace Unity.Pooling.AddressableAssets
{
    [Serializable]
    public class AssetNamePrepooler<T, TInstantiator, TPrefab, TPool>
        : UnityPrepooler<T, TPrefab, TPool>
        where T : UnityEngine.Object
        where TInstantiator : IAssetNameInstantiator<T>, new()
        where TPrefab : AssetNamePrefab<T, TInstantiator>
        where TPool : AssetNamePool<T, TInstantiator, TPrefab>
    {
    }
}
