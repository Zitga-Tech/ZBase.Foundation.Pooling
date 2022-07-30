using System.Pooling;

namespace Unity.Pooling
{
    public interface IUnityPool<T, TPrefab> : IUnityPool, IAsyncPool<T>
        where TPrefab : IPrefab
    {
        TPrefab Prefab { get; set; }
    }
}
