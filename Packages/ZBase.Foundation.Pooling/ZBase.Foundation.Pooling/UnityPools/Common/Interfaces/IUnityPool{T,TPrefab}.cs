namespace ZBase.Foundation.Pooling.UnityPools
{
    public interface IUnityPool<T, TPrefab> : IUnityPool<T>
        where TPrefab : IPrefab
    {
        TPrefab Prefab { get; set; }
    }
}
