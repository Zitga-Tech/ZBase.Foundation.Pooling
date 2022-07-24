using System.Pooling;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Unity.Pooling.Scriptables
{
    [CreateAssetMenu(fileName = "Scriptable Component Source", menuName = "Pooling/Scriptables/Sources/Component", order = 1)]
    public class ScriptableComponentSource : ScriptableSource
    {
        [SerializeField]
        private Component _source;

        public override async UniTask<UnityEngine.Object> InstantiateAsync(Transform parent)
        {
            if (_source == false)
                ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);

            Component instance;

            if (parent)
                instance = Instantiate(_source, parent);
            else
                instance = Instantiate(_source);

            return await UniTask.FromResult(instance);
        }
    }
}
