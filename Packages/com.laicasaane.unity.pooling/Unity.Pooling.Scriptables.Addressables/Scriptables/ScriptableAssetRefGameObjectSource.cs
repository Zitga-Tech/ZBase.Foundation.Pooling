using System.Pooling;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Unity.Pooling.Scriptables.AddressableAssets
{
    [CreateAssetMenu(
        fileName = "Scriptable AssetRef GameObject Source"
        , menuName = "Pooling/Scriptables/Sources/AssetRef GameObject"
        , order = 1
    )]
    public class ScriptableAssetRefGameObjectSource
        : ScriptableAssetRefSource<AssetReferenceGameObject>
    {
        public override async UniTask<Object> Instantiate(Transform parent, CancellationToken cancelToken = default)
        {
            var source = Source;

            if (source == null)
                ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);

            AsyncOperationHandle<GameObject> handle;

            if (parent)
                handle = source.InstantiateAsync(parent, true);
            else
                handle = source.InstantiateAsync();

            return await handle.WithCancellation(cancelToken);
        }

        public override void Release(Object instance)
        {
            if (instance is GameObject gameObject && Source != null)
                Source.ReleaseInstance(gameObject);
        }
    }
}
