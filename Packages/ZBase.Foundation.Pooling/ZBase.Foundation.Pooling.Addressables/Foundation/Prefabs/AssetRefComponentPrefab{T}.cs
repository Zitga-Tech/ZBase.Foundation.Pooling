using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace ZBase.Foundation.Pooling.AddressableAssets
{
    [Serializable]
    public class AssetRefComponentPrefab<T>
        : AssetRefPrefab<T, AssetReferenceGameObject>
        where T : Component
    {
        protected override async UniTask<T> Instantiate(
              AssetReferenceGameObject source
            , Transform parent
            , CancellationToken cancelToken = default
        )
        {
            AsyncOperationHandle<GameObject> handle;

            if (parent)
                handle = source.InstantiateAsync(parent, true);
            else
                handle = source.InstantiateAsync();

            var gameObject = await handle.WithCancellation(cancelToken);

            return gameObject.GetComponent<T>();
        }

        public override void Release(T instance)
        {
            if (instance && Source != null)
                Source.ReleaseInstance(instance.gameObject);
        }
    }
}
