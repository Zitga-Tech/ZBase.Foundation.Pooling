using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Unity.Pooling.AddressableAssets
{
    public interface IAssetNameInstantiator<T>
    {
        UniTask<T> InstantiateAsync(string assetName, Transform parent);
    }
}
