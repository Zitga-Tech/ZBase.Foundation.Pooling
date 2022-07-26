using UnityEngine;

namespace Unity.Pooling
{
    public class GameObjectPoolBehaviour
        : UnityPoolBehaviour<GameObject, GameObject
            , GameObjectPrefab
            , GameObjectPool
            , UnityPrepooler<GameObject, GameObject, GameObjectPrefab, GameObjectPool>
        >
    {
    }
}
