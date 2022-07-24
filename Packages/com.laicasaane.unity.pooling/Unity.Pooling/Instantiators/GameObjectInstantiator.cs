using System;
using System.Runtime.CompilerServices;
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

        public GameObjectInstantiator(Transform parent) : base(parent)
        { }

        public GameObjectInstantiator(GameObject source, Transform parent) : base(source, parent)
        { }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override async UniTask<GameObject> InstantiateAsync(GameObject source, Transform parent)
        {
            GameObject instance;

            if (parent)
                instance = UnityEngine.Object.Instantiate(Source, parent);
            else
                instance = UnityEngine.Object.Instantiate(Source);

            return await UniTask.FromResult(instance);
        }
    }
}
