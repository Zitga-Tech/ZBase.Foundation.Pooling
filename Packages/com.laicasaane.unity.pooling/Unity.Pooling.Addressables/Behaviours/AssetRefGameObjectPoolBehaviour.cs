using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Unity.Pooling.AddressableAssets
{
    public class AssetRefGameObjectPoolBehaviour
        : UnityPoolBehaviour<
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
