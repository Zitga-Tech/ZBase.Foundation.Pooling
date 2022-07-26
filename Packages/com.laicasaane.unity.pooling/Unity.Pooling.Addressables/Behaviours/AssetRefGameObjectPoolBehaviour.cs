using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Unity.Pooling.AddressableAssets
{
    public class AssetRefGameObjectPoolBehaviour
        : AssetRefPoolBehaviour<
            GameObject
            , AssetReferenceGameObject
            , AssetRefGameObjectPrefab
            , AssetRefGameObjectPool
            , AssetRefPrepooler<
                GameObject
                , AssetReferenceGameObject
                , AssetRefGameObjectPrefab
                , AssetRefGameObjectPool
            >
        >
    {
    }
}
