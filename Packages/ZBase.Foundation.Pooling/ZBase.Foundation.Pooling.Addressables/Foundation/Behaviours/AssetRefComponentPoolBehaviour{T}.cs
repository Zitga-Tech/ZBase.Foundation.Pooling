using UnityEngine;
using ZBase.Foundation.Pooling.UnityPools;

namespace ZBase.Foundation.Pooling.AddressableAssets
{
    public class AssetRefComponentPoolBehaviour<T>
        : UnityPoolBehaviour<
            T
            , AssetRefComponentPrefab<T>
            , AssetRefComponentPool<T>
        >
        where T : Component
    {
    }
}