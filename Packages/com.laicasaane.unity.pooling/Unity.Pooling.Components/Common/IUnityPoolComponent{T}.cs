namespace Unity.Pooling.Components
{
    public interface IUnityPoolComponent<T, TPrefab, TPool>
        : IUnityPoolComponent, IUnityPool<T>
        where T : UnityEngine.Object
        where TPrefab : IUnityPrefab<T>
        where TPool : IUnityPool<T>
    {
        TPrefab Prefab { get; }

        TPool Pool { get; }
    }
}
