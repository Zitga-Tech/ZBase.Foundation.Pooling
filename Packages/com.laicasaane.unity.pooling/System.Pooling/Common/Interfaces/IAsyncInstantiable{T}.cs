using Cysharp.Threading.Tasks;

namespace System.Pooling
{
    public interface IAsyncInstantiable<T> : IInstantiable<UniTask<T>>
    {
    }
}
