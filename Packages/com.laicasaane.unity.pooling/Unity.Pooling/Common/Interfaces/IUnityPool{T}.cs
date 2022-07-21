using System.Pooling;

namespace Unity.Pooling
{
    public interface IUnityPool<T> : IUnityPool, IAsyncPool<T>
        where T : class
    {
    }
}
