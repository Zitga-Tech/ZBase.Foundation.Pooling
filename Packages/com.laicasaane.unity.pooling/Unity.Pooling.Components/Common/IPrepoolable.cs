using Cysharp.Threading.Tasks;

namespace Unity.Pooling.Components
{
    public interface IPrepoolable
    {
        UniTask Prepool();
    }
}
