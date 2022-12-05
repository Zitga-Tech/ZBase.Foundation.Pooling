using System;
using ZBase.Foundation.Pooling.UnityPools;

namespace ZBase.Foundation.Pooling.AddressableAssets
{
    [Serializable]
    public abstract class AddressPrefab<T>
        : UnityPrefab<T, string>
        where T : UnityEngine.Object
    {
    }
}
