using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Unity.Pooling.AddressableAssets
{
    public class AssetRefComponentPoolBehaviour<T>
        : AssetRefPoolBehaviour<
            T
            , AssetReferenceGameObject
            , AssetRefComponentPrefab<T>
            , AssetRefComponentPool<T>
            , AssetRefPrepooler<
                T
                , AssetReferenceGameObject
                , AssetRefComponentPrefab<T>
                , AssetRefComponentPool<T>
            >
        >
        where T : Component
    {
    }
}
