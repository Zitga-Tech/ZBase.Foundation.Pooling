using System.Pooling;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Unity.Pooling.Scriptables
{
    public class ScriptableComponentSource<T> : ScriptableSource<T>
        where T : Component
    {
        public override async UniTask<UnityEngine.Object> Instantiate(Transform parent)
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

        public override void Release(UnityEngine.Object instance)
        {
            if (instance is T component)
                Destroy(component.gameObject);
        }
    }
}
