using System.Pooling;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Unity.Pooling.Components.Addressables
{
    public class AssetRefGameObjectPrepooler<TKey, TPrefab, TPool>
        : AssetRefPrepooler<TKey, GameObject, AssetReferenceGameObject, TPrefab, TPool>
        where TPrefab : IPrefab<TKey, AssetReferenceGameObject>
        where TPool : IReturnable<TKey, GameObject>
    {
        public override async UniTask<GameObject> InstantiateAsync(AssetReferenceGameObject assetRef, Transform parent)
            => await assetRef.InstantiateAsync(parent, true);
    }
}