using System;

namespace Unity.Pooling.Components
{
    [Serializable]
    public sealed class ComponentPrefab<TKey, T> : UnityPrefab<TKey, T>
        where T : UnityEngine.Component
    {
    }
}