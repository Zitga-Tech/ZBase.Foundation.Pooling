namespace Unity.Pooling.Components
{
    public interface IAsyncPoolComponent<T, TPrefab, TPool>
        : IPoolComponent, IAsyncUnityPool<T>
        where T : UnityEngine.Object
        where TPrefab : IPrefab<T>
        where TPool : IAsyncUnityPool<T>
    {
        TPrefab Prefab { get; }

        TPool Pool { get; }
    }
}
