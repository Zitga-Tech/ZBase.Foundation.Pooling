using UnityEngine;
using Unity.Pooling;
using Unity.Pooling.Components;

namespace Project.Runtime
{
    public class ProjectRuntime : MonoBehaviour
    {
        [SerializeField]
        private UnityPrefab<GameObject> _prefabT;

        [SerializeField]
        private UnityPrefab<string, GameObject> _prefabTKey;
    }
}
