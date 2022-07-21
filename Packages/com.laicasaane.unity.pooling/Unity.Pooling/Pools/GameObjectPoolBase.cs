using System.Pooling;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Unity.Pooling
{
    public abstract class GameObjectPoolBase<S, TSource, TPrefab>
        : UnityPool<GameObject, S, TSource, TPrefab>
        where TSource : IAsyncInstantiatableSource<S, GameObject>
        where TPrefab : IPrefab<GameObject, S, TSource>
    {
        public GameObjectPoolBase()
            : base(null, default, null)
        { }

        public GameObjectPoolBase(TPrefab prefab, Transform defaultParent = null)
            : base(null, prefab, defaultParent)
        { }

        public GameObjectPoolBase(UniqueQueue<int, GameObject> queue, TPrefab prefab, Transform defaultParent = null)
            : base(queue, prefab, defaultParent)
        { }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected sealed override void ReturnPreprocess(GameObject instance)
        {
            if (instance.activeSelf)
                instance.SetActive(false);
        }
    }
}
