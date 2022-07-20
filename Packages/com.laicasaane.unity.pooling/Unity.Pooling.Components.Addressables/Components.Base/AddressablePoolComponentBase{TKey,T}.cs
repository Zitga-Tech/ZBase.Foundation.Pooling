using System;
using System.Pooling;

namespace Unity.Pooling.Components.AddressableAssets
{
    public abstract class AddressablePoolComponentBase<TKey, T, TPrefab, TPool>
        : AsyncPoolComponentBase<TKey, T, TPrefab, TPool>
        where T : UnityEngine.Object
        where TPrefab : IAddressablePrefab<TKey, T>
        where TPool : IAsyncUnityPool<TKey, T>, IAsyncInstantiatorSetable<T>, IDisposable, new()
    {
    }
}
