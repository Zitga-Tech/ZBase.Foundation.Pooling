using System.Pooling;

namespace Unity.Pooling
{
    public interface INamedRentable<T> : IRentable<T> where T : class
    {
        T Rent(string name);
    }
}