using System;

namespace Unity.Pooling.AddressableAssets
{
    [Serializable]
    public class AddressableComponentPool<T>
        : AssetNameComponentPool<T, AddressableComponentInstantiator<T>, AddressableComponentPrefab<T>>
        where T : UnityEngine.Component
    {
    }
}
