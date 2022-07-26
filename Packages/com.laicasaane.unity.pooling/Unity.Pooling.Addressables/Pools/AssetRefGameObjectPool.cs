using System;
using System.Pooling;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Unity.Pooling.AddressableAssets
{
    [Serializable]
    public class AssetRefGameObjectPool
        : UnityPool<GameObject, AssetReferenceGameObject, AssetRefGameObjectPrefab>
    {
        public AssetRefGameObjectPool()
            : base(null, default)
        { }

        public AssetRefGameObjectPool(AssetRefGameObjectPrefab prefab)
            : base(null, prefab)
        { }

        public AssetRefGameObjectPool(UniqueQueue<int, GameObject> queue, AssetRefGameObjectPrefab prefab)
            : base(queue, prefab)
        { }

        protected override void ReturnPreprocess(GameObject instance)
        {
            if (instance && instance.activeSelf)
                instance.SetActive(false);
        }
    }
}
