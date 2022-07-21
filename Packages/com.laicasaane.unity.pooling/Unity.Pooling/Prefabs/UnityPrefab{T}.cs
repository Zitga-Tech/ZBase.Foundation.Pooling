using System;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Unity.Pooling
{
    [Serializable]
    public abstract class UnityPrefab<T, S, TSource>
        : IPrefab<T, S, TSource>
        where T : class
        where TSource : IAsyncInstantiatableSource<S, T>
    {
        [SerializeField]
        private TSource _source;

        [SerializeField]
        private int _prepoolAmount;

        [SerializeField]
        private Transform _parent;

        public TSource Source
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => _source;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => _source = value ?? throw new ArgumentNullException(nameof(value));
        }

        public int PrepoolAmount
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => _prepoolAmount;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => _prepoolAmount = value;
        }

        public Transform Parent
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => _parent;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => _parent = value ?? throw new ArgumentNullException(nameof(value));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public async UniTask<T> InstantiateAsync(Transform parent)
            => await _source.InstantiateAsync(parent);
    }
}
