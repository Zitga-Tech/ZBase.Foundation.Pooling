using System;

namespace Unity.Pooling.Components
{
    [Serializable]
    public class ComponentPrefab<TKey, T> : Prefab<TKey, T>
        where T : UnityEngine.Component
    {
    }
}