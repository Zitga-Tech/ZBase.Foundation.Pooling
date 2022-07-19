using System;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Unity.Pooling.Components.Addressables
{
    [Serializable]
    public sealed class AssetRefGameObjectPrefab : AssetRefPrefab<GameObject, AssetReferenceGameObject>
    {
    }
}
