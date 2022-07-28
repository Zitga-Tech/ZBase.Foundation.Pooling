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
    public class ScriptableAssetNameGameObjectSource : ScriptableAssetNameSource
    {
        public override async UniTask<Object> Instantiate(Transform parent)
        {
            var assetName = AssetName;

            if (string.IsNullOrEmpty(assetName))
                ThrowHelper.ThrowArgumentNullException(ExceptionArgument.assetName);

            GameObject instance;

            if (parent)
                instance = await Addressables.InstantiateAsync(assetName, parent, true);
            else
                instance = await Addressables.InstantiateAsync(assetName);

            return instance;
        }
    }
}
