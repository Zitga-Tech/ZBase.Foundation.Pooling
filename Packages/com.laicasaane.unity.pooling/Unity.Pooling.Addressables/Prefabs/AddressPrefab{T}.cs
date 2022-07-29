using System;

namespace Unity.Pooling.AddressableAssets
{
    [Serializable]
    public abstract class AddressPrefab<T>
        : UnityPrefab<T, string>
        where T : UnityEngine.Object
    {
    }
}
