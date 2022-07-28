using System;
using System.Pooling;
using UnityEngine;

namespace Unity.Pooling.AddressableAssets
{
    [Serializable]
    public class AssetNameGameObjectPool<TPrefab, TInstantiator>
        : GameObjectPool<TPrefab>
        where TPrefab : AssetNameGameObjectPrefab<TInstantiator>
        where TInstantiator : IAssetNameInstantiator<GameObject>, new()
    {
        public AssetNameGameObjectPool()
            : base()
        { }

        public AssetNameGameObjectPool(TPrefab prefab)
            : base(prefab)
        { }

        public AssetNameGameObjectPool(UniqueQueue<int, GameObject> queue, TPrefab prefab)
            : base(queue, prefab)
        { }
    }
}
