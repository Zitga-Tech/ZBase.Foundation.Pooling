using System.Pooling;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Unity.Pooling.Scriptables.AddressableAssets
{
    [CreateAssetMenu(
        fileName = "Scriptable AssetRef GameObject Source"
        , menuName = "Pooling/Scriptables/Sources/AssetRef GameObject"
        , order = 1
    )]
    public class ScriptableAssetRefGameObjectSource
        : ScriptableAssetRefSource<AssetReferenceGameObject>
    {
        public override async UniTask<Object> InstantiateAsync(Transform parent)
        {
            var source = Source;

            if (source == null)
                ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);

            GameObject instance;

            if (parent)
                instance = await source.InstantiateAsync(parent, true);
            else
                instance = await source.InstantiateAsync();

            return instance;
        }
    }
}
