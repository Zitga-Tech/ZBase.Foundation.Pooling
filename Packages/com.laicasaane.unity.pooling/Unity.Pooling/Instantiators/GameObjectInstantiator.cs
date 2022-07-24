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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override async UniTask<GameObject> InstantiateAsync(GameObject source, Transform parent)
        {
            var instance = UnityEngine.Object.Instantiate(Source, parent);
            return await UniTask.FromResult(instance);
        }
    }
}
