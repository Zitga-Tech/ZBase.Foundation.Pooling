using UnityEngine;
using ZBase.Foundation.Pooling.UnityPools;

namespace ZBase.Foundation.Pooling.AddressableAssets
{
    public class AssetRefGameObjectPoolBehaviour
        : UnityPoolBehaviour<
            GameObject
            , AssetRefGameObjectPrefab
            , AssetRefGameObjectPool
        >
    {
    }
}