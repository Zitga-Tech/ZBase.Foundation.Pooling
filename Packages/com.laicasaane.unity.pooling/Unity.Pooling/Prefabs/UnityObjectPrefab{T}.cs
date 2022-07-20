using System;

namespace Unity.Pooling
{
    [Serializable]
    public class UnityObjectPrefab<T, TSource> : Prefab<T, T, TSource>
        where T : UnityEngine.Object
        where TSource : UnityObjectSource<T>
    {
    }
}