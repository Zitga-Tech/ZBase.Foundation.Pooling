using System;

namespace Unity.Pooling.Components
{
    [Serializable]
    public sealed class ComponentPrefab<T> : UnityPrefab<T>
        where T : UnityEngine.Component
    {
    }
}