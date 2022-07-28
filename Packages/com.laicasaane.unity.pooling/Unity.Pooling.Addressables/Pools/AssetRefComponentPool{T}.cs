using System;
using UnityEngine;

namespace Unity.Pooling.AddressableAssets
{
    [Serializable]
    public class AssetRefComponentPool<T>
        : ComponentPool<T, AssetRefComponentPrefab<T>>
        where T : Component
    {
    }
}
