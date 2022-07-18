namespace Unity.Pooling.Components
{
    public interface IAsyncUnityPoolComponent<TKey, T, TPrefab, TPool>
        : IUnityPoolComponent, IAsyncUnityPool<TKey, T>
        where T : UnityEngine.Object
        where TPrefab : IUnityPrefab<TKey, T>
        where TPool : IAsyncUnityPool<TKey, T>
    {
        TPrefab Prefab { get; }

        TPool Pool { get; }
    }
}
