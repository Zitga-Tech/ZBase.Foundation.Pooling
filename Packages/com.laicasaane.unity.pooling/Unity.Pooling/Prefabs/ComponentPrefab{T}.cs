using System;

namespace Unity.Pooling
{
    [Serializable]
    public class ComponentPrefab<T, TSource> : UnityObjectPrefab<T, TSource>
        where T : UnityEngine.Component
        where TSource : UnityObjectSource<T>
    {
    }
}