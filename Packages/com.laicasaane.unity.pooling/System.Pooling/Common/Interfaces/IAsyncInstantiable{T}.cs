using System.Threading;
using Cysharp.Threading.Tasks;

namespace System.Pooling
{
    public interface IAsyncInstantiable<T> : IInstantiable<UniTask<T>>
    {
        UniTask<T> Instantiate(CancellationToken cancelToken);
    }
}
