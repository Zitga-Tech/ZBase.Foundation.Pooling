using System;
using System.Pooling;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Unity.Pooling
{
    public abstract partial class UnityPool<T, TSource, TInstantiator, TPrefab>
        : IUnityPool<T>, IHasPrefab<TPrefab>, IDisposable
        where T : UnityEngine.Object
        where TInstantiator : IAsyncInstantiator<TSource, T>
        where TPrefab : IPrefab<T, TSource, TInstantiator>
    {
        private readonly UniqueQueue<int, T> _queue;

        private TPrefab _prefab;
        private Transform _defaultParent;

        public UnityPool()
            : this(null, default, null)
        { }

        public UnityPool(TPrefab prefab, Transform defaultParent = null)
            : this(null, prefab, defaultParent)
        { }

        public UnityPool(UniqueQueue<int, T> queue, TPrefab prefab, Transform defaultParent = null)
        {
            _queue = queue ?? new UniqueQueue<int, T>();
            _prefab = prefab;
            _defaultParent = defaultParent;
        }

        public TPrefab Prefab
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => _prefab;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => _prefab = value;
        }

        public Transform DefaultParent
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => _defaultParent;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => _defaultParent = value;
        }

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
                var instance = _queue.Dequeue();
                onReleased?.Invoke(instance.Value);
                countRemove--;
            }
        }

        public async UniTask<T> RentAsync()
        {
            if (_queue.TryDequeue(out var instance))
                return instance.Value;

            return await _prefab.InstantiateAsync(_defaultParent);
        }

        public void Return(T instance)
        {
            if (instance == false)
                return;

            ReturnPreprocess(instance);
            _queue.Enqueue(instance.ToKVPair());
        }

        protected abstract void ReturnPreprocess(T instance);
    }
}
