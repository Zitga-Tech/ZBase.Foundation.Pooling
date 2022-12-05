using System.Threading;
using Cysharp.Threading.Tasks;

namespace ZBase.Foundation.Pooling
{
    public interface IAsyncInstantiable<T> : IInstantiable<UniTask<T>>
    {
        UniTask<T> Instantiate(CancellationToken cancelToken);
    }
}
