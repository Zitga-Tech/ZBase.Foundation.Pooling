namespace Unity.Pooling.Components
{
    public abstract class ComponentPoolComponent<T>
        : UnityPoolComponentBase<T, UnityPrefab<T>, ComponentPool<T>>
        where T : UnityEngine.Component
    {
        protected override void ReleaseInstance(T instance)
        {
            if (instance && instance.gameObject)
                Destroy(instance.gameObject);
        }
    }
}
