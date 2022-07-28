using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Unity.Pooling.AddressableAssets
{
    [Serializable]
    public class AssetRefGameObjectPrefab
        : AssetRefPrefab<GameObject, AssetReferenceGameObject>
    {
        protected override async UniTask<GameObject> Instantiate(
            AssetReferenceGameObject source
            , Transform parent
        )
        {
            GameObject instance;

            if (parent)
                instance = await source.InstantiateAsync(parent, true);
            else
                instance = await source.InstantiateAsync();

            return instance;
        }
    }
}
