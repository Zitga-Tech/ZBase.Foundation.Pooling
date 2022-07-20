using System;

namespace Unity.Pooling
{
    [Serializable]
    public class ComponentPrefab<TKey, T, TSource> : UnityObjectPrefab<TKey, T, TSource>
        where T : UnityEngine.Component
        where TSource : ComponentSource<T>
    {
    }
}