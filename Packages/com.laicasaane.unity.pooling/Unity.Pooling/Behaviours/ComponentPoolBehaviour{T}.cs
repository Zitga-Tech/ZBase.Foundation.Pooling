namespace Unity.Pooling
{
    public class ComponentPoolBehaviour<T>
        : UnityPoolBehaviour<T
            , ComponentPrefab<T>
            , ComponentPool<T>
        >
        where T : UnityEngine.Component
    {
    }
}
