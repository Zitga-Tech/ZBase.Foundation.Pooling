using System;
using System.Pooling;

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
        public AddressableComponentPool()
            : base()
        { }

        public AddressableComponentPool(AssetNameComponentPrefab<T, AddressableComponentInstantiator<T>> prefab)
            : base(prefab)
        { }

        public AddressableComponentPool(UniqueQueue<int, T> queue, AssetNameComponentPrefab<T, AddressableComponentInstantiator<T>> prefab)
            : base(queue, prefab)
        { }
    }
}