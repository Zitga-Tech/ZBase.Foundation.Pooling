using System;
using System.Pooling;
using UnityEngine.AddressableAssets;

namespace Unity.Pooling.Components.AddressableAssets
{
    public abstract class AssetRefPoolComponentBase<T, TAssetRef, TPrefab, TPool>
        : AsyncPoolComponentBase<T, TPrefab, TPool>
        where T : UnityEngine.Object
        where TAssetRef : AssetReferenceT<T>
        where TPrefab : IPrefab<TAssetRef>
        where TPool : IAsyncUnityPool<T>, IAsyncInstantiatorSetable<T>, IDisposable, new()
    {
    }
}
