using Cysharp.Threading.Tasks;

namespace Unity.Pooling
{
    public interface IAsyncPrepoolable
    {
        UniTask PrepoolAsync();
    }
}
