using System.Pooling;

namespace Unity.Pooling
{
    public interface IUnityPool<TKey, T>
        : IUnityPool, IPool<TKey, T>, INamedRentable<TKey, T>
        where T : class
    {
    }

    public interface IUnityPool<TKey, T, S, TSource, TPrefab>
        : IUnityPool, IPool<TKey, T>, INamedRentable<TKey, T>
        where T : class
        where TSource : ILoadableSource<S, T>
        where TPrefab : IPrefab<TKey, T, S, TSource>
    {
    }
}