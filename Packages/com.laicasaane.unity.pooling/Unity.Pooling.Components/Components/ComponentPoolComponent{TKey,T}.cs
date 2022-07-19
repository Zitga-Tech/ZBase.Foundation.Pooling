﻿namespace Unity.Pooling.Components
{
    public abstract class ComponentPoolComponent<TKey, T>
        : PoolComponentBase<TKey, T, Prefab<TKey, T>, ComponentPool<TKey, T>>
        where T : UnityEngine.Component
    {
        protected override void ReleaseInstance(T instance)
        {
            if (instance && instance.gameObject)
                Destroy(instance.gameObject);
        }
    }
}