using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Unity.Pooling
{
    public class GameObjectPool<TKey> : UnityPoolBase<TKey, GameObject>
    {
        public static readonly GameObjectPool<TKey> Shared  = new GameObjectPool<TKey>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected sealed override void ReturnPreprocess(GameObject instance)
        {
            if (instance.activeSelf)
                instance.SetActive(false);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected sealed override Func<GameObject> GetDefaultInstantiator()
            => Instantiator;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static GameObject Instantiator()
            => new GameObject();
    }
}
