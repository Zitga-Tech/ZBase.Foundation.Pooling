using System;
using System.Pooling;
using UnityEngine;

namespace Unity.Pooling.AddressableAssets
{
    [Serializable]
    public class AddressComponentPool<T>
        : AddressComponentPool<T, AddressComponentPrefab<T>>
        where T : Component
    {
        public AddressComponentPool()
            : base()
        { }

        public AddressComponentPool(AddressComponentPrefab<T> prefab)
            : base(prefab)
        { }

        public AddressComponentPool(UniqueQueue<int, T> queue, AddressComponentPrefab<T> prefab)
            : base(queue, prefab)
        { }
    }
}
