using UnityEngine;

namespace Unity.Pooling
{
    public class GameObjectPoolBehaviour<TKey>
        : UnityPoolBehaviour<TKey, GameObject, GameObject
            , GameObjectInstantiator
            , GameObjectPrefab<TKey>
            , GameObjectPool<TKey>
            , GameObjectPrepooler<TKey, GameObjectPool<TKey>>
        >
    {
    }
}
