using System.Buffers;
using System.Runtime.CompilerServices;
using Collections.Pooled;
using Collections.Pooled.Generic;
using Collections.Pooled.Generic.Internals;
using Cysharp.Threading.Tasks;

namespace System.Pooling
{
    public abstract class AsyncPoolBase<TKey, T> : IAsyncPool<TKey, T>, IDisposable
        where T : class, new()
    {
        private readonly UniTaskFunc<T> _instantiate;
        private readonly ArrayPool<T> _pool;
        private readonly Dictionary<TKey, Queue<T>> _queueMap;

        public AsyncPoolBase()
            : this(null, ArrayPool<T>.Shared)
        { }

        public AsyncPoolBase(ArrayPool<T> pool)
            : this(null, pool)
        { }

        public AsyncPoolBase(UniTaskFunc<T> instantiate)
            : this(instantiate, ArrayPool<T>.Shared)
        { }

        public AsyncPoolBase(UniTaskFunc<T> instantiate, ArrayPool<T> pool)
            : this(instantiate, pool, ArrayPool<int>.Shared, ArrayPool<Entry<TKey, Queue<T>>>.Shared)
        { }

        public AsyncPoolBase(ArrayPool<T> pool, ArrayPool<int> poolBucket, ArrayPool<Entry<TKey, Queue<T>>> poolEntry)
            : this(null, pool, poolBucket, poolEntry)
        { }

        public AsyncPoolBase(UniTaskFunc<T> instantiate, ArrayPool<T> pool, ArrayPool<int> poolBucket, ArrayPool<Entry<TKey, Queue<T>>> poolEntry)
        {
            _instantiate = instantiate ?? GetInstantiator() ?? DefaultAsyncInstantiator<T>.Get();
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

        public AsyncDisposableContext<TKey, T> Poolable()
            => new AsyncDisposableContext<TKey, T>(this);

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

        public async UniTask<T> RentAsync(TKey key)
        {
            if (key is null)
                throw new ArgumentNullException(nameof(key));

            if (_queueMap.TryGetValue(key, out var queue))
            {
                if (queue.Count > 0)
                    return queue.Dequeue();
            }

            return await _instantiate();
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

        protected virtual UniTaskFunc<T> GetInstantiator() => DefaultAsyncInstantiator<T>.Get();
    }
}
