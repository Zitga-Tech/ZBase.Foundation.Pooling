using System;
using System.Pooling;
using UnityEngine;

namespace Unity.Pooling
{
    [Serializable]
    public class GameObjectPool
        : GameObjectPoolBase<GameObject, GameObjectInstantiator, GameObjectPrefab>
    {
        public GameObjectPool()
            : base(null, default)
        { }

        public GameObjectPool(GameObjectPrefab prefab)
            : base(null, prefab)
        { }

        public GameObjectPool(UniqueQueue<int, GameObject> queue, GameObjectPrefab prefab)
            : base(queue, prefab)
        { }
    }
}
