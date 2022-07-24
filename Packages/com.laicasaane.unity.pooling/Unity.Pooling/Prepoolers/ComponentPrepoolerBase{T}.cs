using System;
using System.Pooling;

namespace Unity.Pooling
{
    [Serializable]
    public abstract class ComponentPrepoolerBase<T, TSource, TInstantiator, TPrefab, TPool>
        : UnityPrepooler<T, TSource, TInstantiator, TPrefab, TPool>
        where T : UnityEngine.Component
        where TInstantiator : IAsyncInstantiator<TSource, T>
        where TPrefab : IPrefab<T, TSource, TInstantiator>
        where TPool : IReturnable<T>
    {
    }
}