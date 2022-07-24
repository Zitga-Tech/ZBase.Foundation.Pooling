using System;
using System.Pooling;

namespace Unity.Pooling
{
    [Serializable]
    public abstract class ComponentPrepoolerBase<T, TSource, TPrefab, TPool>
        : UnityPrepooler<T, TSource, TPrefab, TPool>
        where T : UnityEngine.Component
        where TPrefab : IPrefab<T, TSource>
        where TPool : IReturnable<T>
    {
    }
}