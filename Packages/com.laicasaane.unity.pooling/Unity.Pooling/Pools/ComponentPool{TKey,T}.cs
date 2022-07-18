using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Unity.Pooling
{
    public class ComponentPool<TKey, T> : UnityPoolBase<TKey, T>
        where T : UnityEngine.Component
    {
        public static readonly ComponentPool<TKey, T> Shared  = new ComponentPool<TKey, T>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override void ReturnPreprocess(T instance)
        {
            if (instance.gameObject.activeSelf)
                instance.gameObject.SetActive(false);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override Func<T> GetDefaultInstantiator()
            => Instantiator;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static T Instantiator()
        {
            var go = new GameObject(NameOf<T>.Value);
            var instance = go.AddComponent<T>();
            return instance;
        }
    }
}
