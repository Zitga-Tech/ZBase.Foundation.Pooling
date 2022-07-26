using System.Pooling;

namespace Unity.Pooling.AddressableAssets
{
    public abstract class AssetNamePool<T, TInstantiator, TPrefab>
        : UnityPool<T, string, TPrefab>
        where T : UnityEngine.Object
        where TInstantiator : IAssetNameInstantiator<T>, new()
        where TPrefab : AssetNamePrefab<T, TInstantiator>
    {
        public AssetNamePool()
            : base(null, default)
        { }

        public AssetNamePool(TPrefab prefab)
            : base(null, prefab)
        { }

        public AssetNamePool(UniqueQueue<int, T> queue, TPrefab prefab)
            : base(queue, prefab)
        { }
    }
}
