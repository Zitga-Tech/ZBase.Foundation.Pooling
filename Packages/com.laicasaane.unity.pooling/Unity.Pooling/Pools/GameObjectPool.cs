using System.Pooling;
using UnityEngine;

namespace Unity.Pooling
{
    public class GameObjectPool
        : GameObjectPoolBase<GameObject, GameObjectSource, GameObjectPrefab>
    {
        public GameObjectPool()
            : base(null, default, null)
        { }

        public GameObjectPool(GameObjectPrefab prefab, Transform defaultParent = null)
            : base(null, prefab, defaultParent)
        { }

        public GameObjectPool(UniqueQueue<int, GameObject> queue, GameObjectPrefab prefab, Transform defaultParent = null)
            : base(queue, prefab, defaultParent)
        { }
    }
}
