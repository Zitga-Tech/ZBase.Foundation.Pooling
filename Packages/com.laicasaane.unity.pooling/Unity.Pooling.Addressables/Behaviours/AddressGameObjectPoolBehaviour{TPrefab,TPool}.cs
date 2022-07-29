using UnityEngine;

namespace Unity.Pooling.AddressableAssets
{
    public class AddressGameObjectPoolBehaviour<TPrefab, TPool>
        : UnityPoolBehaviour<GameObject, TPrefab, TPool>
        where TPrefab : AddressGameObjectPrefab
        where TPool : AddressGameObjectPool<TPrefab>
    {
    }
}
