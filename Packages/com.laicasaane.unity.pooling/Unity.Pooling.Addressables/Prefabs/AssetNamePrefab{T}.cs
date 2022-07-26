using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Unity.Pooling.AddressableAssets
{
    public abstract class AssetNamePrefab<T, TInstantiator>
        : UnityPrefab<T, string>
        where T : UnityEngine.Object
        where TInstantiator : IAssetNameInstantiator<T>, new()
    {
        protected readonly TInstantiator Instantiator = new TInstantiator();

        protected override async UniTask<T> InstantiateAsync(string source, Transform parent)
            => await Instantiator.InstantiateAsync(source, parent);
    }
}
