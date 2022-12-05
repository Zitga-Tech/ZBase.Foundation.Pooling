using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace ZBase.Foundation.Pooling.AddressableAssets
{
    [Serializable]
    public class AddressComponentPrefab<T>
        : AddressPrefab<T>
        where T : Component
    {
        protected override async UniTask<T> Instantiate(
              string source
            , Transform parent
            , CancellationToken cancelToken = default
        )
        {
            AsyncOperationHandle<GameObject> handle;

            if (parent)
                handle = Addressables.InstantiateAsync(source, parent);
            else
                handle = Addressables.InstantiateAsync(source);

            var gameObject = await handle.WithCancellation(cancelToken);

            return gameObject.GetComponent<T>();
        }

        public override void Release(T instance)
        {
            if (instance)
                Addressables.ReleaseInstance(instance.gameObject);
        }
    }
}
