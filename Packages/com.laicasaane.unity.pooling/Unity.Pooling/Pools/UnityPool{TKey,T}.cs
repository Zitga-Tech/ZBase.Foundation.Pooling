using System;
using System.Pooling;
using System.Runtime.CompilerServices;
using Collections.Pooled.Generic;
using Collections.Pooled.Generic.Internals.Unsafe;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Unity.Pooling
{
    [Serializable]
    public abstract partial class UnityPool<TKey, T, TSource, TInstantiator, TPrefab>
        : IUnityPool<TKey, T>, IHasPrefab<TPrefab>, IDisposable
        where T : UnityEngine.Object
        where TInstantiator : IAsyncInstantiator<TSource, T>
        where TPrefab : IPrefab<TKey, T, TSource, TInstantiator>
    {
        private readonly Dictionary<TKey, UniqueQueue<int, T>> _queueMap;
        private readonly Func<UniqueQueue<int, T>> _queueInstantiate;

        [SerializeField]
        private TPrefab _prefab;

        [SerializeField]
        private Transform _defaultParent;

        public UnityPool()
            : this(null, null, default, null)
        { }

        public UnityPool(TPrefab prefab, Transform defaultParent = null)
            : this(null, null, prefab, defaultParent)
        { }

        public UnityPool(Dictionary<TKey, UniqueQueue<int, T>> queueMap
            , Func<UniqueQueue<int, T>> queueInstantiate
            , TPrefab prefab
            , Transform defaultParent = null
        )
        {
            _queueMap = queueMap ?? new Dictionary<TKey, UniqueQueue<int, T>>();
            _queueInstantiate = queueInstantiate ?? NewInstancer<UniqueQueue<int, T>>.Instantiate;
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

        public int Count(TKey key)
        {
            if (key is null)
                ThrowHelper.ThrowArgumentNullException(ExceptionArgument.key);

            if (_queueMap.TryGetValue(key, out var queue))
                return queue.Count;

            return 0;
        }

        public void Dispose()
        {
            _queueMap.GetUnsafe(out var entries, out var count);

            for (int i = 0; i < count; i++)
            {
                ref var entry = ref entries[i];

                if (entry.Next >= -1)
                    entry.Value?.Dispose();
            }

            _queueMap.Dispose();
        }

        /// <inheritdoc/>
        public void ReleaseInstances(TKey key, int keep, Action<T> onReleased = null)
        {
            if (key is null)
                ThrowHelper.ThrowArgumentNullException(ExceptionArgument.key);

            if (_queueMap.TryGetValue(key, out var queue))
            {
                var countRemove = queue.Count - keep;

                while (countRemove > 0)
                {
                    if (queue.TryDequeue(out var instance))
                        onReleased?.Invoke(instance.Value);

                    countRemove--;
                }
            }
        }

        public async UniTask<T> RentAsync(TKey key)
        {
            if (key is null)
                ThrowHelper.ThrowArgumentNullException(ExceptionArgument.key);

            if (_queueMap.TryGetValue(key, out var queue)
                && queue.TryDequeue(out var instance))
                return instance.Value;

            return await _prefab.InstantiateAsync(_defaultParent);
        }

        public void Return(TKey key, T instance)
        {
            if (key is null)
                ThrowHelper.ThrowArgumentNullException(ExceptionArgument.key);

            if (instance == false)
                return;

            if (_queueMap.TryGetValue(key, out var queue) == false)
            {
                queue = _queueInstantiate();
                _queueMap[key] = queue;
            }

            ReturnPreprocess(instance);
            queue.Enqueue(instance.ToKVPair());
        }

        protected abstract void ReturnPreprocess(T instance);
    }
}
