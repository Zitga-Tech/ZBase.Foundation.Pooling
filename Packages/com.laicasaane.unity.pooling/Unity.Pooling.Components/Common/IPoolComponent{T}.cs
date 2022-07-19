namespace Unity.Pooling.Components
{
    public interface IPoolComponent<T, TPrefab, TPool>
        : IPoolComponent, IUnityPool<T>
        where T : class
        where TPrefab : IPrefab
        where TPool : IUnityPool<T>
    {
        TPrefab Prefab { get; }

        TPool Pool { get; }
    }
}
