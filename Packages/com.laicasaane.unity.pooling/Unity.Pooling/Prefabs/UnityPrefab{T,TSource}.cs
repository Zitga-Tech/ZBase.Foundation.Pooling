using System;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Unity.Pooling
{
    [Serializable]
    public abstract class UnityPrefab<T, TSource>
        : IPrefab<T, TSource>
        where T : class
    {
        [SerializeField]
        private TSource _source;

        [SerializeField]
        private Transform _parent;

        [SerializeField]
        private int _prepoolAmount;

        public TSource Source
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => _source;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => _source = value;
        }

        public Transform Parent
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => _parent;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => _parent = value;
        }

        public int PrepoolAmount
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => _prepoolAmount;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => _prepoolAmount = value;
        }

        public async UniTask<T> Instantiate()
        {
            if (_source is null)
                throw new NullReferenceException(nameof(Source));

            return await Instantiate(Source, Parent);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected abstract UniTask<T> Instantiate(TSource source, Transform parent);
    }
}
