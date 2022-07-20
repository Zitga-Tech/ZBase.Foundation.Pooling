using System;

namespace Unity.Pooling.Components.AddressableAssets
{
    [Serializable]
    public abstract class AddressablePrefab<TKey, T> : Prefab<TKey, T>, IAddressablePrefab<TKey, T>
        where T : class
    {
    }
}
