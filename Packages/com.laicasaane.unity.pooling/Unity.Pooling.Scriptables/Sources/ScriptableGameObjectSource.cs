using System.Pooling;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Unity.Pooling.Scriptables
{
    [CreateAssetMenu(
        fileName = "Scriptable GameObject Source"
        , menuName = "Pooling/Scriptables/Sources/GameObject"
        , order = 1
    )]
    public class ScriptableGameObjectSource : ScriptableSource<GameObject>
    {
        public override async UniTask<UnityEngine.Object> Instantiate(Transform parent)
        {
            var source = Source;

            if (source == false)
                ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);

            GameObject instance;

            if (parent)
                instance = Instantiate(source, parent);
            else
                instance = Instantiate(source);

            return await UniTask.FromResult(instance);
        }
    }
}
