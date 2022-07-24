using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using Cysharp.Threading.Tasks;

namespace Unity.Pooling
{
    [Serializable]
    public abstract class UnityInstantiator<TSource, T> : IAsyncInstantiator<TSource, T>
        where T : UnityEngine.Object
    {
        [SerializeField]
        private TSource _source;

        [SerializeField]
        private Transform _parent;

        public UnityInstantiator() { }

        public UnityInstantiator(TSource source)
        {
            _source = source ?? throw new ArgumentNullException(nameof(source));
        }

        public TSource Source
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => _source;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => _source = value ?? throw new ArgumentNullException(nameof(value));
        }

        public Transform Parent
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => _parent;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => _parent = value ?? throw new ArgumentNullException(nameof(value));
        }

        public async UniTask<T> InstantiateAsync()
        {
            if (Source is null)
                throw new NullReferenceException(nameof(Source));

            return await InstantiateAsync(Source, Parent);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected abstract UniTask<T> InstantiateAsync(TSource source, Transform parent);
    }
}
