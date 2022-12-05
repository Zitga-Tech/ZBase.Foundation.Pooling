using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using ZBase.Foundation.Pooling;

namespace Unity.Pooling.Scriptables.AddressableAssets
{
    public class ScriptableAddressComponentSource<T> : ScriptableAddressSource
        where T : Component
    {
        public override async UniTask<Object> Instantiate(Transform parent, CancellationToken cancelToken = default)
        {
            var source = Source;

            if (string.IsNullOrEmpty(source))
                ThrowHelper.ThrowArgumentNullException(ExceptionArgument.assetName);

            AsyncOperationHandle<GameObject> handle;

            if (parent)
                handle = Addressables.InstantiateAsync(source, parent, true);
            else
                handle = Addressables.InstantiateAsync(source);

            var gameObject = await handle.WithCancellation(cancelToken);

            return gameObject.GetComponent<T>();
        }

        public override void Release(Object instance)
        {
            if (instance is T component)
                Addressables.ReleaseInstance(component.gameObject);
        }
    }
}
