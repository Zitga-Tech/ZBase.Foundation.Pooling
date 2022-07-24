namespace Unity.Pooling
{
    public class ComponentPoolBehaviour<TKey, T>
        : UnityPoolBehaviour<TKey, T, T
            , ComponentInstantiator<T>
            , ComponentPrefab<TKey, T, ComponentInstantiator<T>>
            , ComponentPool<TKey, T>
            , ComponentPrepooler<TKey, T, ComponentPool<TKey, T>>
        >
        where T : UnityEngine.Component
    {
    }
}
