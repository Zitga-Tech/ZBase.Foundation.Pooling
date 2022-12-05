using System;
using ZBase.Foundation.Pooling;
using ZBase.Foundation.Pooling.UnityPools;
using UnityEngine;

namespace ZBase.Foundation.Pooling.AddressableAssets
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
