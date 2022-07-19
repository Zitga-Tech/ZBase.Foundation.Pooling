namespace Unity.Pooling.Components
{
    public interface IPoolComponent<TKey, T, TPrefab, TPool>
        : IPoolComponent, IUnityPool<TKey, T>
        where T : class
        where TPrefab : IPrefab
        where TPool : IUnityPool<TKey, T>
    {
        TPrefab Prefab { get; }

        TPool Pool { get; }
    }
}
