using UnityEngine;

namespace Unity.Pooling.Components
{
    public abstract class GameObjectPoolComponent<TKey>
        : PoolComponentBase<TKey, GameObject, GameObjectPrefab<TKey>, GameObjectPool<TKey>>
    {
        protected sealed override void ReleaseInstance(GameObject instance)
        {
            if (instance)
                Destroy(instance);
        }
    }
}
