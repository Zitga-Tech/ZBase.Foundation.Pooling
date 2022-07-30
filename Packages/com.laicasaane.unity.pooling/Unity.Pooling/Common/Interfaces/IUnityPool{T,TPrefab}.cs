namespace Unity.Pooling
{
    public interface IUnityPool<T, TPrefab> : IUnityPool<T>
        where TPrefab : IPrefab
    {
        TPrefab Prefab { get; set; }
    }
}
