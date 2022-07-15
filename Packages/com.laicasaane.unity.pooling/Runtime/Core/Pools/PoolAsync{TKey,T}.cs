using System;
using System.Buffers;
using Collections.Pooled;
using Collections.Pooled.Generic;
using Cysharp.Threading.Tasks;

namespace Unity.Pooling
{
    public class PoolAsync<TKey, T> : IAsyncPool<TKey, T>
        where T : class, new()
    {
        public static readonly PoolAsync<TKey, T> Shared = new PoolAsync<TKey, T>();

        private readonly UniTaskFunc<T> _instantiate;
        private readonly ArrayPool<T> _pool;
        private readonly Dictionary<TKey, Queue<T>> _queueMap;

        public PoolAsync()
            : this(Instantiator.Instantiate, ArrayPool<T>.Shared)
        { }

        public PoolAsync(ArrayPool<T> pool)
            : this(Instantiator.Instantiate, pool)
        { }

        public PoolAsync(UniTaskFunc<T> instantiate)
            : this(instantiate, ArrayPool<T>.Shared)
        { }

        public PoolAsync(UniTaskFunc<T> instantiate, ArrayPool<T> pool)
            : this(instantiate, pool, ArrayPool<int>.Shared, ArrayPool<Entry<TKey, Queue<T>>>.Shared)
        { }

        public PoolAsync(ArrayPool<T> pool, ArrayPool<int> poolBucket, ArrayPool<Entry<TKey, Queue<T>>> poolEntry)
            : this(Instantiator.Instantiate, pool, poolBucket, poolEntry)
        { }

        public PoolAsync(UniTaskFunc<T> instantiate, ArrayPool<T> pool, ArrayPool<int> poolBucket, ArrayPool<Entry<TKey, Queue<T>>> poolEntry)
        {
            _instantiate = instantiate ?? Instantiator.Instantiate;
            _pool = pool ?? ArrayPool<T>.Shared;

            _queueMap = new Dictionary<TKey, Queue<T>>(
                poolBucket ?? ArrayPool<int>.Shared
                , poolEntry ?? ArrayPool<Entry<TKey, Queue<T>>>.Shared
            );
        }

        public int Count(TKey key)
        {
            if (_queueMap.TryGetValue(key, out var queue))
                return queue.Count;

            return 0;
        }

        public void ReleaseInstances(TKey key, int keep, Action<T> onReleased = null)
        {
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
            if (_queueMap.TryGetValue(key, out var queue))
            {
                if (queue.Count > 0)
                    return queue.Dequeue();
            }

            return await _instantiate();
        }

        public void Return(TKey key, T instance)
        {
            if (_queueMap.TryGetValue(key, out var queue) == false)
                queue = new Queue<T>(_pool);

            ReturnPreprocess(instance);
            queue.Enqueue(instance);
        }

        protected virtual void ReturnPreprocess(T instance) { }

        private static class Instantiator
        {
            private static readonly Type s_type = typeof(T);

            public static async UniTask<T> Instantiate()
            {
                var result = (T)Activator.CreateInstance(s_type);
                return await UniTask.FromResult(result);
            }
        }
    }
}
