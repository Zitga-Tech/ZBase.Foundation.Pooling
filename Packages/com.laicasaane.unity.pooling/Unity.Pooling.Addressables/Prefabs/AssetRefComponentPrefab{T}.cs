using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Unity.Pooling.AddressableAssets
{
    [Serializable]
    public class AssetRefComponentPrefab<T> : AssetRefPrefab<T, AssetReferenceT<T>>
        where T : Component
    {
        protected override async UniTask<T> InstantiateAsync(AssetReferenceT<T> source, Transform parent)
        {
            T instance;
            GameObject gameObject;

            if (parent)
                gameObject = await source.InstantiateAsync(parent, true);
            else
                gameObject = await source.InstantiateAsync();

            instance = gameObject.GetComponent<T>();
            return instance;
        }
    }
}
