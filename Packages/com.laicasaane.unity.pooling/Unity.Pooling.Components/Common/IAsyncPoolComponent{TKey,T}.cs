namespace Unity.Pooling.Components
{
    public interface IAsyncPoolComponent<TKey, T, TPrefab, TPool>
        : IPoolComponent, IAsyncUnityPool<TKey, T>
        where T : UnityEngine.Object
        where TPrefab : IPrefab<TKey, T>
        where TPool : IAsyncUnityPool<TKey, T>
    {
        TPrefab Prefab { get; }

        TPool Pool { get; }
    }
}
