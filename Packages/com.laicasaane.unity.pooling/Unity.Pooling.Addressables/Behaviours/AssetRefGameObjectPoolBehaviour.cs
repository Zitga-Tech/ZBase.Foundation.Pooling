using UnityEngine;

namespace Unity.Pooling.AddressableAssets
{
    public class AssetRefGameObjectPoolBehaviour
        : UnityPoolBehaviour<
            GameObject
            , AssetRefGameObjectPrefab
            , AssetRefGameObjectPool
            , UnityPrepooler<
                GameObject
                , AssetRefGameObjectPrefab
                , AssetRefGameObjectPool
            >
        >
    {
    }
}