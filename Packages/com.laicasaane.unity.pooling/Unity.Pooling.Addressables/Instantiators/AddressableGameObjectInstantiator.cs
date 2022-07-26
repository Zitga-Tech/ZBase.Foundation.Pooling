using UnityEngine;
using Cysharp.Threading.Tasks;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Unity.Pooling.AddressableAssets
{
    public class AddressableGameObjectInstantiator : AssetNameInstantiator<GameObject>
    {
        public override async UniTask<GameObject> InstantiateAsync(string assetName, Transform parent)
        {
            AsyncOperationHandle<GameObject> handle;

            if (parent)
                handle = Addressables.InstantiateAsync(assetName, parent);
            else
                handle = Addressables.InstantiateAsync(assetName);

            return await handle;
        }
    }
}
