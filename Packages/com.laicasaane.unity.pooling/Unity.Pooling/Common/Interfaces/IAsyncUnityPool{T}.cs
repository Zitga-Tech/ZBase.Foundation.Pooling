using System.Pooling;

namespace Unity.Pooling
{
    public interface IAsyncUnityPool<T>
        : IUnityPool, IAsyncPool<T>, IAsyncNamedRentable<T>
        where T : class
    {
    }

    public interface IAsyncUnityPool<T, S, TSource, TPrefab>
        : IUnityPool, IAsyncPool<T>, IAsyncNamedRentable<T>
        where T : class
        where TSource : ILoadableSource<S, T>
        where TPrefab : IPrefab<T, S, TSource>
    {
    }
}
