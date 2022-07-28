using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Unity.Pooling.AddressableAssets
{
    public interface IAssetNameInstantiator<T>
    {
        UniTask<T> Instantiate(string assetName, Transform parent);
    }
}
