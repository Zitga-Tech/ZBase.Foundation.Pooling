using System.Pooling;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Unity.Pooling
{
    public class GameObjectPool
        : UnityPool<GameObject, GameObject, GameObjectSource, GameObjectPrefab>
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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override void ReturnPreprocess(GameObject instance)
        {
            if (instance.activeSelf)
                instance.SetActive(false);
        }
    }
}
