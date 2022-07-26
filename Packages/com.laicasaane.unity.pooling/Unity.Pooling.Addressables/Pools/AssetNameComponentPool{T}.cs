using System;
using UnityEngine;

namespace Unity.Pooling.AddressableAssets
{
    [Serializable]
    public class AssetNameComponentPool<T, TInstantiator, TPrefab>
        : AssetNamePool<T, TInstantiator, TPrefab>
        where T : Component
        where TInstantiator : IAssetNameInstantiator<T>, new()
        where TPrefab : AssetNameComponentPrefab<T, TInstantiator>
    {
        protected override void ReturnPreprocess(T instance)
        {
            if (instance && instance.gameObject && instance.gameObject.activeSelf)
                instance.gameObject.SetActive(false);
        }
    }
}
