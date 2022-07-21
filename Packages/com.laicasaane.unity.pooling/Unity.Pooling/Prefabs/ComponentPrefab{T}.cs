using System;

namespace Unity.Pooling
{
    [Serializable]
    public class ComponentPrefab<T, TSource>
        : UnityPrefab<T, T, TSource>
        where T : UnityEngine.Component
        where TSource : UnitySource<T, T>
    {
    }
}