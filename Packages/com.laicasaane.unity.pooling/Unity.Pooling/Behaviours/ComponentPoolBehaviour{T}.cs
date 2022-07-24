namespace Unity.Pooling
{
    public class ComponentPoolBehaviour<T>
        : UnityPoolBehaviour<T, T
            , ComponentPrefab<T>
            , ComponentPool<T>
            , ComponentPrepooler<T, ComponentPool<T>>
        >
        where T : UnityEngine.Component
    {
    }
}
