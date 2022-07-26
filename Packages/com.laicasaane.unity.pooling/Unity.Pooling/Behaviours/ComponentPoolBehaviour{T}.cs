namespace Unity.Pooling
{
    public class ComponentPoolBehaviour<T>
        : UnityPoolBehaviour<T, T
            , ComponentPrefab<T>
            , ComponentPool<T>
            , UnityPrepooler<T, T, ComponentPrefab<T>, ComponentPool<T>>
        >
        where T : UnityEngine.Component
    {
    }
}
