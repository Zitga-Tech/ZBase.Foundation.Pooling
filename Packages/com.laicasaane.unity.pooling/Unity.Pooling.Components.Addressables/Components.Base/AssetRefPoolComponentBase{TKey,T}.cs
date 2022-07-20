using System;
using System.Pooling;
using UnityEngine.AddressableAssets;

namespace Unity.Pooling.Components.AddressableAssets
{
    public abstract class AssetRefPoolComponentBase<TKey, T, TAssetRef, TPrefab, TPool>
        : AsyncPoolComponentBase<TKey, T, TPrefab, TPool>
        where T : UnityEngine.Object
        where TAssetRef : AssetReferenceT<T>
        where TPrefab : IPrefab<TKey, TAssetRef>
        where TPool : IAsyncUnityPool<TKey, T>, IAsyncInstantiatorSetable<T>, IDisposable, new()
    {
    }
}
