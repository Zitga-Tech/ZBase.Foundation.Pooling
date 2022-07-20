using System.Pooling;

namespace Unity.Pooling
{
    public interface IUnityPool<T>
        : IUnityPool, IPool<T>, INamedRentable<T>
        where T : class
    {
    }

    public interface IUnityPool<T, S, TSource, TPrefab>
        : IUnityPool, IPool<T>, INamedRentable<T>
        where T : class
        where TSource : ILoadableSource<S, T>
        where TPrefab : IPrefab<T, S, TSource>
    {
    }
}