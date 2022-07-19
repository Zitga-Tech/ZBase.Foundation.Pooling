namespace Unity.Pooling.Components
{
    public interface IPoolComponent<T, TPrefab, TPool>
        : IPoolComponent, IUnityPool<T>
        where T : UnityEngine.Object
        where TPrefab : IPrefab<T>
        where TPool : IUnityPool<T>
    {
        TPrefab Prefab { get; }

        TPool Pool { get; }
    }
}
