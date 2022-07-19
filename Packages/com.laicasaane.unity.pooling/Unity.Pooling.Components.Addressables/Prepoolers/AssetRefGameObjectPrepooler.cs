using System.Pooling;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Unity.Pooling.Components.Addressables
{
    public class AssetRefGameObjectPrepooler<TPrefab, TPool>
        : AssetRefPrepooler<GameObject, AssetReferenceGameObject, TPrefab, TPool>
        where TPrefab : IPrefab<AssetReferenceGameObject>
        where TPool : IReturnable<GameObject>
    {
        public override async UniTask<GameObject> InstantiateAsync(AssetReferenceGameObject assetRef, Transform parent)
            => await assetRef.InstantiateAsync(parent, true);
    }
}