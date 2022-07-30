using System;
using System.Pooling;
using UnityEngine;

namespace Unity.Pooling.AddressableAssets
{
    [Serializable]
    public class AddressComponentPool<T, TPrefab>
        : ComponentPool<T, TPrefab>
        where T : Component
        where TPrefab : AddressComponentPrefab<T>
    {
        public AddressComponentPool()
            : base()
        { }

        public AddressComponentPool(TPrefab prefab)
            : base(prefab)
        { }

        public AddressComponentPool(UniqueQueue<int, T> queue)
            : base(queue)
        { }

        public AddressComponentPool(UniqueQueue<int, T> queue, TPrefab prefab)
            : base(queue, prefab)
        { }
    }
}
