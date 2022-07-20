using Cysharp.Threading.Tasks;

namespace Unity.Pooling.Components
{
    public interface IAssetLoader<TRef, T>
        where T : class
    {
        TRef Reference { get; set; }

        UniTask<T> Load();
    }
}
