using System.Pooling;

namespace Unity.Pooling
{
    public interface INamedRentable<TKey, T> : IRentable<TKey, T> where T : class
    {
        T Rent(TKey key, string name);
    }
}