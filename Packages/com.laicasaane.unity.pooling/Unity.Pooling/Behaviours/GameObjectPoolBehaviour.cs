using UnityEngine;

namespace Unity.Pooling
{
    public class GameObjectPoolBehaviour
        : UnityPoolBehaviour<GameObject, GameObject
            , GameObjectPrefab
            , GameObjectPool
            , GameObjectPrepooler<GameObjectPool>
        >
    {
    }
}
