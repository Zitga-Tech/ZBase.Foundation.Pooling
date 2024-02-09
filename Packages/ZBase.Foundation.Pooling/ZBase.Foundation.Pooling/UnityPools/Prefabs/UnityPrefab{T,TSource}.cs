using System;
using System.Threading;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace ZBase.Foundation.Pooling.UnityPools
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
            {
                ThrowHelper.ThrowNullReferenceException(ExceptionArgument._source);
            }

            return await Instantiate(Source, Parent);
        }

        public async UniTask<T> Instantiate(CancellationToken cancelToken)
        {
            if (_source is null)
            {
                ThrowHelper.ThrowNullReferenceException(ExceptionArgument._source);
            }

            return await Instantiate(Source, Parent, cancelToken);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected abstract UniTask<T> Instantiate(
              TSource source
            , Transform parent
            , CancellationToken cancelToken = default)
        ;

        public abstract void Release(T instance);
    }
}
