using System.Pooling;
using System.Threading;
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
        public override async UniTask<Object> Instantiate(Transform parent, CancellationToken cancelToken = default)
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

        public override void Release(Object instance)
        {
            if (instance is GameObject gameObject)
                Destroy(gameObject);
        }
    }
}
