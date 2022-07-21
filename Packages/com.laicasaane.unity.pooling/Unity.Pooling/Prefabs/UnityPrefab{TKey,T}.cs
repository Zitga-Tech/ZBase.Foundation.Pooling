using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Unity.Pooling
{
    [Serializable]
    public abstract class UnityPrefab<TKey, T, S, TSource>
        : UnityPrefab<T, S, TSource>, IPrefab<TKey, T, S, TSource>
        where T : class
        where TSource : IAsyncInstantiatableSource<S, T>
    {
        [SerializeReference]
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
