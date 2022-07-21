using System;

namespace Unity.Pooling
{
    [Serializable]
    public class ComponentPrefab<TKey, T, TSource>
        : UnityPrefab<TKey, T, T, TSource>
        where T : UnityEngine.Component
        where TSource : ComponentSource<T>
    {
    }
}