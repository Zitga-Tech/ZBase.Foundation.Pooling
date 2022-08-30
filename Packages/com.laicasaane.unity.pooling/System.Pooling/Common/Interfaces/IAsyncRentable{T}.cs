using System.Threading;
using Cysharp.Threading.Tasks;

namespace System.Pooling
{
    public interface IAsyncRentable<T> : IRentable<UniTask<T>>
    {
        UniTask<T> Rent(CancellationToken cancelToken);
    }
}