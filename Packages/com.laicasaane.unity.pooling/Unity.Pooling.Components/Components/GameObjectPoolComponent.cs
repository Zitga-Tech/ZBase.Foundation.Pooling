using UnityEngine;

namespace Unity.Pooling.Components
{
    public sealed class GameObjectPoolComponent
        : UnityPoolComponentBase<GameObject, GameObjectPrefab, GameObjectPool>
    {
        protected override void ReleaseInstance(GameObject instance)
        {
            if (instance)
                Destroy(instance);
        }
    }
}
