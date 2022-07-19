using System;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Cysharp.Threading.Tasks;

namespace Unity.Pooling.Components.Addressables
{
    public class AssetRefGameObjectInstantiator<TPrefab>
        : AssetRefInstantiator<GameObject, AssetReferenceGameObject, TPrefab>
        where TPrefab : IPrefab<AssetReferenceGameObject>
    {
        public override async UniTask<GameObject> InstantiateAsync(TPrefab prefab, Transform defaultParent)
        {
            if (prefab == null)
                throw new ArgumentNullException(nameof(prefab));

            if (prefab.Validate() == false)
                throw new InvalidOperationException(nameof(prefab));

            var parent = prefab.Parent ? prefab.Parent : defaultParent;
            var instance = await prefab.Source.InstantiateAsync(parent, true);
            return instance;
        }
    }
}
