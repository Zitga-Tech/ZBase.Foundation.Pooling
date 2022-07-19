namespace Unity.Pooling.Components
{
    public interface IPoolComponent<TKey, T, TPrefab, TPool>
        : IPoolComponent, IUnityPool<TKey, T>
        where T : UnityEngine.Object
        where TPrefab : IPrefab<TKey, T>
        where TPool : IUnityPool<TKey, T>
    {
        TPrefab Prefab { get; }

        TPool Pool { get; }
    }
}
