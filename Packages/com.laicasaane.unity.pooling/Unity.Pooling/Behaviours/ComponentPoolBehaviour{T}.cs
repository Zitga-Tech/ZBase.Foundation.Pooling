namespace Unity.Pooling
{
    public class ComponentPoolBehaviour<T>
        : UnityPoolBehaviour<T, T
            , ComponentInstantiator<T>
            , ComponentPrefab<T, ComponentInstantiator<T>>
            , ComponentPool<T>
            , ComponentPrepooler<T, ComponentPool<T>>
        >
        where T : UnityEngine.Component
    {
    }
}
