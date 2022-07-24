using Cysharp.Threading.Tasks;

namespace Unity.Pooling
{
    public interface IAsyncInstantiable<T>
    {
        UniTask<T> InstantiateAsync();
    }
}
