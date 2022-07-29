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
            SharedPool.Of<AddressGameObjectPool>();
        }
    }
}
