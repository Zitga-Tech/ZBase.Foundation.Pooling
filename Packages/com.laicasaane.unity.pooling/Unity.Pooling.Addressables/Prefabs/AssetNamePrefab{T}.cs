using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Unity.Pooling.AddressableAssets
{
    [Serializable]
    public abstract class AssetNamePrefab<T>
        : UnityPrefab<T, string>
        where T : UnityEngine.Object
    {
    }
}
