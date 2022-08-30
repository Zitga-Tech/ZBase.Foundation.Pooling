using System.Pooling;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Unity.Pooling.Scriptables
{
    public class ScriptableComponentSource<T> : ScriptableSource<T>
        where T : Component
    {
        public override async UniTask<Object> Instantiate(Transform parent, CancellationToken cancelToken = default)
        {
            var source = Source;

            if (source == false)
                ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);

            T instance;

            if (parent)
                instance = Instantiate(source, parent);
            else
                instance = Instantiate(source);

            return await UniTask.FromResult(instance);
        }

        public override void Release(Object instance)
        {
            if (instance is T component)
                Destroy(component.gameObject);
        }
    }
}
