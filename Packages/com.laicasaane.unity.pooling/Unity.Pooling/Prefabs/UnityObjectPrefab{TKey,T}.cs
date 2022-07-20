using System;

namespace Unity.Pooling
{
    [Serializable]
    public class UnityObjectPrefab<TKey, T, TSource> : Prefab<TKey, T, T, TSource>
        where T : UnityEngine.Object
        where TSource : UnityObjectSource<T>
    {
    }
}