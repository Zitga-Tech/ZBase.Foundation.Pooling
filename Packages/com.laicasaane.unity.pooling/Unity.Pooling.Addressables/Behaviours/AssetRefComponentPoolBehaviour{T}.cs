using UnityEngine;

namespace Unity.Pooling.AddressableAssets
{
    public class AssetRefComponentPoolBehaviour<T>
        : UnityPoolBehaviour<
            T
            , AssetRefComponentPrefab<T>
            , AssetRefComponentPool<T>
            , UnityPrepooler<
                T
                , AssetRefComponentPrefab<T>
                , AssetRefComponentPool<T>
            >
        >
        where T : Component
    {
    }
}