using System;
using UnityEngine;

namespace ZBase.Foundation.Pooling.UnityPools
{
    [Serializable]
    public class GameObjectPool
        : GameObjectPool<GameObjectPrefab>
    {
        public GameObjectPool()
            : base()
        { }

        public GameObjectPool(GameObjectPrefab prefab)
            : base(prefab)
        { }

        public GameObjectPool(UniqueQueue<int, GameObject> queue)
            : base(queue)
        { }

        public GameObjectPool(UniqueQueue<int, GameObject> queue, GameObjectPrefab prefab)
            : base(queue, prefab)
        { }
    }
}
