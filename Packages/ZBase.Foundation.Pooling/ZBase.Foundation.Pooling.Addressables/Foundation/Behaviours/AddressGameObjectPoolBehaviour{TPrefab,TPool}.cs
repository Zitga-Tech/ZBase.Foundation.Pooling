using UnityEngine;
using ZBase.Foundation.Pooling.UnityPools;

namespace ZBase.Foundation.Pooling.AddressableAssets
{
    public class AddressGameObjectPoolBehaviour<TPrefab, TPool>
        : UnityPoolBehaviour<GameObject, TPrefab, TPool>
        where TPrefab : AddressGameObjectPrefab
        where TPool : AddressGameObjectPool<TPrefab>
    {
    }
}
