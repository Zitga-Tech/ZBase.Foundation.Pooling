using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Unity.Pooling
{
    [Serializable]
    public class GameObjectInstantiator : UnityInstantiator<GameObject, GameObject>
    {
        public GameObjectInstantiator() : base()
        { }

        public GameObjectInstantiator(GameObject source) : base(source)
        { }

        public override async UniTask<GameObject> InstantiateAsync(Transform parent)
        {
            if (Source)
            {
                var instance = UnityEngine.Object.Instantiate(Source, parent);
                return await UniTask.FromResult(instance);
            }

            throw new NullReferenceException(nameof(Source));
        }
    }
}
