using UnityEngine;
using ZBase.Foundation.Pooling;
using ZBase.Foundation.Pooling.AddressableAssets;
using ZBase.Foundation.Pooling.UnityPools;

namespace Project.Runtime
{
    public class ProjectRuntime : MonoBehaviour
    {
        private void Start()
        {
            this.gameObject.AddComponent<ComponentPoolBehaviour<BoxCollider>>();
            var pool = SharedPool.Of<AddressGameObjectPool>();
            pool.ReleaseInstances(1);
        }
    }
}
