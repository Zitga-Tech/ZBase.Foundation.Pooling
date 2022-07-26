using System;

namespace Unity.Pooling.AddressableAssets
{
    [Serializable]
    public class AddressableGameObjectPool
        : AssetNameGameObjectPool<AddressableGameObjectInstantiator, AddressableGameObjectPrefab>
    {
    }
}
