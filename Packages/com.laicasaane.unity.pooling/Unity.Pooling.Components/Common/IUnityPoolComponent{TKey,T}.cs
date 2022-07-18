namespace Unity.Pooling.Components
{
    public interface IUnityPoolComponent<TKey, T, TPrefab, TPool>
        : IUnityPoolComponent, IUnityPool<TKey, T>
        where T : UnityEngine.Object
        where TPrefab : IUnityPrefab<TKey, T>
        where TPool : IUnityPool<TKey, T>
    {
        TPrefab Prefab { get; }

        TPool Pool { get; }
    }
}
