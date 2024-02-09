using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

namespace Project.Runtime
{
    public class ProjectRuntime : MonoBehaviour
    {
        [SerializeField]
        private MeshRenderer _prefab;

        [SerializeField]
        private List<Object> _instances;

        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                var count = 100;
                var allocator = Allocator.Temp;
                var newInstanceIDs = new NativeArray<int>(count, allocator);
                var newTransformInstanceIDs = new NativeArray<int>(count, Allocator.Temp);
                var sourceInstanceID = _prefab.gameObject.GetInstanceID();

                GameObject.InstantiateGameObjects(
                      sourceInstanceID
                    , count
                    , newInstanceIDs
                    , newTransformInstanceIDs
                );

                GameObject.SetGameObjectsActive(newInstanceIDs, false);
                _instances = new List<Object>(count);
                Resources.InstanceIDToObjectList(newInstanceIDs, _instances);
            }
        }
    }
}
