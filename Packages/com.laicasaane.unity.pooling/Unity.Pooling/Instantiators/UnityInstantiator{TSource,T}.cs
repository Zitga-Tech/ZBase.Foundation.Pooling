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

        public abstract UniTask<T> InstantiateAsync(Transform parent);
    }
}
