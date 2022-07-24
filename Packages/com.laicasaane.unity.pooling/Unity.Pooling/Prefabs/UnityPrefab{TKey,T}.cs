using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Unity.Pooling
{
    [Serializable]
    public abstract class UnityPrefab<TKey, T, TSource, TInstantiator>
        : UnityPrefab<T, TSource, TInstantiator>, IPrefab<TKey, T, TSource, TInstantiator>
        where T : class
        where TInstantiator : IAsyncInstantiator<TSource, T>
    {
        [SerializeField]
        private TKey _key;

        public TKey Key
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => _key;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => _key = value ?? throw new ArgumentNullException(nameof(value));
        }
    }
}
