using Unity.Pooling;
using UnityEngine;

namespace Project.Runtime
{
    public class ProjectRuntime : MonoBehaviour
    {
        private void Start()
        {
            this.gameObject.AddComponent<ComponentPoolBehaviour<BoxCollider>>();
        }
    }
}
