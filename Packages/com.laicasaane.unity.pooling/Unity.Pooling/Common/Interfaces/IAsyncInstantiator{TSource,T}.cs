using Cysharp.Threading.Tasks;

namespace Unity.Pooling
{
    public interface IAsyncInstantiator<TSource, T> : IHasParent
        where T : class
    {
        TSource Source { get; set; }

        UniTask<T> InstantiateAsync();
    }
}
