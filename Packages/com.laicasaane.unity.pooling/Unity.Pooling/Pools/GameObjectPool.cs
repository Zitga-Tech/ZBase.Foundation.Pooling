using System;
using System.Pooling;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Unity.Pooling
{
    public sealed class GameObjectPool : UnityPoolBase<GameObject>
    {
        public GameObjectPool()
            : base(null, null)
        { }

        public GameObjectPool(UniqueQueue<int, GameObject> queue)
            : base(queue, null)
        { }

        public GameObjectPool(Func<GameObject> instantiate)
            : base(null, instantiate)
        { }

        public GameObjectPool(UniqueQueue<int, GameObject> queue, Func<GameObject> instantiate)
            : base(queue, instantiate)
        { }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override void ReturnPreprocess(GameObject instance)
        {
            if (instance.activeSelf)
                instance.SetActive(false);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override Func<GameObject> GetDefaultInstantiator()
            => Instantiator;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static GameObject Instantiator()
            => new GameObject();
    }
}
