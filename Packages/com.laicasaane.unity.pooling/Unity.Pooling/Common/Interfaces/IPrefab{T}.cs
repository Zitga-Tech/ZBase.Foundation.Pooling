using System.Pooling;

namespace Unity.Pooling
{
    public interface IPrefab<T>
        : IPrefab, IAsyncInstantiable<T>, IHasParent
    {
    }
}
