using System.Threading;
using Cysharp.Threading.Tasks;

namespace Unity.Pooling
{
    public interface IPrepoolable
    {
        UniTask Prepool(CancellationToken cancelToken);
    }
}
