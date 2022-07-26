using System.Pooling;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Unity.Pooling.Scriptables.AddressableAssets
{
    public class ScriptableAssetRefComponentSource<T>
        : ScriptableAssetRefSource<AssetReferenceGameObject>
        where T : Component
    {
        public override async UniTask<Object> InstantiateAsync(Transform parent)
        {
            var source = Source;

            if (source == null)
                ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);

            GameObject gameObject;

            if (parent)
                gameObject = await source.InstantiateAsync(parent);
            else
                gameObject = await source.InstantiateAsync();

            return gameObject.GetComponent<T>();
        }
    }
}
