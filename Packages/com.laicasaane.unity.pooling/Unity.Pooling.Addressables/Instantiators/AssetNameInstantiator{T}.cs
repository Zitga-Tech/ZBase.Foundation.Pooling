using System;
using UnityEngine;
using Cysharp.Threading.Tasks;

namespace Unity.Pooling.AddressableAssets
{
    [Serializable]
    public abstract class AssetNameInstantiator<T>
        : IAssetNameInstantiator<T>
        where T : UnityEngine.Object
    {
        public abstract UniTask<T> Instantiate(string assetName, Transform parent);
    }
}
