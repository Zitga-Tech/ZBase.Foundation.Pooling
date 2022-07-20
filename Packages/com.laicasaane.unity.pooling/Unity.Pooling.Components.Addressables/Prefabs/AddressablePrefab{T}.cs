using System;

namespace Unity.Pooling.Components.AddressableAssets
{
    [Serializable]
    public abstract class AddressablePrefab<T> : Prefab<T>, IAddressablePrefab<T>
        where T : class
    {
    }
}
