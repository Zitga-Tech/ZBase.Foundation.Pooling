using System.Pooling;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Unity.Pooling.Scriptables
{
    [CreateAssetMenu(fileName = "Scriptable GameObject Source", menuName = "Pooling/Scriptables/Sources/GameObject", order = 1)]
    public class ScriptableGameObjectSource : ScriptableSource
    {
        [SerializeField]
        private GameObject _source;

        public override async UniTask<UnityEngine.Object> InstantiateAsync(Transform parent)
        {
            if (_source == false)
                ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);

            GameObject instance;

            if (parent)
                instance = Instantiate(_source, parent);
            else
                instance = Instantiate(_source);

            return await UniTask.FromResult(instance);
        }
    }
}
