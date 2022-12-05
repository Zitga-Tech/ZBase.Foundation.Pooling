using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using ZBase.Foundation.Pooling;

namespace Unity.Pooling.Scriptables.AddressableAssets
{
    public class ScriptableAssetRefComponentSource<T>
        : ScriptableAssetRefSource<AssetReferenceGameObject>
        where T : Component
    {
        public override async UniTask<Object> Instantiate(Transform parent, CancellationToken cancelToken = default)
        {
            var source = Source;

            if (source == null)
                ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);

            AsyncOperationHandle<GameObject> handle;

            if (parent)
                handle = source.InstantiateAsync(parent);
            else
                handle = source.InstantiateAsync();

            var gameObject = await handle.WithCancellation(cancelToken);

            return gameObject.GetComponent<T>();
        }

        public override void Release(Object instance)
        {
            if (instance is T component && Source != null)
                Source.ReleaseInstance(component.gameObject);
        }
    }
}
