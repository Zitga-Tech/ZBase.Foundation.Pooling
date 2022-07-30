using System.Pooling;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Unity.Pooling.Scriptables.AddressableAssets
{
    [CreateAssetMenu(
        fileName = "Scriptable Asset Name GameObject Source"
        , menuName = "Pooling/Scriptables/Sources/Asset Name GameObject"
        , order = 1
    )]
    public class ScriptableAddressGameObjectSource : ScriptableAddressSource
    {
        public override async UniTask<Object> Instantiate(Transform parent)
        {
            var source = Source;

            if (string.IsNullOrEmpty(source))
                ThrowHelper.ThrowArgumentNullException(ExceptionArgument.assetName);

            GameObject instance;

            if (parent)
                instance = await Addressables.InstantiateAsync(source, parent, true);
            else
                instance = await Addressables.InstantiateAsync(source);

            return instance;
        }

        public override void Release(Object instance)
        {
            if (instance is GameObject gameObject)
                Addressables.ReleaseInstance(gameObject);
        }
    }
}
