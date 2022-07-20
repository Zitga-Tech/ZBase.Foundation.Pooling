using System.Pooling;

namespace Unity.Pooling
{
    public interface IAsyncUnityPool<TKey, T>
        : IUnityPool, IAsyncPool<TKey, T>, IAsyncNamedRentable<TKey, T>
        where T : class
    {
    }

    public interface IAsyncUnityPool<TKey, T, S, TSource, TPrefab>
        : IUnityPool, IAsyncPool<TKey, T>, IAsyncNamedRentable<TKey, T>
        where T : class
        where TSource : ILoadableSource<S, T>
        where TPrefab : IPrefab<TKey, T, S, TSource>
    {
    }
}
