using System;

namespace Unity.Pooling
{
    [Serializable]
    public class ComponentPrefab<TKey, T, TInstantiator>
        : UnityPrefab<TKey, T, T, TInstantiator>
        where T : UnityEngine.Component
        where TInstantiator : ComponentInstantiator<T>
    {
    }
}