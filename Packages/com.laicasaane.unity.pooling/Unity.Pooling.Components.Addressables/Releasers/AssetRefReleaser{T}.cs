using UnityEngine.AddressableAssets;

namespace Unity.Pooling.Components.AddressableAssets
{
    public abstract class AssetRefReleaser<T, TAssetRef, TPrefab>
        where T : UnityEngine.Object
        where TAssetRef : AssetReferenceT<T>
        where TPrefab : IPrefab<TAssetRef>
    {
        public abstract void Release(TPrefab prefab, T instance);
    }
}