using System.Pooling;

namespace Unity.Pooling
{
    public interface IUnityPool<TKey, T> : IUnityPool, IAsyncPool<TKey, T>
        where T : class
    {
    }
}
