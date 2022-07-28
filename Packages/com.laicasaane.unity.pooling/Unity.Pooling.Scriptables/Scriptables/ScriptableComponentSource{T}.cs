using System.Pooling;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Unity.Pooling.Scriptables
{
    public class ScriptableComponentSource<T> : ScriptableSource
        where T : Component
    {
        [SerializeField]
        private T _source;

        public override async UniTask<UnityEngine.Object> Instantiate(Transform parent)
        {
            if (_source == false)
                ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);

            T instance;

            if (parent)
                instance = Instantiate(_source, parent);
            else
                instance = Instantiate(_source);

            return await UniTask.FromResult(instance);
        }
    }
}
