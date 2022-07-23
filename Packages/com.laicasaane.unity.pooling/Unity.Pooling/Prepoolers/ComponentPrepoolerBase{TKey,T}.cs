using System;
using System.Pooling;

namespace Unity.Pooling
{
    [Serializable]
    public abstract class ComponentPrepoolerBase<TKey, T, TSource, TInstantiator, TPrefab, TPool>
        : UnityPrepooler<TKey, T, TSource, TInstantiator, TPrefab, TPool>
        where T : UnityEngine.Component
        where TInstantiator : IAsyncInstantiator<TSource, T>
        where TPrefab : IPrefab<TKey, T, TSource, TInstantiator>
        where TPool : IReturnable<TKey, T>
    {
    }
}