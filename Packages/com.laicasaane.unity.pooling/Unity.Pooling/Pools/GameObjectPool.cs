using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Unity.Pooling
{
    public sealed class GameObjectPool : UnityPoolBase<GameObject>
    {
        public static readonly GameObjectPool Shared  = new GameObjectPool();
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override void ReturnPreprocess(GameObject instance)
        {
            if (instance.activeSelf)
                instance.SetActive(false);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override Func<GameObject> GetInstantiator()
            => Instantiator;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static GameObject Instantiator()
            => new GameObject();
    }
}
