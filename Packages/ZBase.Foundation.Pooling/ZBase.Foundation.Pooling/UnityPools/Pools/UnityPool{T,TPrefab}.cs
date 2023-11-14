﻿using System;
using System.Threading;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace ZBase.Foundation.Pooling.UnityPools
{
    [Serializable]
    public class UnityPool<T, TPrefab>
        : IUnityPool<T, TPrefab>, IShareable, IDisposable
        where T : UnityEngine.Object
        where TPrefab : IPrefab<T>
    {
        private readonly UniqueQueue<int, T> _queue;

        [SerializeField]
        private TPrefab _prefab;

        public UnityPool()
        {
            _queue = new UniqueQueue<int, T>();
        }

        public UnityPool(TPrefab prefab)
        {
            _queue = new UniqueQueue<int, T>();
            _prefab = prefab ?? throw new ArgumentNullException(nameof(prefab));
        }

        public UnityPool(UniqueQueue<int, T> queue)
        {
            _queue = queue ?? throw new ArgumentNullException(nameof(queue));
        }

        public UnityPool(UniqueQueue<int, T> queue, TPrefab prefab)
        {
            _queue = queue ?? throw new ArgumentNullException(nameof(queue));
            _prefab = prefab ?? throw new ArgumentNullException(nameof(prefab));
        }

        public TPrefab Prefab
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => _prefab;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => _prefab = value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Count() => _queue.Count;

        public void Dispose()
        {
            _queue.Dispose();
        }

        /// <inheritdoc/>
        public void ReleaseInstances(int keep, Action<T> onReleased = null)
        {
            var countRemove = _queue.Count - keep;

            while (countRemove > 0)
            {
                if (_queue.TryDequeue(out var _, out var instance))
                {
                    if (onReleased != null)
                        onReleased(instance);
                    else if (_prefab != null)
                        _prefab.Release(instance);
                }

                countRemove--;
            }
        }

        public async UniTask<T> Rent()
        {
            if (_queue.TryDequeue(out var _, out var instance) == false)
            {
                instance = await _prefab.Instantiate();
            }

            await RentPostprocess(instance, default);
            return instance;
        }

        public async UniTask<T> Rent(CancellationToken cancelToken)
        {
            if (_queue.TryDequeue(out var _, out var instance) == false)
            {
                instance = await _prefab.Instantiate(cancelToken);
            }

            await RentPostprocess(instance, cancelToken);
            return instance;
        }

        public void Return(T instance)
        {
            if (instance == false)
                return;

            ReturnPreprocess(instance);
            _queue.TryEnqueue(instance.GetInstanceID(), instance);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected virtual UniTask RentPostprocess(T instance, CancellationToken cancelToken)
            => UniTask.CompletedTask;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected virtual void ReturnPreprocess(T instance) { }
    }
}
