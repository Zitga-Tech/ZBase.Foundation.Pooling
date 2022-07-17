using System.Buffers;
using System.Runtime.CompilerServices;
using Collections.Pooled;
using Collections.Pooled.Generic;
using Collections.Pooled.Generic.Internals;

namespace System.Pooling
{
    public abstract partial class PoolBase<TKey, T> : IPool<TKey, T>, IDisposable
        where T : class, new()
    {
        private readonly Func<T> _instantiate;
        private readonly ArrayPool<T> _pool;
        private readonly Dictionary<TKey, Queue<T>> _queueMap;

        public PoolBase()
            : this(null, ArrayPool<T>.Shared)
        { }

        public PoolBase(ArrayPool<T> pool)
            : this(null, pool)
        { }

        public PoolBase(Func<T> instantiate)
            : this(instantiate, ArrayPool<T>.Shared)
        { }

        public PoolBase(Func<T> instantiate, ArrayPool<T> pool)
            : this(instantiate, pool, ArrayPool<int>.Shared, ArrayPool<Entry<TKey, Queue<T>>>.Shared)
        { }

        public PoolBase(ArrayPool<T> pool, ArrayPool<int> poolBucket, ArrayPool<Entry<TKey, Queue<T>>> poolEntry)
            : this(null, pool, poolBucket, poolEntry)
        { }

        public PoolBase(Func<T> instantiate, ArrayPool<T> pool, ArrayPool<int> poolBucket, ArrayPool<Entry<TKey, Queue<T>>> poolEntry)
        {
            _instantiate = instantiate ?? GetInstantiator() ?? DefaultInstantiator<T>.Get();
            _pool = pool ?? ArrayPool<T>.Shared;

            _queueMap = new Dictionary<TKey, Queue<T>>(
                poolBucket ?? ArrayPool<int>.Shared
                , poolEntry ?? ArrayPool<Entry<TKey, Queue<T>>>.Shared
            );
        }

        public int Count(TKey key)
        {
            if (key is null)
                throw new ArgumentNullException(nameof(key));

            if (_queueMap.TryGetValue(key, out var queue))
                return queue.Count;

            return 0;
        }

        public void Dispose()
        {
            var entries = CollectionInternals.GetRef(_queueMap).Entries;

            for (int i = 0, len = entries.Length; i < len; i++)
            {
                entries[i].Value.Dispose();
            }

            _queueMap.Dispose();
        }

        public void ReleaseInstances(TKey key, int keep, Action<T> onReleased = null)
        {
            if (key is null)
                throw new ArgumentNullException(nameof(key));

            if (_queueMap.TryGetValue(key, out var queue))
            {
                var countRemove = queue.Count - keep;

                while (countRemove > 0)
                {
                    var instance = queue.Dequeue();
                    onReleased?.Invoke(instance);
                    countRemove--;
                }
            }
        }

        public T Rent(TKey key)
        {
            if (key is null)
                throw new ArgumentNullException(nameof(key));

            if (_queueMap.TryGetValue(key, out var queue))
            {
                if (queue.Count > 0)
                    return queue.Dequeue();
            }

            return _instantiate();
        }

        public void Return(TKey key, T instance)
        {
            if (key is null)
                throw new ArgumentNullException(nameof(key));

            if (instance is null)
                return;

            if (_queueMap.TryGetValue(key, out var queue) == false)
            {
                queue = new Queue<T>(_pool);
                _queueMap[key] = queue;
            }

            ReturnPreprocess(instance);
            queue.Enqueue(instance);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected virtual void ReturnPreprocess(T instance) { }

        protected virtual Func<T> GetInstantiator() => DefaultInstantiator<T>.Get();
    }
}
