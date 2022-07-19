using UnityEngine;
using UnityEngine.AddressableAssets;
using Cysharp.Threading.Tasks;

namespace Unity.Pooling.Components.Addressables
{
    public abstract class AssetRefInstantiator<T, TAssetRef, TPrefab>
        where T : UnityEngine.Object
        where TAssetRef : AssetReferenceT<T>
        where TPrefab : IPrefab<TAssetRef>
    {
        public abstract UniTask<T> InstantiateAsync(TPrefab prefab, Transform defaultParent);
    }
}