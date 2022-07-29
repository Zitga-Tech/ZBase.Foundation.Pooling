using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Unity.Pooling.AddressableAssets
{
    [Serializable]
    public class AddressGameObjectPrefab
        : AddressPrefab<GameObject>
    {
        protected override async UniTask<GameObject> Instantiate(string source, Transform parent)
        {
            AsyncOperationHandle<GameObject> handle;

            if (parent)
                handle = Addressables.InstantiateAsync(source, parent);
            else
                handle = Addressables.InstantiateAsync(source);

            return await handle;
        }
    }
}
