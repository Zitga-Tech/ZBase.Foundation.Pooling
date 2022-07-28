using System.Pooling;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Unity.Pooling.Scriptables.AddressableAssets
{
    public class ScriptableAddressableComponentSource<T> : ScriptableAssetNameSource
        where T : Component
    {
        public override async UniTask<Object> Instantiate(Transform parent)
        {
            var assetName = AssetName;

            if (string.IsNullOrEmpty(assetName))
                ThrowHelper.ThrowArgumentNullException(ExceptionArgument.assetName);

            GameObject gameObject;

            if (parent)
                gameObject = await Addressables.InstantiateAsync(assetName, parent, true);
            else
                gameObject = await Addressables.InstantiateAsync(assetName);

            return gameObject.GetComponent<T>();
        }
    }
}
