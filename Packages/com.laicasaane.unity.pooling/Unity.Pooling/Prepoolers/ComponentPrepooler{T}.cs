using System;
using System.Pooling;

namespace Unity.Pooling
{
    [Serializable]
    public class ComponentPrepooler<T, TPool>
        : ComponentPrepoolerBase<T, T, ComponentInstantiator<T>, ComponentPrefab<T, ComponentInstantiator<T>>, TPool>
        where T : UnityEngine.Component
        where TPool : IReturnable<T>
    {
    }
}