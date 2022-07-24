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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public async UniTask<T> InstantiateAsync()
            => await _instantiator.InstantiateAsync();
    }
}
