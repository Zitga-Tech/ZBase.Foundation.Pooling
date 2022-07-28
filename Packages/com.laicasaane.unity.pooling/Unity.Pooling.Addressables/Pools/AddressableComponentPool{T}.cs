using System;

namespace Unity.Pooling.AddressableAssets
{
    [Serializable]
    public class AddressableComponentPool<T>
        : AssetNameComponentPool<T
            , AssetNameComponentPrefab<T, AddressableComponentInstantiator<T>>
            , AddressableComponentInstantiator<T>
        >
        where T : UnityEngine.Component
    {
    }
}