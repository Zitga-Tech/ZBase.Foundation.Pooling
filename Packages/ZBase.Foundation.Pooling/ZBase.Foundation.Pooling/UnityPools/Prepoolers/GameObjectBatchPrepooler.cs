#if UNITY_2022_3_OR_NEWER

using Unity.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ZBase.Foundation.Pooling.UnityPools
{
    public struct GameObjectBatchPrepooler<TPrefab>
        where TPrefab : IPrefab<GameObject, GameObject>
    {
        public void Prepool(TPrefab prefab, Scene destinationScene = default)
        {
            if (prefab == null)
                ThrowHelper.ThrowArgumentNullException(ExceptionArgument.prefab);

            if (prefab.PrepoolAmount <= 0)
                return;

            var newInstanceIDs = Instantiate(prefab.Source, prefab.PrepoolAmount, Allocator.Temp, destinationScene);
            
            GameObject.SetGameObjectsActive(newInstanceIDs, false);
        }

        public NativeArray<int> Instantiate(
              GameObject source
            , int count
            , Allocator allocator = Allocator.Temp
            , Scene destinationScene = default
        )
        {
            if (source == false)
            {
                ThrowHelper.ThrowNullReferenceException(ExceptionArgument.source);
            }

            var newInstanceIDs = new NativeArray<int>(count, allocator);
            var newTransformInstanceIDs = new NativeArray<int>(count, Allocator.Temp);
            var sourceInstanceID = source.GetInstanceID();

            GameObject.InstantiateGameObjects(
                  sourceInstanceID
                , count
                , newInstanceIDs
                , newTransformInstanceIDs
                , destinationScene
            );

            return newInstanceIDs;
        }
    }
}

#endif
