using System.Pooling;

namespace Unity.Pooling
{
    public interface IUnityPool<TKey, T> : IUnityPool, IPool<TKey, T>, INamedRentable<TKey, T>
        where T : class
    {
    }
}