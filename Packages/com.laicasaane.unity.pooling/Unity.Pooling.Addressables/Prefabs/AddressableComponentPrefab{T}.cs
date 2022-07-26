using System;
using UnityEngine;

namespace Unity.Pooling.AddressableAssets
{
    [Serializable]
    public class AddressableComponentPrefab<T>
        : AssetNameComponentPrefab<T, AddressableComponentInstantiator<T>>
        where T : Component
    {
    }
}
