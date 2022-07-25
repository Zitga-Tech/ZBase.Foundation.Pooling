using UnityEngine;
using Cysharp.Threading.Tasks;

namespace Unity.Pooling.AddressableAssets
{
    public abstract class AssetNameInstantiator<T>
        : IAssetNameInstantiator<T>
        where T : UnityEngine.Object
    {
        public abstract UniTask<T> InstantiateAsync(string assetName, Transform parent);
    }
}
