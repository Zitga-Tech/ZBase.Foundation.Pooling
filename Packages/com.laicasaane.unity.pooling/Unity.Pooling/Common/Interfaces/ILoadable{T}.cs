using Cysharp.Threading.Tasks;

namespace Unity.Pooling
{
    public interface ILoadable<T>
    {
        UniTask<T> Load();
    }
}
