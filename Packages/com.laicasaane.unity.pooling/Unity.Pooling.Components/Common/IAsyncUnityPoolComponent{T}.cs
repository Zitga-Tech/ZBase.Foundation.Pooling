namespace Unity.Pooling.Components
{
    public interface IAsyncUnityPoolComponent<T, TPrefab, TPool>
        : IUnityPoolComponent, IAsyncUnityPool<T>
        where T : UnityEngine.Object
        where TPrefab : IUnityPrefab<T>
        where TPool : IAsyncUnityPool<T>
    {
        TPrefab Prefab { get; }

        TPool Pool { get; }
    }
}
