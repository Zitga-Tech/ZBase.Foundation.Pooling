using System.Pooling;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Unity.Pooling.Scriptables.AddressableAssets
{
    public class ScriptableAddressComponentSource<T> : ScriptableAddressSource
        where T : Component
    {
        public override async UniTask<Object> Instantiate(Transform parent)
        {
            var source = Source;

            if (string.IsNullOrEmpty(source))
                ThrowHelper.ThrowArgumentNullException(ExceptionArgument.assetName);

            GameObject gameObject;

            if (parent)
                gameObject = await Addressables.InstantiateAsync(source, parent, true);
            else
                gameObject = await Addressables.InstantiateAsync(source);

            return gameObject.GetComponent<T>();
        }
    }
}
