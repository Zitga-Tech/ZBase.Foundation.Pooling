using System;
using System.Pooling;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Unity.Pooling.AddressableAssets
{
    [Serializable]
    public class AssetRefComponentPool<T>
        : AssetRefPool<T, AssetReferenceT<T>, AssetRefComponentPrefab<T>>
        where T : Component
    {
        public AssetRefComponentPool()
            : base(null, default)
        { }

        public AssetRefComponentPool(AssetRefComponentPrefab<T> prefab)
            : base(null, prefab)
        { }

        public AssetRefComponentPool(UniqueQueue<int, T> queue, AssetRefComponentPrefab<T> prefab)
            : base(queue, prefab)
        { }

        protected override void ReturnPreprocess(T instance)
        {
            if (instance && instance.gameObject && instance.gameObject.activeSelf)
                instance.gameObject.SetActive(false);
        }
    }
}
