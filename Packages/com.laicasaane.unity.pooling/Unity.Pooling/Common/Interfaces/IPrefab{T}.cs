using System.Pooling;

namespace Unity.Pooling
{
    public interface IPrefab<T, TSource>
        : IPrefab, IAsyncInstantiable<T>, IHasParent
    {
        TSource Source { get; set; }
    }
}
