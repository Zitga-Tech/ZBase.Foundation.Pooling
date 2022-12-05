using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace ZBase.Foundation.Pooling.AddressableAssets
{
    [Serializable]
    public class AssetRefGameObjectPrefab
        : AssetRefPrefab<GameObject, AssetReferenceGameObject>
    {
        protected override async UniTask<GameObject> Instantiate(
              AssetReferenceGameObject source
            , Transform parent
            , CancellationToken cancelToken
        )
        {
            AsyncOperationHandle<GameObject> handle;

            if (parent)
                handle = source.InstantiateAsync(parent, true);
            else
                handle = source.InstantiateAsync();

            return await handle.WithCancellation(cancelToken);
        }

        public override void Release(GameObject instance)
        {
            if (instance && Source != null)
                Source.ReleaseInstance(instance);
        }
    }
}
