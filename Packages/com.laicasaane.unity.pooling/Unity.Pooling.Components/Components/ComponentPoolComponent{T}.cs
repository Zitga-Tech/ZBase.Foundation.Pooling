namespace Unity.Pooling.Components
{
    public abstract class ComponentPoolComponent<T>
        : PoolComponentBase<T, Prefab<T>, ComponentPool<T>>
        where T : UnityEngine.Component
    {
        protected override void ReleaseInstance(T instance)
        {
            if (instance && instance.gameObject)
                Destroy(instance.gameObject);
        }
    }
}
