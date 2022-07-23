using System;
using System.Pooling;

namespace Unity.Pooling
{
    [Serializable]
    public class ComponentPrepooler<TKey, T, TPool>
        : ComponentPrepoolerBase<TKey, T, T, ComponentInstantiator<T>, ComponentPrefab<TKey, T, ComponentInstantiator<T>>, TPool>
        where T : UnityEngine.Component
        where TPool : IReturnable<TKey, T>
    {
    }
}