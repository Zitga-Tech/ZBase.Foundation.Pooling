using System;

namespace Unity.Pooling.Components
{
    [Serializable]
    public class ComponentPrefab<T> : Prefab<T>
        where T : UnityEngine.Component
    {
    }
}