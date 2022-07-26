using UnityEngine;

namespace Unity.Pooling.AddressableAssets
{
    public class AssetNameGameObjectPool<TInstantiator, TPrefab>
        : AssetNamePool<GameObject, TInstantiator, TPrefab>
        where TInstantiator : IAssetNameInstantiator<GameObject>, new()
        where TPrefab : AssetNameGameObjectPrefab<TInstantiator>
    {
        protected override void ReturnPreprocess(GameObject instance)
        {
            if (instance && instance.activeSelf)
                instance.SetActive(false);
        }
    }
}
