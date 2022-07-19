namespace Unity.Pooling.Components
{
    public interface IAsyncPoolComponent<T, TPrefab, TPool>
        : IPoolComponent, IAsyncUnityPool<T>
        where T : class
        where TPrefab : IPrefab
        where TPool : IAsyncUnityPool<T>
    {
        TPrefab Prefab { get; }

        TPool Pool { get; }
    }
}
