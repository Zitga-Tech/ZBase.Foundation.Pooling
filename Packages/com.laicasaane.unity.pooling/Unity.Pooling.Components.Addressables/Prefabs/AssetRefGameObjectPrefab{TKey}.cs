using System;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Unity.Pooling.Components.Addressables
{
    [Serializable]
    public class AssetRefGameObjectPrefab<TKey> : AssetRefPrefab<TKey, GameObject, AssetReferenceGameObject>
    {
    }
}
