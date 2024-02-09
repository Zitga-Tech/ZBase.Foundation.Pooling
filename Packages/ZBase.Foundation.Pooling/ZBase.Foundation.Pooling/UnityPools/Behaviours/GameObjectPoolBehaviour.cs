using UnityEngine;

namespace ZBase.Foundation.Pooling.UnityPools
{
    public class GameObjectPoolBehaviour
        : UnityPoolBehaviour<GameObject
            , GameObjectPrefab
            , GameObjectPool
        >
    {
#if UNITY_2022_3_OR_NEWER
        public void PrepoolBatch(UnityEngine.SceneManagement.Scene destinationScene = default)
        {
            var prepooler = new GameObjectBatchPrepooler<GameObjectPrefab>();
            prepooler.Prepool(Pool?.Prefab, destinationScene);
        }
#endif
    }
}
