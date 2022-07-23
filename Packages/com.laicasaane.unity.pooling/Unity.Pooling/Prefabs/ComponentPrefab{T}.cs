using System;

namespace Unity.Pooling
{
    [Serializable]
    public class ComponentPrefab<T, TInstantiator>
        : UnityPrefab<T, T, TInstantiator>
        where T : UnityEngine.Component
        where TInstantiator : UnityInstantiator<T, T>
    {
    }
}