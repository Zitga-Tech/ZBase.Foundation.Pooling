using UnityEngine;
using Cysharp.Threading.Tasks;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Unity.Pooling.AddressableAssets
{
    public class AddressableComponentInstantiator<T> : AssetNameInstantiator<T>
        where T : Component
    {
        public override async UniTask<T> InstantiateAsync(string assetName, Transform parent)
        {
            AsyncOperationHandle<GameObject> handle;

            if (parent)
                handle = Addressables.InstantiateAsync(assetName, parent);
            else
                handle = Addressables.InstantiateAsync(assetName);

            var gameObject = await handle;

            return gameObject.GetComponent<T>();
        }
    }
}
