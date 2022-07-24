using System;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Unity.Pooling
{
    [Serializable]
    public abstract class UnityPrefab<T, TSource, TInstantiator>
        : IPrefab<T, TSource, TInstantiator>
        where T : class
        where TInstantiator : IAsyncInstantiator<TSource, T>
    {
        [SerializeField]
        private TInstantiator _instantiator;

        [SerializeField]
        private int _prepoolAmount;

        [SerializeField]
        private Transform _parent;

        public TInstantiator Instantiator
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => _instantiator;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => _instantiator = value ?? throw new ArgumentNullException(nameof(value));
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
            => await _instantiator.InstantiateAsync(parent);
    }
}
