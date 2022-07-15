using System;
using System.Buffers;
using Collections.Pooled;
using Collections.Pooled.Generic;

namespace Unity.Pooling
{
    public class Pool<TKey, T> : IPool<TKey, T>
        where T : class, new()
    {
        public static readonly Pool<TKey, T> Shared = new Pool<TKey, T>();

        private readonly Func<T> _instantiate;
        private readonly ArrayPool<T> _pool;
        private readonly Dictionary<TKey, Queue<T>> _queueMap;

        public Pool()
            : this(Instantiator.Instantiate, ArrayPool<T>.Shared)
        { }

        public Pool(ArrayPool<T> pool)
            : this(Instantiator.Instantiate, pool)
        { }

        public Pool(Func<T> instantiate)
            : this(instantiate, ArrayPool<T>.Shared)
        { }

        public Pool(Func<T> instantiate, ArrayPool<T> pool)
            : this(instantiate, pool, ArrayPool<int>.Shared, ArrayPool<Entry<TKey, Queue<T>>>.Shared)
        { }

        public Pool(ArrayPool<T> pool, ArrayPool<int> poolBucket, ArrayPool<Entry<TKey, Queue<T>>> poolEntry)
            : this(Instantiator.Instantiate, pool, poolBucket, poolEntry)
        { }

        public Pool(Func<T> instantiate, ArrayPool<T> pool, ArrayPool<int> poolBucket, ArrayPool<Entry<TKey, Queue<T>>> poolEntry)
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

        public T Rent(TKey key)
        {
            if (_queueMap.TryGetValue(key, out var queue))
            {
                if (queue.Count > 0)
                    return queue.Dequeue();
            }

            return _instantiate();
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

            public static T Instantiate() => (T)Activator.CreateInstance(s_type);
        }
    }
}
