using UnityEngine;

namespace Unity.Pooling.AddressableAssets
{
    public class AssetNameComponentPoolBehaviour<T>
        : AssetNameComponentPoolBehaviour<T
            , AssetNameComponentPrefab<T>
            , AssetNameComponentPool<T>
        >
        where T : Component
    {
    }
}