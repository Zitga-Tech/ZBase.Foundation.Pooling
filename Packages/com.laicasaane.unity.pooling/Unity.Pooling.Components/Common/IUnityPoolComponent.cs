using Cysharp.Threading.Tasks;

namespace Unity.Pooling.Components
{
    public interface IUnityPoolComponent
    {
        UniTask Prepool();
    }
}
