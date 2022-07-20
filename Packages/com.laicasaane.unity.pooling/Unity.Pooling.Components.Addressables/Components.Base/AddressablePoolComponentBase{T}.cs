using System;
using System.Pooling;

namespace Unity.Pooling.Components.AddressableAssets
{
    public abstract class AddressablePoolComponentBase<T, TPrefab, TPool>
        : AsyncPoolComponentBase<T, TPrefab, TPool>
        where T : UnityEngine.Object
        where TPrefab : IAddressablePrefab<T>
        where TPool : IAsyncUnityPool<T>, IAsyncInstantiatorSetable<T>, IDisposable, new()
    {
    }
}
