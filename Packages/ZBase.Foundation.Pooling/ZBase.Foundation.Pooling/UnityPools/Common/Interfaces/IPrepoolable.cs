using System.Threading;
using Cysharp.Threading.Tasks;

namespace ZBase.Foundation.Pooling.UnityPools
{
    public interface IPrepoolable
    {
        UniTask Prepool(CancellationToken cancelToken);
    }
}
