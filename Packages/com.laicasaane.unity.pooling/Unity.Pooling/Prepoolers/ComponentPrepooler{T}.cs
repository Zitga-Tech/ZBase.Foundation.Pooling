using System;
using System.Pooling;

namespace Unity.Pooling
{
    [Serializable]
    public class ComponentPrepooler<T, TPool>
        : ComponentPrepoolerBase<T, T, ComponentPrefab<T>, TPool>
        where T : UnityEngine.Component
        where TPool : IReturnable<T>
    {
    }
}