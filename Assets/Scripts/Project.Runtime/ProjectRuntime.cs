using System.Pooling;
using Unity.Pooling;
using Unity.Pooling.AddressableAssets;
using UnityEngine;

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
